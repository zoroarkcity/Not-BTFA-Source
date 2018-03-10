using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.TitanRock
{
	[AutoloadBossHead]
	public class TitanRock : ModNPC
	{
		int timer = 0;
		int timer2 = 2;
		int timer3 = 1;
		int phase2timer = 0;
		int shootTimer = 0;
		bool bisexual = false;
		bool bisexual2 = false;
		float teleportF;
		bool despawn = false;
		Vector2 gayvector = new Vector2(0f, -5f);
		Vector2 homovector = new Vector2(0f, 5f);
		Vector2 frickvector = new Vector2(0f, 2f);
		
		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.lifeMax = 32500;
			npc.damage = 100;
			npc.defense = 15;
			npc.knockBackResist = 0f;
			npc.width = 170;
			npc.height = 170;
			npc.value = Item.buyPrice(0, 12, 0, 0);
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noTileCollide = true;
			npc.noGravity = true;
			npc.HitSound = SoundID.NPCHit41;
			npc.DeathSound = SoundID.NPCDeath44;
			npc.scale = 1.25f;
			npc.npcSlots = 5;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/TitanRock");
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titan Rock");
			Main.npcFrameCount[npc.type] = 6;
		}
		
		public override void BossHeadRotation (ref float rotation)
		{
			rotation = npc.rotation;
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = 37500 + ((numPlayers) * 4000);
			npc.damage = 120;
			npc.defense = 20;
		}

		public void MakeFloatyMeteors()
		{
			int meteorsPerVolley = 4;

            if (Main.expertMode)
                meteorsPerVolley += 3;
            
            for (int i = 0; i < meteorsPerVolley; i++)
            {
                float variance = (1f + (float)Main.rand.Next(-25, 126) / 100f);
                double angle = Main.rand.Next(-45, 46) * Math.PI / 180;
                Vector2 velocity = new Vector2(0, -5f * variance).RotatedBy(angle);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, mod.ProjectileType("BallMeteorFloaty"), (int) npc.damage / 4, 1, Main.myPlayer);
            }
		}

        public void Phase2Ring()
        {
            for (int i = 0; i < 10; ++i)
            {
                frickvector = frickvector.RotatedBy(System.Math.PI / 5);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, frickvector.X, frickvector.Y, mod.ProjectileType("Ball"), (int)npc.damage / 4, 1f, Main.myPlayer, 1, 0);
            }
        }
		
		public override void AI()
		{
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			
			if (npc.life <= (int)(npc.lifeMax/2) && despawn == false)
			{		
				phase2timer++;
				if (phase2timer <= 355)
				{
					if (phase2timer == 1 || phase2timer == 75 || phase2timer == 145 || phase2timer == 215 || phase2timer == 285 || phase2timer == 355)
					{
						Vector2 direction = Main.player[npc.target].Center - npc.Center;
						direction.Normalize();
						npc.velocity.Y = direction.Y * 15f;
						npc.velocity.X = direction.X * 15f;
					}
					
					if (phase2timer == 60 || phase2timer == 130 || phase2timer == 200 || phase2timer == 270 || phase2timer == 340)
					{
						Vector2 direction = Main.player[npc.target].Center - npc.Center;
						direction.Normalize();
						npc.velocity.Y = direction.Y * 1f;
						npc.velocity.X = direction.X * 1f;

                        Phase2Ring();
						
						Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 75);
					}
					npc.rotation += npc.velocity.X / 15f;
					timer3 = -1;
				}
				else
				{
					npc.rotation = npc.velocity.X / 15f;
					float num586 = 0.03f;
					float num587 = 4f;
					float num588 = 0.07f;
					float num589 = 9.5f;
					if (Main.expertMode)
					{
						num586 = 0.04f;
						num587 = 15f;
						num588 = 0.09f;
						num589 = 15f;
					}
					if (npc.position.Y > Main.player[npc.target].position.Y - 250f)
					{
						if (npc.velocity.Y > 0f)
						{
							npc.velocity.Y = npc.velocity.Y * 0.96f;
						}
						npc.velocity.Y = npc.velocity.Y - num586;
						if (npc.velocity.Y > num587)
						{
							npc.velocity.Y = num587;
						}
					}
					else if (npc.position.Y < Main.player[npc.target].position.Y - 250f)
					{
						if (npc.velocity.Y < 0f)
						{
							npc.velocity.Y = npc.velocity.Y * 0.96f;
						}
						npc.velocity.Y = npc.velocity.Y + num586;
						if (npc.velocity.Y < -num587)
						{
							npc.velocity.Y = -num587;
						}
					}
					if (npc.position.X + (float)(npc.width / 2) > Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2))
					{
						if (npc.velocity.X > 0f)
						{
							npc.velocity.X = npc.velocity.X * 0.96f;
						}
						npc.velocity.X = npc.velocity.X - num588;
						if (npc.velocity.X > num589)
						{
							npc.velocity.X = num589;
						}
					}
					if (npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2))
					{
						if (npc.velocity.X < 0f)
						{
							npc.velocity.X = npc.velocity.X * 0.96f;
						}
						npc.velocity.X = npc.velocity.X + num588;
						if (npc.velocity.X < -num589)
						{
							npc.velocity.X = -num589;
						}
					}
					
					if (timer3 % 120 == 0)
					{
						MakeFloatyMeteors();
					}
					
					if ((timer3 % 200 == 0 && Main.expertMode) || (shootTimer % 400 == 0 && !Main.expertMode))
					{
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("TitanMarkShower"), (int) npc.damage / 5, 1, Main.myPlayer, player.whoAmI);
					}
					
					//if (phase2timer == 895 || phase2timer == 835) Phase2Ring(); else 
                    if (phase2timer == 955)
					{
						phase2timer = 0;
					}
				}
			}
			
			else
			{
				timer++;
				if (timer <= 350)
				{
					npc.ai[2] += 1f;
					if (npc.ai[2] >= 800f)
					{
						npc.ai[2] = 0f;
						npc.ai[1] = 1f;
						npc.TargetClosest(true);
						npc.netUpdate = true;
					}
					npc.rotation = npc.velocity.X / 15f;
					float num586 = 0.02f;
					float num587 = 2f;
					float num588 = 0.05f;
					float num589 = 8f;
					if (Main.expertMode)
					{
						num586 = 0.03f;
						num587 = 4f;
						num588 = 0.07f;
						num589 = 9.5f;
					}
					if (npc.position.Y > Main.player[npc.target].position.Y - 250f)
					{
						if (npc.velocity.Y > 0f)
						{
							npc.velocity.Y = npc.velocity.Y * 0.98f;
						}
						npc.velocity.Y = npc.velocity.Y - num586;
						if (npc.velocity.Y > num587)
						{
							npc.velocity.Y = num587;
						}
					}
					else if (npc.position.Y < Main.player[npc.target].position.Y - 250f)
					{
						if (npc.velocity.Y < 0f)
						{
							npc.velocity.Y = npc.velocity.Y * 0.98f;
						}
						npc.velocity.Y = npc.velocity.Y + num586;
						if (npc.velocity.Y < -num587)
						{
							npc.velocity.Y = -num587;
						}
					}
					if (npc.position.X + (float)(npc.width / 2) > Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2))
					{
						if (npc.velocity.X > 0f)
						{
							npc.velocity.X = npc.velocity.X * 0.98f;
						}
						npc.velocity.X = npc.velocity.X - num588;
						if (npc.velocity.X > num589)
						{
							npc.velocity.X = num589;
						}
					}
					if (npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2))
					{
						if (npc.velocity.X < 0f)
						{
							npc.velocity.X = npc.velocity.X * 0.98f;
						}
						npc.velocity.X = npc.velocity.X + num588;
						if (npc.velocity.X < -num589)
						{
							npc.velocity.X = -num589;
						}
					}
					
					if (timer == 100 || timer == 200)
					{	
						for (int i = 0; i < 6; ++i)
						{
							Vector2 direction = Main.player[npc.target].Center - npc.Center;
							direction.Normalize();
							float sX = direction.X * 8f;
							float sY = direction.Y * 8f;
							sX += (float)Main.rand.Next(-15, 15) * 0.1f;
							sY += (float)Main.rand.Next(-15, 15) * 0.1f;
							int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, sX, sY, mod.ProjectileType("Ball2"), (int) npc.damage / 5, 1, Main.myPlayer, 0, 0);
							Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 75);
							Main.projectile[p].netUpdate = true;
						}
					}
					if (timer == 50 || timer == 150 || timer == 250)
					{	
						if (npc.life <= npc.lifeMax * 6 / 7 && Main.expertMode)
						{
							for (int i = 0; i < 3; ++i)
							{
								Vector2 direction = Main.player[npc.target].Center - npc.Center;
								direction.Normalize();
								float sX = direction.X * 8f;
								float sY = direction.Y * 8f;
								sX += (float)Main.rand.Next(-15, 15) * 0.1f;
								sY += (float)Main.rand.Next(-15, 15) * 0.1f;
								int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, sX, sY, mod.ProjectileType("Ball2"), (int) npc.damage / 4, 1, Main.myPlayer, 0, 0);
								Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 75);
								Main.projectile[p].netUpdate = true;
							}
						}
					}
				}
				
				
				if (timer >= 350)
				{
					timer2++;
					
					npc.rotation += 0.20f;
					npc.velocity.X = 0f;
					npc.velocity.Y = 0f;
					
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60);
					
					if (timer2 >= 5)
					{
						double swirlyIncrement = System.Math.PI / 36;

						if (npc.life <= npc.lifeMax * 6 / 7 && Main.expertMode)
						{
							swirlyIncrement = System.Math.PI / 31;
						}

						gayvector = gayvector.RotatedBy(swirlyIncrement);
						homovector = homovector.RotatedBy(swirlyIncrement);
					
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, gayvector.X * 1.5f, gayvector.Y * 1.5f, mod.ProjectileType("Ball"), (int) npc.damage / 6, 1, Main.myPlayer, 2f, 0);
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, homovector.X * 1.5f, homovector.Y * 1.5f, mod.ProjectileType("Ball"), (int) npc.damage / 6, 1, Main.myPlayer, 2f, 0);
						Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 75);
						timer2 = 0;
					}
				}
				
				if (Main.rand.Next(500) == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("TitanBat"));
				}
				
				if (timer3 % 600 == 0)
				{
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("TitanMarkShower"), (int) npc.damage / 5, 1, Main.myPlayer, player.whoAmI);
				}
				
				if (timer >= 650)
				{
					timer = 0;
				}
			}

			if (Main.expertMode)
			{
				if (timer3 == 1200)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SpikeTitan"));
					timer3 = 0;
				}
				
				timer3++;
			}
			
			if (!player.active || player.dead)
			{
				npc.TargetClosest(false);
				npc.velocity.Y = -20;
				timer = 0;
				despawn = true;
				if (npc.timeLeft > 10)
				{
					npc.timeLeft = 10;
				}
			}
		}

		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.1f; 
			if (npc.life <= 1000 && Main.expertMode)
			{
				npc.frameCounter += 0.1f;
			}
			npc.frameCounter %= Main.npcFrameCount[npc.type]; 
			int frame = (int)npc.frameCounter; 
			npc.frame.Y = frame * frameHeight; 
		}
		
		public override void NPCLoot()
		{
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TitanRock/TitanGore1"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TitanRock/TitanGore2"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TitanRock/TitanGore3"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TitanRock/TitanGore4"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TitanRock/TitanGore5"), 1f);
			
			TGEMWorld.TryForBossMask(npc.Center, npc.type);
			if (Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("TitanRockBag")));
			}
			else
			{
				int amountToDrop = Main.rand.Next(12,16);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpaceRockFragment"), amountToDrop);
				
				switch (Main.rand.Next (8))
				{
				case 0:
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LaserbladeKatana"), 1);
					break;
				case 1:
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NeedleBow"), 1);
					break;
				case 2:
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LaserbeamStaff"), 1);
					break;
				case 3:
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BeamSlicer"), Main.rand.Next(210, 240));
					break;
				case 4:
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnergizedBlaster"), 1);
					break;
				case 5:
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TitanSpin"), 1);
					break;
				case 6:
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TitanicCrusher"), 1);
					break;
				case 7:
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AncientLauncher"), 1);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 771, Main.rand.Next(110, 140));
					break;
				}
			}
			if (!TGEMWorld.downedTitanRock)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CosmiCrystal"), 1);
			}
			if (TGEMWorld.downedTitanRock && Main.rand.Next(10) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CosmiCrystal"), 1);
			}
			TGEMWorld.downedTitanRock = true;			
		}
	}
}
