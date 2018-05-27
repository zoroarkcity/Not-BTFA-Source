using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.GhastlyEnt
{
	[AutoloadBossHead]
    public class GhastlyEnt : ModNPC
    {
		bool p3;
		bool biphronSeeds = false;
		Vector2 SeedPos;
		int seedcounter;
		int timer1 = 0;
		
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 35000;
            npc.damage = 60;
            npc.defense = 20;
            npc.knockBackResist = 0f;
            npc.width = 202;
            npc.height = 310;
            npc.value = 150000;
			npc.buffImmune[31] = true;
			npc.buffImmune[20] = true;
			npc.buffImmune[70] = true;
			npc.buffImmune[186] = true;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath10;
            music = 12;
			npc.npcSlots = 5;
			NPCID.Sets.TrailCacheLength[npc.type] = 10;
			NPCID.Sets.TrailingMode[npc.type] = 1;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = 50000 + ((numPlayers) * 20000);
			npc.damage = 90;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ghastly Ent");
			Main.npcFrameCount[npc.type] = 7;
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (npc.spriteDirection > 0)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
			Microsoft.Xna.Framework.Color color25 = Lighting.GetColor((int)((double)npc.position.X + (double)npc.width * 0.5) / 16, (int)(((double)npc.position.Y + (double)npc.height * 0.5) / 16.0));
			Texture2D texture2D3 = Main.npcTexture[npc.type];
			int num156 = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
			int y3 = num156 * (int)npc.frameCounter;
			Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(0, y3, texture2D3.Width, num156);
			Vector2 origin2 = rectangle.Size() / 2f;
			int arg_5ADA_0 = npc.type;
			int arg_5AE7_0 = npc.type;
			int arg_5AF4_0 = npc.type;
			int num157 = 10;
			int num158 = 2;
			int num159 = 1;
			float value3 = 1f;
			float num160 = 0f;
			
			int num161 = num159;
			while (npc.velocity != Vector2.Zero &&((num158 > 0 && num161 < num157) || (num158 < 0 && num161 > num157)))
			{
				Microsoft.Xna.Framework.Color color26 = color25;
				color26 = npc.GetAlpha(color26);		
				{
					goto IL_6899;
				}
				color26 = Microsoft.Xna.Framework.Color.Lerp(color26, Microsoft.Xna.Framework.Color.Green, 0.5f);
				
				IL_6881:
				num161 += num158;
				continue;
				IL_6899:
				float num164 = (float)(num157 - num161);
				if (num158 < 0)
				{
					num164 = (float)(num159 - num161);
				}
				color26 *= num164 / ((float)NPCID.Sets.TrailCacheLength[npc.type] * 1.5f);
				Vector2 value4 = (npc.oldPos[num161]);
				float num165 = npc.rotation;
				SpriteEffects effects = spriteEffects;
				Main.spriteBatch.Draw(texture2D3, value4 + npc.Size / 2f - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color26, num165 + npc.rotation * num160 * (float)(num161 - 1) * -(float)spriteEffects.HasFlag(SpriteEffects.FlipHorizontally).ToDirectionInt(), origin2, npc.scale, effects, 0f);
				goto IL_6881;
			}

			string ownTexture = "NPCs/GhastlyEnt/GhastlyEnt";
			if (p3)
			{
				ownTexture += "P3";
			}

			Texture2D texture2D4 = mod.GetTexture(ownTexture);
			int num1561 = texture2D4.Height / Main.npcFrameCount[npc.type];
			int y31 = num1561 * (int)npc.frameCounter;
			Microsoft.Xna.Framework.Rectangle rectangle2 = new Microsoft.Xna.Framework.Rectangle(0, y31, texture2D4.Width, num1561);
			Vector2 origin3 = rectangle2.Size() / 2f;
			float num166 = npc.rotation;
			Microsoft.Xna.Framework.Color color39 = npc.GetAlpha(color25);
			Main.spriteBatch.Draw(texture2D4, npc.position + npc.Size / 2f - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle2), color39, num166 + npc.rotation * num160 * (float)(num161 - 1) * -(float)spriteEffects.HasFlag(SpriteEffects.FlipHorizontally).ToDirectionInt(), origin3, npc.scale, spriteEffects, 0f);
			return false;
		}

        public override void AI()
        {
			npc.TargetClosest(true);
			npc.spriteDirection = npc.direction;
			
            Player player = Main.player[npc.target];
			
			if (npc.alpha > 255)
				npc.alpha = 255;
			
			if (npc.life > (int)(npc.lifeMax/2) && !Main.expertMode || npc.life > (int)(npc.lifeMax * 0.66) && Main.expertMode)
			{
				Phase1(player);
			}
					
			if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                npc.velocity.Y = -20;
				
				if (npc.timeLeft > 10)
				{
					npc.timeLeft = 10;
				}
            }
		}
		
		public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			BTFAUtility.DrawNPCGlowMask(spriteBatch, npc, mod.GetTexture("NPCs/GhastlyEnt/GhastlyEnt_Glow1"));
		}
		
		public void Phase1(Player player)
		{
			timer1++;
			Phase1Movement(player);

			if (timer1 % 180 == 0)
			{
				switch(Main.rand.Next(3))
				{
					case 0: biphronSeeds = true;
						SeedPos = player.Center;
						break;
					case 1: Leafnados(player);
						break;
					case 2: LeafRain(player);
						break;
				}
			}
			
			if(biphronSeeds)
			{
				BiphronSeeds(player, SeedPos);
			}
		}
		
		public void LeafRain(Player player)
		{
			for(int i = 0; i < 3; i++)
			{
				Vector2 Position = player.Center;
				Position.Y -= 100 + ((i == (0 | 2))? 50 : 0);
				Position.X += (i * 50) - 50;
				for(int k = 0; k < 5; k++)
				{
					Vector2 Vel = player.Center - Position;
					Vel.Normalize();
					Vel *= 5;
					Vector2 Offset = new Vector2(10, 0).RotatedBy((MathHelper.Pi / 5) * k);
					Projectile.NewProjectile(Position + Offset, Vel, mod.ProjectileType("GiantLeaf"), (int)(npc.damage / 2), 1f, player.whoAmI, 0, 0);
				}
			}
		}
		
		public void BiphronSeeds(Player player, Vector2 Position)
		{
			Position.Y -= 100;
			Position.X += ((timer1 % 180) - 60) * 4;
			
			if(timer1 % 15 == 0)
			{
				Projectile.NewProjectile(Position, new Vector2(0, 10), mod.ProjectileType("WavyLeaf"), (int)(npc.damage / 2), 1f, player.whoAmI, 0, 0);
				seedcounter++;
			}
			if(seedcounter > 8)
			{
				biphronSeeds = false;
				seedcounter = 0;
			}
		}
		
		public void Leafnados(Player player)
		{
			Vector2 vel = player.Center - npc.Center;
			vel.Normalize();
			vel *= 10;
			Projectile.NewProjectile(npc.Center, Vector2.Zero, mod.ProjectileType("LeafnadoHoming"), (int)(npc.damage / 2), 1f, player.whoAmI, 1, 0);
			Projectile.NewProjectile(npc.Center, Vector2.Zero, mod.ProjectileType("LeafnadoHoming"), (int)(npc.damage / 2), 1f, player.whoAmI, 2, 0);
			Projectile.NewProjectile(npc.Center, vel, mod.ProjectileType("LeafnadoHoming"), (int)(npc.damage / 2), 1f, player.whoAmI, 3, 0);
		}
		
		public void Phase1Movement(Player player)
		{
			bool flag2 = false;

			if (npc.ai[2] >= 0)
			{
				int num1 = 16;
				bool flag3 = false;
				if (npc.position.X > npc.ai[0] - num1 && npc.position.X < npc.ai[0] + num1)
				{
					flag3 = true;
				}
				else if (npc.velocity.X < 0 && npc.direction > 0 || npc.velocity.X > 0 && npc.direction < 0)
				{
					flag3 = true;
				}

				int num2 = num1 + 24;
				bool flag4 = false;
				if (npc.position.Y > npc.ai[1] - num2 && npc.position.Y < npc.ai[1] + num2)
				{
					flag4 = true;
				}

				if (flag3 && flag4)
				{
					npc.ai[2] += 1f;

					if (npc.ai[2] >= 60)
					{
						npc.ai[2] = -200f;
						npc.direction = npc.direction * -1;
						npc.velocity.X *= -1f;
						npc.collideX = false;
					}
				}
				else
				{
					npc.ai[0] = npc.position.X;
					npc.ai[1] = npc.position.Y;
					npc.ai[2] = 0.0f;
				}
			}
			else
			{
				if (Main.player[npc.target].position.X + (double) (Main.player[npc.target].width / 2) > npc.position.X + (double) (npc.width / 2))
					npc.direction = -1;
				else
					npc.direction = 1;
			}

			int index1 = (int) npc.Center.X / 16 + npc.direction * 2;
			int num3 = (int) npc.Center.Y / 16; //y position at which to start looking for blocks below
			bool flag5 = true;
			bool flag6 = false;
			int num4 = 10; //roughly half ghent height in tiles

			for (int index2 = num3; index2 < num3 + num4; index2++)
			{
				if (Main.tile[index1, index2] == null)
				{
					Main.tile[index1, index2] = new Tile();
				}

				if (Main.tile[index1, index2].nactive() && Main.tileSolid[(int) Main.tile[index1, index2].type] || (int) Main.tile[index1, index2].liquid > 0)
				{
					if (index2 <= num3 + 1)
					{
						flag6 = true;
					}
					flag5 = false;
					break;
				}
			}

			float adjustedHeight = npc.position.Y + npc.height - 21; //compare player's center to a point at ghent's feet, elevated by (player height / 2)
			if (player.Center.Y < adjustedHeight) //makes ghent not always half in the ground when targeting a player on the same elevation
				npc.directionY = -1;
			else
				npc.directionY = 1;

			if (Main.player[npc.target].npcTypeNoAggro[npc.type])
			{
				bool flag3 = false;
				for (int index2 = num3; index2 < num3 + num4 - 2; index2++)
				{
					if (Main.tile[index1, index2] == null)
					{
						Main.tile[index1, index2] = new Tile();
					}

					if (Main.tile[index1, index2].nactive() && Main.tileSolid[(int) Main.tile[index1, index2].type] || (int) Main.tile[index1, index2].liquid > 0)
					{
						flag3 = true;
						break;
					}
				}
				npc.directionY = (!flag3).ToDirectionInt();
			}

			if (flag5)
			{
				npc.velocity.Y += 0.1f;

				if (npc.velocity.Y > 3)
				{
					npc.velocity.Y = 3;
				}
			}
			else
			{
				if (npc.directionY < 0 && npc.velocity.Y > 0)
				{
					npc.velocity.Y -= 0.1f;
				}

				if (npc.velocity.Y < -4)
				{
					npc.velocity.Y = -4;
				}
			}
			
			if (npc.collideX)
			{
				npc.velocity.X = npc.oldVelocity.X * -0.4f;

				if (npc.direction == -1 && npc.velocity.X > 0 && npc.velocity.X < 1)
				{
					npc.velocity.X = 1;
				}
				if (npc.direction == 1 && npc.velocity.X < 0 && npc.velocity.X > -1)
				{
					npc.velocity.X = -1;
				}
			}
			if (npc.collideY)
			{
				npc.velocity.Y = npc.oldVelocity.Y * -0.25f;

				if (npc.velocity.Y > 0 && npc.velocity.Y < 1)
				{
					npc.velocity.Y = 1;
				}
				if (npc.velocity.Y < 0 && npc.velocity.Y > -1)
				{
					npc.velocity.Y = -1;
				}
			}

			float num11 = 2f;
			
			if (npc.direction == -1 && npc.velocity.X > -num11)
			{
				npc.velocity.X -= 0.1f;

				if (npc.velocity.X > num11)
				{
					npc.velocity.X -= 0.1f;
				}
				else if (npc.velocity.X > 0)
				{
					npc.velocity.X += 0.05f;
				}

				if (npc.velocity.X < -num11)
				{
					npc.velocity.X = -num11;
				}
			}
			else if (npc.direction == 1 && npc.velocity.X < num11)
			{
				npc.velocity.X += 0.1f;

				if (npc.velocity.X < -num11)
				{
					npc.velocity.X += 0.1f;
				}
				else if (npc.velocity.X < 0)
				{
					npc.velocity.X -= 0.05f;
				}
				if (npc.velocity.X > num11)
				{
					npc.velocity.X = num11;
				}
			}

			float num12 = 1.5f;
			
			if (npc.directionY == -1 && npc.velocity.Y > -num12)
			{
				npc.velocity.Y -= 0.04f;

				if (npc.velocity.Y > num12)
				{
					npc.velocity.Y -= 0.05f;
				}
				else if (npc.velocity.Y > 0)
				{
					npc.velocity.Y += 0.03f;
				}

				if (npc.velocity.Y < -num12)
				{
					npc.velocity.Y = -num12;
				}
			}
			else if (npc.directionY == 1 && npc.velocity.Y < num12)
			{
				npc.velocity.Y += 0.04f;

				if (npc.velocity.Y < -num12)
				{
					npc.velocity.Y += 0.05f;
				}
				else if (npc.velocity.Y < 0.0)
				{
					npc.velocity.Y -= 0.03f;
				}

				if (npc.velocity.Y > num12)
				{
					npc.velocity.Y = num12;
				}
			}
		}
		
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (p3)
			{
				target.AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(3, 6));
			}
		}
		
		 public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			scale = 1.5f; // larger health bar
			return null;
        }
		
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.2f; 
			npc.frameCounter %= Main.npcFrameCount[npc.type]; 
			int frame = (int)npc.frameCounter; 
			npc.frame.Y = frame * frameHeight; 
		}

		public override void NPCLoot()
		{
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GhastlyEnt/GhastlyEntGore1"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GhastlyEnt/GhastlyEntGore2"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GhastlyEnt/GhastlyEntGore2"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GhastlyEnt/GhastlyEntGore3"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GhastlyEnt/GhastlyEntGore4"), 1f);
			
			TGEMWorld.TryForBossMask(npc.Center, npc.type);
			TGEMWorld.downedGhastlyEnt = true;

			if (Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("MegaTreeBag")));
			}
			else
			{
			    switch (Main.rand.Next(5))
			    {
				    case 0: 
					    player.QuickSpawnItem(mod.ItemType("Fist_of_the_Hallow_Ent"), 1);
					    break;
				    case 1: 
					    player.QuickSpawnItem(mod.ItemType("ForestBlast"), 1);
					    break;
				    case 2: 
					    player.QuickSpawnItem(mod.ItemType("GhastlyKnife"), 1);
					    break;
				    case 3: 
					    player.QuickSpawnItem(mod.ItemType("LeafScythe"), 1);
					    break;
				    case 4: 
					    player.QuickSpawnItem(mod.ItemType("LivingTreeSword"), 1);
					    break;
				    case 5: 
					    player.QuickSpawnItem(mod.ItemType("WoodChipper"), 1);
					    break;
				    case 6: 
					    player.QuickSpawnItem(mod.ItemType("TreeStaff"), 1);
					    break;
				    default:
					    break;
				    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("ForestEnergy"), Main.rand.Next(22, 35));
				    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("BlossomBranch"), Main.rand.Next(5, 10));
			    }
			}
		}
    }
 }
