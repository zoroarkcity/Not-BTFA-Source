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
		Int16 timer = 0;
		int timer2 = 2;
		int timer3 = 1;
		Int16 phase2timer = 0;
		int shootTimer = 0;
		int curlDirection = 1;
		int angleModifier = 0;
		//bool bisexual = false; //is phase 2
		bool takeLessDamage = false;
		Vector2 gayvector = new Vector2(0f, -7.5f);
		Vector2 frickvector = new Vector2(0f, 2f);
		
		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.lifeMax = 28000;
			npc.damage = 80;
			npc.defense = 14;
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
			bossBag = mod.ItemType("TitanRockBag");
			npc.scale = 1.25f;
			npc.npcSlots = 5;
			music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/Acheron");
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.Venom] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.OnFire] = true;
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
			npc.lifeMax = 42000 + ((numPlayers) * 4200);
			npc.damage = 100;
			npc.defense = 28;
		}

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(timer);
            writer.Write(phase2timer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            timer = reader.ReadInt16();
            phase2timer = reader.ReadInt16();
        }

        public void MakeBurstBall()
		{
            Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 75);

            if (Main.netMode != 1)
            {
                Vector2 velocity = Main.player[npc.target].Center - npc.Center;
                velocity /= 60f;
                int damage = npc.damage / 5;
                float ai1 = 0f;
                if (Main.expertMode)
                {
                    damage = npc.damage * 2 / 9; //91.5

                    if (npc.life < npc.lifeMax / 4)
                    {
                        ai1 = 0.01f * curlDirection;
                        curlDirection *= -1;
                    }
                }
                int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, mod.ProjectileType("Ball"), damage, 1, Main.myPlayer, 3f, ai1);
                Main.projectile[p].scale = 1.3f;
            }
		}

		public void MakeFloatyMeteors()
		{
            if (Main.netMode != 1)
            {
                int meteorsPerVolley = 5;
                int projDamage = npc.damage / 5;

                if (Main.expertMode)
                {
                    meteorsPerVolley += 2;
                    projDamage = npc.damage * 2 / 9; //91.5
                }

                for (int i = 0; i < meteorsPerVolley; i++)
                {
                    float variance = 0.5f + 1.25f * i / meteorsPerVolley;
                    double angle = Main.rand.Next(-45, 46) * Math.PI / 180;
                    Vector2 velocity = new Vector2(0, -5f * variance).RotatedBy(angle);
                    int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, mod.ProjectileType("BallMeteorFloaty"), projDamage, 1, Main.myPlayer);
                    Main.projectile[p].netUpdate = true;
                }
            }
		}

        public void Phase2Ring()
        {
            if (Main.netMode != 1)
            {
                int projDamage = Main.expertMode ? npc.damage * 2 / 9 : npc.damage / 5; //91.5, ???
                bool curlFlag = Main.expertMode && npc.life < npc.lifeMax / 4;

                for (int i = 0; i < 14; ++i)
                {
                    frickvector = frickvector.RotatedBy(System.Math.PI / 7);

                    if (curlFlag)
                    {
                        int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, frickvector.X, frickvector.Y, mod.ProjectileType("Ball"), projDamage, 1, Main.myPlayer, 4f, 0.012f * curlDirection);
                        Main.projectile[p].timeLeft += 120;
                    }
                    else
                    {
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, frickvector.X, frickvector.Y, mod.ProjectileType("Ball"), projDamage, 1, Main.myPlayer, 1f, 0);
                    }
                }

                curlDirection *= -1;
            }
        }
		
		public override void AI()
		{
			npc.TargetClosest(false);
			Player player = Main.player[npc.target];

            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                npc.velocity.Y = -20;
                timer = 0;
                if (npc.timeLeft > 10)
                    npc.timeLeft = 10;

                return;
            }

            if (npc.life <= npc.lifeMax / 2)
			{		
				phase2timer++;
				shootTimer++;
				if (phase2timer <= 355)
				{
					if (phase2timer == 1 || phase2timer == 75 || phase2timer == 145 || phase2timer == 215 || phase2timer == 285)
					{
						Vector2 direction = Main.player[npc.target].Center - npc.Center;
						direction.Normalize();
						npc.velocity.Y = direction.Y * 15f;
						npc.velocity.X = direction.X * 15f;
                        npc.buffImmune[BuffID.CursedInferno] = true;
                        npc.buffImmune[BuffID.ShadowFlame] = true;
                        npc.buffImmune[BuffID.Ichor] = true;
                    }
					else if (phase2timer == 355)
					{
						Vector2 direction = Main.player[npc.target].Center - npc.Center;
						direction.Normalize();
						npc.velocity.Y = direction.Y * 7f;
						npc.velocity.X = direction.X * 7f;
						
						if (Main.expertMode)
						{
							for (int i = 0; i < 4; i++) //spawn shit with velocity around boss
							{
                                double angle = (45 + 90 * i) * Math.PI / 180;
                                int n = NPC.NewNPC((int) npc.Center.X, (int) npc.Center.Y, mod.NPCType("SpikeTitan"), 0, -300 + 20 * i);
                                Main.npc[n].velocity = new Vector2(0, 9f).RotatedBy(angle);
                                Main.npc[n].ai[3] = 1f;
                                if (Main.netMode == 2) NetMessage.SendData(23, -1, -1, null, n, 0f, 0f, 0f, 0, 0, 0);
							}
						}
					}
					else if (phase2timer == 60 || phase2timer == 130 || phase2timer == 200 || phase2timer == 270 || phase2timer == 340)
					{
						Vector2 direction = Main.player[npc.target].Center - npc.Center;
						direction.Normalize();
						npc.velocity.Y = direction.Y * 1f;
						npc.velocity.X = direction.X * 1f;

                        Phase2Ring();
						
						Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 75);
					}
					npc.rotation += npc.velocity.X / 15f;
					shootTimer = -1;
					takeLessDamage = true;
                    npc.defense = 0;
				}
				else
				{
					takeLessDamage = false;
                    npc.defense = Main.expertMode ? 42 : 28;
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
					
					//timer % 180 == 0
					if (shootTimer == 0 || shootTimer == 180 || shootTimer == 360 || shootTimer == 540 || shootTimer == 720)
					{
						MakeFloatyMeteors();

						npc.buffImmune[BuffID.OnFire] = false;
						npc.buffImmune[BuffID.CursedInferno] = false;
						npc.buffImmune[BuffID.ShadowFlame] = false;
						npc.buffImmune[BuffID.Ichor] = false;
					}
					
					//timer % 200 == 0 and expert, or timer % 400 == 0
					bool showerTime = (shootTimer == 200 || shootTimer == 600);
					if ((showerTime && Main.expertMode) || shootTimer == 0 || shootTimer == 400 || shootTimer == 800)
					{
                        if (Main.netMode != 1)
                        {
                            int damage = Main.expertMode ? npc.damage * 2 / 9 : npc.damage / 5; //91.5, ???
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("TitanMarkShower"), damage, 1, Main.myPlayer, player.whoAmI);
                        }
					}

					bool burstBallTime = (shootTimer == 220 || shootTimer == 440 || shootTimer == 660 || shootTimer == 880);
					if (burstBallTime && (npc.life < npc.lifeMax / 4 || Main.expertMode))
					{
						MakeBurstBall();
					}
					
					if (phase2timer == 955)
					{
						phase2timer = 0;
                        npc.netUpdate = true;
					}
				}
			}
			else
			{
				timer++;
				if (timer < 350)
				{
					npc.ai[2] += 1f;
					if (npc.ai[2] >= 800f)
					{
						npc.ai[2] = 0f;
						npc.ai[1] = 1f;
						npc.TargetClosest(false);
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
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 75);

                        if (Main.netMode != 1)
                        {
                            int projDamage = npc.damage / 5; //82.35 in expert
                            /*if (Main.expertMode)
                                projDamage = npc.damage * 3 / 16; //77.21*/

                            for (int i = 0; i < 6; ++i)
                            {
                                Vector2 direction = Main.player[npc.target].Center - npc.Center;
                                direction.Normalize();
                                float sX = direction.X * 8f;
                                float sY = direction.Y * 8f;
                                sX += (float)Main.rand.Next(-15, 16) * 0.1f;
                                sY += (float)Main.rand.Next(-15, 16) * 0.1f;
                                int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, sX, sY, mod.ProjectileType("Ball2"), projDamage, 1, Main.myPlayer, 0, 0);
                                Main.projectile[p].netUpdate = true;
                            }
                        }
					}

					if (timer == 50 || timer == 150 || timer == 250)
					{	
						if (npc.life <= npc.lifeMax * 6 / 7 && Main.expertMode)
						{
                            Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 75);

                            if (Main.netMode != 1)
                            {
                                int projDamage = npc.damage / 5; //82.35 in expert
                                /*if (Main.expertMode)
                                    projDamage = npc.damage * 3 / 16; //77.21*/

                                for (int i = 0; i < 3; ++i)
                                {
                                    Vector2 direction = Main.player[npc.target].Center - npc.Center;
                                    direction.Normalize();
                                    float sX = direction.X * 8f;
                                    float sY = direction.Y * 8f;
                                    sX += (float)Main.rand.Next(-15, 16) * 0.1f;
                                    sY += (float)Main.rand.Next(-15, 16) * 0.1f;
                                    int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, sX, sY, mod.ProjectileType("Ball2"), projDamage, 1, Main.myPlayer, 0, 0);
                                    Main.projectile[p].netUpdate = true;
                                }
                            }
						}
					}
				}
				else if (timer == 350) //initializing phase 1 spin
				{
					angleModifier = 0;

					gayvector = npc.Center - player.Center; //points from player to npc (i.e. behind boss)
					gayvector.Normalize();

                    takeLessDamage = true;
                    npc.defense = 0;
					
					if (Main.expertMode)
					{
						curlDirection *= -1;

                        if (Main.netMode != 1)
                        {
                            for (int i = 0; i < 4; i++) //spawn shit with velocity behind boss
                            {
                                double angle = (-60 + 40 * i) * Math.PI / 180; //angle range is -60, -20, +20, +60
                                int n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SpikeTitan"), 0, -300 - 20 * i);
                                Main.npc[n].velocity = gayvector.RotatedBy(angle);
                                Main.npc[n].velocity *= 14f;
                                if (Main.netMode == 2) NetMessage.SendData(23, -1, -1, null, n, 0f, 0f, 0f, 0, 0, 0);
                            }
                        }
					}

					gayvector = gayvector.RotatedBy(0.785398163); //always starts spin bullets at 45 degree angle to player
					gayvector *= 7.5f;

                    npc.netUpdate = true;
				}
				else if (timer > 350)
				{
					timer2++;
					
					npc.rotation += 0.20f * curlDirection;
					npc.velocity.X = 0f;
					npc.velocity.Y = 0f;
					
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60);
					
					if (timer2 >= 5)
					{
						double swirlyIncrement = System.Math.PI;

						if (Main.expertMode)
						    swirlyIncrement /= 32;
						else
						    swirlyIncrement /= 36;

						swirlyIncrement *= curlDirection;
						
						if (angleModifier < 18) //rotate at half speed for first 18 shots (1.5 seconds)
						    gayvector = gayvector.RotatedBy(swirlyIncrement / 2);
						else
						    gayvector = gayvector.RotatedBy(swirlyIncrement);

						angleModifier++;

                        if (Main.netMode != 1)
                        {
                            int projDamage = npc.damage / 5; //82.35 in expert
                            /*if (Main.expertMode)
                                projDamage = npc.damage * 3 / 16; //77.21*/

                            Projectile.NewProjectile(npc.Center, gayvector, mod.ProjectileType("Ball"), projDamage, 1, Main.myPlayer, 2f, 0);
                            Projectile.NewProjectile(npc.Center, -gayvector, mod.ProjectileType("Ball"), projDamage, 1, Main.myPlayer, 2f, 0);

                            Vector2 lesvector = gayvector.RotatedBy(System.Math.PI / 2);
                            Projectile.NewProjectile(npc.Center, lesvector, mod.ProjectileType("Ball"), projDamage, 1, Main.myPlayer, 2f, 0);
                            Projectile.NewProjectile(npc.Center, -lesvector, mod.ProjectileType("Ball"), projDamage, 1, Main.myPlayer, 2f, 0);
                        }

						Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 75);
						timer2 = 0;
					}
				}
				
				if (timer3 == 600 || timer3 == 1200)
				{
                    if (Main.netMode != 1)
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("TitanMarkShower"), npc.damage / 5, 1, Main.myPlayer, player.whoAmI);
					/*if (Main.expertMode)
					{
						Main.projectile[p].damage = npc.damage * 3 / 16; //77.21
					}*/
				}
				
				if (timer >= 650)
				{
					takeLessDamage = false;
                    npc.defense = Main.expertMode ? 28 : 14;
					timer = 0;
                    npc.netUpdate = true;
				}
			}

			if (timer3 == 1200)
			{
				timer3 = 0;
			}
				
			timer3++;
		}

		public override bool StrikeNPC (ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
		{
			if (takeLessDamage)
			{
				damage *= 0.4;
			}
			else
			{
				damage *= 0.9;
			}

			return true;
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
		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.GreaterHealingPotion; //Applies to Bosses regardless of world difficulty- pre hm is always lesser, hm is always greater   
		}		
		public override void NPCLoot()
		{
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && Main.npc[i].type == mod.NPCType("SpikeTitan"))
				{
					Main.npc[i].life = 0;
					Main.npc[i].checkDead();
					Main.npc[i].netUpdate = true;
				}
			}
			
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TitanRock/TitanGore1"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TitanRock/TitanGore2"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TitanRock/TitanGore3"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TitanRock/TitanGore4"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TitanRock/TitanGore5"), 1f);
			if (Main.expertMode)
			{
                npc.DropBossBags();
			}
			else
			{
				int amountToDrop = Main.rand.Next(12,16);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpaceRockFragment"), amountToDrop);
				TGEMWorld.TryForBossMask(npc.Center, npc.type);
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
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BeamSlicer"), Main.rand.Next(210, 241));
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
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 771, Main.rand.Next(110, 141));
					break;
				}
			}
			TGEMWorld.downedTitanRock = true;			
		}
	}
}
