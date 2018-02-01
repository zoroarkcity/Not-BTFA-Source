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
		int directionY;
		int p3Timer;
		int p3Timer2;
		bool p3;
		
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
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/ForestArmy");
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
			
					
			Microsoft.Xna.Framework.Color color29 = npc.GetAlpha(color25);
			if (p3)
			{
				Texture2D texture2D4 = mod.GetTexture("NPCs/GhastlyEnt/GhastlyEntP3");
				int num1561 = texture2D4.Height / Main.npcFrameCount[npc.type];
				int y31 = num1561 * (int)npc.frameCounter;
				Microsoft.Xna.Framework.Rectangle rectangle2 = new Microsoft.Xna.Framework.Rectangle(0, y31, texture2D4.Width, num1561);
				Vector2 origin3 = rectangle2.Size() / 2f;
				SpriteEffects effects = spriteEffects;
				if (npc.spriteDirection > 0)
				{
					effects = SpriteEffects.FlipHorizontally;
				}
				float num165 = npc.rotation;
				Microsoft.Xna.Framework.Color color39 = npc.GetAlpha(color25);
				Main.spriteBatch.Draw(texture2D4, npc.position + npc.Size / 2f - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle2), color39, num165 + npc.rotation * num160 * (float)(num161 - 1) * -(float)spriteEffects.HasFlag(SpriteEffects.FlipHorizontally).ToDirectionInt(), origin3, npc.scale, effects, 0f);
				return false;
			}
			return true;
		}

        public override void AI()
        {
			npc.TargetClosest(true);
			npc.spriteDirection = npc.direction;
            Player player = Main.player[npc.target];
			directionY = (npc.Center.Y <= player.Center.Y) ? 1 : -1;
			npc.ai[0]++;
			
			if (npc.alpha > 255)
				npc.alpha = 255;
			
			if (npc.life > (int)(npc.lifeMax/2) && !Main.expertMode || npc.life > (int)(npc.lifeMax * 0.66) && Main.expertMode)
			{
				Phase1(player);
			}
			else if (!Main.expertMode || npc.life > (int)(npc.lifeMax/3) && Main.expertMode)
			{
				Phase2(player);
			}
			else
			{
				Phase3(player);
				p3 = true;
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
		
		public void Phase1(Player player)
		{
			if (npc.ai[0] <= 180) //move towards player
			{
				npc.alpha = 0;
				if (npc.direction == -1 && (double) npc.velocity.X > -7)
				{
					npc.velocity.X -= 0.5f;
					if ((double) npc.velocity.X > 6.0)
					  npc.velocity.X -= 0.5f;
					else if ((double) npc.velocity.X > 0.0)
					  npc.velocity.X += 0.05f;
					if ((double) npc.velocity.X < -6.0)
					  npc.velocity.X = -4f;
				}
				else if (npc.direction == 1 && (double) npc.velocity.X < 7)
				{
					npc.velocity.X += 0.5f;
					if ((double) npc.velocity.X < -6.0)
						npc.velocity.X += 0.5f;
					else if ((double) npc.velocity.X < 0.0)
						npc.velocity.X -= 0.05f;
					if ((double) npc.velocity.X > 6.0)
						npc.velocity.X = 4f;
				}
				if (directionY == -1 && (double) npc.velocity.Y > -5)
				{
					npc.velocity.Y -= 0.25f;
					if ((double) npc.velocity.Y > 3)
					  npc.velocity.Y -= 0.25f;
					else if ((double) npc.velocity.Y > 0.0)
					  npc.velocity.Y += 0.025f;
					if ((double) npc.velocity.Y < -3)
					  npc.velocity.Y = -2f;
				}
				else if (directionY == 1 && (double) npc.velocity.Y < 5)
				{
					npc.velocity.Y += 0.25f;
					if ((double) npc.velocity.Y < -3)
					  npc.velocity.Y += 0.25f;
					else if ((double) npc.velocity.Y < 0.0)
					  npc.velocity.Y -= 0.025f;
					if ((double) npc.velocity.Y > 3)
					  npc.velocity.Y = 2f;
				}
			}
			else
			{
				npc.velocity = Vector2.Lerp(npc.velocity, Vector2.Zero, 0.03f); //slowly reduce velocity
				
				if (npc.ai[0] <= 360)
					npc.alpha += 5; //make it look more invisible over time so that teleports look better
			}
			if (npc.ai[0] > 180 && npc.ai[0] <= 384 && npc.ai[1] == 0)
			{ //DASH
				float num4 = 17f;
				Vector2 vector2 = new Vector2(npc.position.X + (float) npc.width * 0.5f, npc.position.Y + (float) npc.height * 0.5f);
				float num5 = Main.player[npc.target].position.X + (float) (Main.player[npc.target].width / 2) - vector2.X;
				float num6 = Main.player[npc.target].position.Y + (float) (Main.player[npc.target].height / 2) - vector2.Y;
				float num7 = (float) Math.Sqrt((double) num5 * (double) num5 + (double) num6 * (double) num6);
				float num8 = num4 / num7;
				npc.velocity.X = num5 * num8;
				npc.velocity.Y = num6 * num8;
				Main.PlaySound(SoundID.Item119, npc.position);
				
				npc.ai[1] = 1;
			}
			if (npc.alpha == 255 && npc.ai[1] == 1)
			{ //TELEPORT
				Vector2 vector = new Vector2(0, 550).RotatedBy(MathHelper.ToRadians(Main.rand.Next(360)));
				npc.Center = player.Center + vector;
				npc.ai[1] = 0;
				npc.alpha = 0;
				npc.netUpdate = true;
				
				Main.PlaySound(SoundID.Item8, npc.position);
			}
			
			if (npc.ai[0] > 384 && npc.ai[0] <= 420)
			{ //MAGIK
				npc.alpha = 0;
				npc.velocity = Vector2.Zero;
				
				if (npc.ai[0] == 420)
				{
					switch(Main.rand.Next(3))
					{
						case 0: DruidCircle(player, 0); //Druidic Circle
							break;
						case 1: Branches(player, 2); //Branches
							break;
						case 2: Portals();
							break;
					}
					npc.netUpdate = true;
				}
			}
			
			if (npc.ai[0] > 420)
			{
				npc.ai[0] = 0;
				npc.ai[1] = 0;
			}
		}
		
		public void Phase2(Player player)
		{
			if (npc.ai[2] == 0)
			{
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SapSlime"));
				npc.ai[0] = 0;
				npc.ai[1] = 0;
				npc.ai[2]++;
				Main.PlaySound(SoundID.NPCDeath10, npc.position);
			}
			
			if (npc.ai[0] <= 180) //move towards player
			{
				npc.alpha = 0;
				if (npc.direction == -1 && (double) npc.velocity.X > -7)
				{
					npc.velocity.X -= 0.5f;
					if ((double) npc.velocity.X > 6.0)
					  npc.velocity.X -= 0.5f;
					else if ((double) npc.velocity.X > 0.0)
					  npc.velocity.X += 0.05f;
					if ((double) npc.velocity.X < -6.0)
					  npc.velocity.X = -4f;
				}
				else if (npc.direction == 1 && (double) npc.velocity.X < 7)
				{
					npc.velocity.X += 0.5f;
					if ((double) npc.velocity.X < -6.0)
						npc.velocity.X += 0.5f;
					else if ((double) npc.velocity.X < 0.0)
						npc.velocity.X -= 0.05f;
					if ((double) npc.velocity.X > 6.0)
						npc.velocity.X = 4f;
				}
				if (directionY == -1 && (double) npc.velocity.Y > -6)
				{
					npc.velocity.Y -= 0.25f;
					if ((double) npc.velocity.Y > 3)
					  npc.velocity.Y -= 0.25f;
					else if ((double) npc.velocity.Y > 0.0)
					  npc.velocity.Y += 0.025f;
					if ((double) npc.velocity.Y < -3)
					  npc.velocity.Y = -2f;
				}
				else if (directionY == 1 && (double) npc.velocity.Y < 6)
				{
					npc.velocity.Y += 0.25f;
					if ((double) npc.velocity.Y < -3)
					  npc.velocity.Y += 0.25f;
					else if ((double) npc.velocity.Y < 0.0)
					  npc.velocity.Y -= 0.025f;
					if ((double) npc.velocity.Y > 3)
					  npc.velocity.Y = 2f;
				}
			}
			else
			{
				npc.velocity = Vector2.Lerp(npc.velocity, Vector2.Zero, 0.03f); //slowly reduce velocity
				
				if (npc.ai[0] <= 360)
					npc.alpha += 5; //make it look more invisible over time so that teleports look better
			}
			if (npc.ai[0] > 180 && npc.ai[0] <= 384 && npc.ai[1] == 0)
			{ //DASH
				float num4 = 19f;
				Vector2 vector2 = new Vector2(npc.position.X + (float) npc.width * 0.5f, npc.position.Y + (float) npc.height * 0.5f);
				float num5 = Main.player[npc.target].position.X + (float) (Main.player[npc.target].width / 2) - vector2.X;
				float num6 = Main.player[npc.target].position.Y + (float) (Main.player[npc.target].height / 2) - vector2.Y;
				float num7 = (float) Math.Sqrt((double) num5 * (double) num5 + (double) num6 * (double) num6);
				float num8 = num4 / num7;
				npc.velocity.X = num5 * num8;
				npc.velocity.Y = num6 * num8;
				
				npc.ai[1] = 1;
				Main.PlaySound(SoundID.Item119, npc.position);
			}
			if (npc.alpha == 255 && npc.ai[1] == 1)
			{ //TELEPORT
				Vector2 vector = new Vector2(0, 550).RotatedBy(MathHelper.ToRadians(Main.rand.Next(360)));
				npc.Center = player.Center + vector;
				npc.ai[1] = 0;
				npc.alpha = 0;
				npc.netUpdate = true;
				Main.PlaySound(SoundID.Item8, npc.position);
			}
			
			if (npc.ai[0] > 384 && npc.ai[0] <= 420)
			{ //MAGIK
				npc.alpha = 0;
				npc.velocity = Vector2.Zero;
				
				if (npc.ai[0] == 420)
				{
					switch(Main.rand.Next(3))
					{
						case 0: DruidCircle(player, 0); //Druidic Circle
							break;
						case 1: Branches(player, 3); //Branches
							break;
						case 2: Portals();
							break;
					}
					npc.netUpdate = true;
				}
			}
			
			if (npc.ai[0] > 420)
			{
				npc.ai[0] = 0;
				npc.ai[1] = 0;
			}
		}
		
		public void Phase3(Player player)
		{ //basic phase3 ai, will be improved later
			//planned phase 3 ai- dash at player constantly, cause cursed fire to rain from sky, create druidic circles occasionally
			//add in screenshader maybe
		
			if (npc.ai[3] == 0)
			{
				npc.ai[0] = 0;
				npc.ai[1] = 0;
				npc.alpha = 0;
				npc.ai[3]++;
				Main.PlaySound(SoundID.NPCDeath10, npc.position);
				
				npc.netUpdate = true;
			}
			
			if (Main.rand.Next(4) == 0)
			{
				int d = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 163, 0.0f, 0.0f, 100, new Color(), 1.5f);
				Main.dust[d].noGravity = true;
			}
			npc.damage = 135;
			
			p3Timer++;
			if(p3Timer % 60 == 0 && p3Timer % 460 < 360)
			{
				p3Timer2 = 0;
				float num4 = Main.rand.Next(20, 26);
				Vector2 vector2 = new Vector2(npc.position.X + (float) npc.width * 0.5f, npc.position.Y + (float) npc.height * 0.5f);
				float num5 = Main.player[npc.target].position.X + Main.player[npc.target].velocity.X + (float) (Main.player[npc.target].width / 2) - vector2.X;
				float num6 = Main.player[npc.target].position.Y + Main.player[npc.target].velocity.Y + (float) (Main.player[npc.target].height / 2) - vector2.Y;
				float num7 = (float) Math.Sqrt((double) num5 * (double) num5 + (double) num6 * (double) num6);
				float num8 = num4 / num7;
				npc.velocity.X = num5 * num8;
				npc.velocity.Y = num6 * num8;
				Main.PlaySound(SoundID.Item45, npc.position);
				npc.netUpdate = true;
			}
			else if (p3Timer % 460 < 360)
			{
				Vector2 Vel = Main.player[npc.target].Center - npc.Center;
				Vel.Normalize();
				Vel *= 6;
				npc.velocity = Vector2.Lerp(npc.velocity, Vel, 0.06f);
			}
			
			if(p3Timer % 50 == 0)
			{
				FireRain(Main.player[npc.target], Main.rand.Next(1,3));
			}
			
			if (p3Timer % 500 == 0)
			{
				DruidCircle(Main.player[npc.target], 0);
			}
			
			
			if(p3Timer % 460 >= 360)
			{
				npc.velocity = Vector2.Lerp(npc.velocity, Vector2.Zero, 0.1f);
				p3Timer2++;
				if (p3Timer2 >= 33)
				{
					Vector2 Vel = (Main.player[npc.target].Center - npc.Center);
					Vel.Normalize();
					Vel *= 15;
					Vel += Main.player[npc.target].velocity;
					Vector2 Pos = npc.Center;
					Projectile proj = Main.projectile[Projectile.NewProjectile(Pos, Vel, mod.ProjectileType("CursedFireGhent"), (int)(npc.damage/4), 1, Main.myPlayer, 0, 0)];
					proj.netUpdate = true;
					p3Timer2 = 0;
					
					Main.PlaySound(SoundID.Item101, npc.position);
				}
			}
		}
		
		public void FireRain(Player player, int num)
		{
			for(int i = 0; i < num; i++)
			{
				int variation = Main.rand.Next(-150, 151);
				Vector2 Pos = player.Center;
				Pos.Y -= 450;
				Pos.X += player.velocity.X + variation;
				Vector2 Vel = new Vector2(0, 10f).RotatedBy(MathHelper.ToRadians(Main.rand.Next(-30, 31)));
				Projectile proj = Main.projectile[Projectile.NewProjectile(Pos, Vel, mod.ProjectileType("CursedFireGhent"), (int)(npc.damage/4), 1, Main.myPlayer, 0, 0)];
				proj.netUpdate = true;
			}
		}
		
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (p3)
				target.AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(3, 6), false);
		}
		
		public void DruidCircle(Player player, int Dist)
		{
			Vector2 Pos = (new Vector2(0, Dist).RotatedBy(MathHelper.ToRadians(Main.rand.Next(360))) + npc.Center);
			Projectile.NewProjectile(Pos.X, Pos.Y, 0, 0, mod.ProjectileType("DruidicCircle"), 0, 0, Main.myPlayer, player.whoAmI, npc.whoAmI);
			Main.PlaySound(SoundID.Item117, npc.position);
		}
		
		 public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			scale = 1.5f; // larger health bar
			return null;
        }
		
		public void Branches(Player player, int num)
		{
			for(int index = 0; index < num; index++)
			{
				Vector2 Pos = new Vector2(0, 300).RotatedBy(MathHelper.ToRadians(Main.rand.Next(-30, 31))) + player.Center;
				
				Vector2 Vel = player.Center - Pos;
				Vel.Normalize();
				int p = Projectile.NewProjectile(Pos.X, Pos.Y, 0, 0, mod.ProjectileType("BranchBody"), (int)(npc.damage/2), 1, Main.myPlayer, 0, 0);
				
				Main.projectile[p].rotation = (float) Math.Atan2((double) Vel.Y, (double) Vel.X) + 1.57f;
				Main.projectile[p].netUpdate = true;
			}
			Main.PlaySound(SoundID.Item117, npc.position);
		}
		
		public void Portals()
		{
			for (int index = 0; index < 3; index++)
			{
				Vector2 Pos = new Vector2(0, -150).RotatedBy(MathHelper.ToRadians(-30 + (30 * index))) + npc.Center;
				int p = Projectile.NewProjectile(Pos.X, Pos.Y, 0, 0, mod.ProjectileType("ForestPortal"), (int)(npc.damage/2), 1, Main.myPlayer, Pos.X, Pos.Y);
				
				Main.projectile[p].netUpdate = true;
			}
			Main.PlaySound(SoundID.Item117, npc.position);
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
					int amountToDrop = Main.rand.Next(10,30);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ForestEnergy"), amountToDrop);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Wood, (amountToDrop * 3));
				}
			}
        }
    }
