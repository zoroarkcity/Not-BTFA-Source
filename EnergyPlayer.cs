using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories
{
	public class EnergyPlayer : ModPlayer
	{
		int damageTaken = 0;
		public bool treeMinion = true;
        public bool lifesteal = false;
		public int lifestealCap = 0;
		public int lifestealTimer = 0;
		public bool firestorm = false;
		public bool doubleJumpMeteor = false;
		public bool meteor = false;
		public bool hadron = false;
		public bool pearl = false;
		public bool pearl2 = false;
		public bool BoCBuff = false;
		public bool dJumpEffectMeteor = false;
		public bool sapBall = false;
		public bool canJumpFirestorm = true;
		public bool SlimyNeck = false;
		public bool jungard = true;
		public bool frostguard = false;
		public bool BeeHive = false;
		public bool ManaShard = false;
		public bool DivineBlessing = false;
		public int firestormCooldown = 0;
		
		public override void ResetEffects()
		{
			firestorm = false;
			doubleJumpMeteor = false;
			hadron = false;
			ManaShard = false;
			pearl = false;
			pearl2 = false;
			BoCBuff = false;
			treeMinion = false;
            lifesteal = false;
			sapBall = false;
			SlimyNeck = false;
			jungard = false;
			frostguard = false;
			BeeHive = false;
			DivineBlessing = false;
		}

            public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
            {
                if (Main.rand.Next(4) == 0 && lifesteal == true && !target.immortal && target.lifeMax >= 20 && lifestealCap <= 4 && damage >= 15)
                {
					int quickthing = Main.rand.Next(2) + 1;
                    player.HealEffect(quickthing);
                    player.statLife += (quickthing);
					lifestealCap++;
                }
				
				if (Main.rand.Next(6) == 0 && DivineBlessing == true)
                {
					Vector2 newVect1 = new Vector2 (12, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(360)));
					int proj = Projectile.NewProjectile(target.Center.X, target.Center.Y, newVect1.X, newVect1.Y, mod.ProjectileType("LightningChain"), damage, 2f, player.whoAmI);
					Main.projectile[proj].ranged = false;
                }
            }
			
			
			public override void OnHitNPCWithProj(Projectile projectile, NPC target, int damage, float knockback, bool crit)
			{
				
				if (Main.rand.Next(4) == 0 && lifesteal == true && !target.immortal && target.lifeMax >= 20 && lifestealCap <= 4 && damage >= 15)
                {
					int quickthing = Main.rand.Next(2) + 1;
                    player.HealEffect(quickthing);
                    player.statLife += (quickthing);
					lifestealCap++;
                }
				
				if (Main.rand.Next(6) == 0 && DivineBlessing == true)
                {
					int proj = Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("LightningChain"), damage / 2, 2f, player.whoAmI);
					Main.projectile[proj].ranged = false;
                }
				
				if (sapBall == true && Main.rand.Next(3) == 0)
				{
					if (projectile.minion == true || ProjectileID.Sets.MinionShot[projectile.type] || ProjectileID.Sets.SentryShot[projectile.type])
					{
						Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("SapSphere"), projectile.damage, 5f, player.whoAmI);
					}
				}
				
				if (BoCBuff == true)
				{	
					if (target.FindBuffIndex(31) >= 0 && projectile.type != mod.ProjectileType("BoCBolt"))
					{
						Player player = Main.player[projectile.owner];
						Vector2 newMove = projectile.Center - player.Center;
						newMove.Normalize();
						float ok = newMove.X * 3f;
						float ok2 = newMove.Y * 3f;
						Projectile.NewProjectile(player.Center.X, player.Center.Y, ok, ok2, mod.ProjectileType("BoCBolt"), (int)(projectile.damage/3), 0f, projectile.owner, 0f, 0f);
					}
					
					if (Main.rand.Next(5) == 0)
					{
						target.AddBuff(31, 540, false);
					}
				}
				
				if (SlimyNeck == true && Main.rand.Next(7) == 0)
				{
					if (projectile.minion == true || ProjectileID.Sets.MinionShot[projectile.type] || ProjectileID.Sets.SentryShot[projectile.type])
					{
						target.AddBuff(mod.BuffType("Gelled"), 60, false);
					}
				}
			}
			
			public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason 	damageSource)		
			{
				damageTaken = damage;
				return true;
			}
			
			public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
			{
				if (jungard == true && Main.rand.Next(3) == 0)
				{
					Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("JungleGuard"), (int)(15 * (player.minionDamage * player.minionDamage * player.minionDamage)), 5f, player.whoAmI);
				}
				
				if (frostguard == true && Main.rand.Next(3) == 0)
				{
					Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("IceSlimeMinion"), (int)(12 * (player.minionDamage * player.minionDamage * player.minionDamage)), 5f, player.whoAmI);
				}
				
				if (BeeHive == true)
				{
					player.AddBuff(48, 60 * Main.rand.Next(3, 11));
					int num = 3;
					if (Main.rand.Next(3) == 0)
						++num;
					if (Main.rand.Next(3) == 0)
						++num;
					if (Main.rand.Next(3) == 0)
						++num;
					for (int index = 0; index < num; ++index)
						Projectile.NewProjectile((float) player.position.X, (float) player.position.Y, (float) Main.rand.Next(-35, 36) * 0.02f, (float) Main.rand.Next(-35, 36) * 0.02f, this.beeType2(), player.beeDamage(80), player.beeKB(0.0f), Main.myPlayer, 0.0f, 0.0f);
				}
				
				if (pearl == true && Main.rand.Next(2) == 0 && damageTaken >= 10)
				{
					//Vector2 ok = player.Center;
					//ok.X += Main.rand.Next(-60, 61);
					//ok.Y += Main.rand.Next(-60, 61);
					//Item.NewItem((int)ok.X, (int)ok.Y, player.width, player.height, mod.ItemType("BlueHeart"));
					player.statLife += 10;
					player.HealEffect(10);
				}
				
				if (pearl == true && player.statLife <= player.statLifeMax2/2)
				{
					player.statLife += damageTaken/10;
					player.HealEffect(damageTaken/10);
				}
				
				if (pearl2 == true && Main.rand.Next(2) == 0 && damageTaken >= 15)
				{
					player.statLife += 15;
					player.HealEffect(15);
				}
				
				if (pearl2 == true && player.statLife <= player.statLifeMax2/2)
				{
					player.statLife += damageTaken/7;
					player.HealEffect(damageTaken/7);
				}
			}
			
			public override void PreUpdate()
			{
				
				lifestealTimer++;
				if (lifestealTimer >= 60)
				{
					lifestealCap = 0;
					lifestealTimer = 0;
				}
				
				if(firestorm == true)
				{
					firestormCooldown++;
				}
				if(player.controlJump)
				{
					if(!player.mount.Active && canJumpFirestorm == true && firestorm == true)
					{
						if(player.controlLeft)
						{
							player.velocity.X = -10f;
						}
						if(player.controlRight)
						{
							player.velocity.X = 10f;
						}
						Main.PlaySound(2, (int)player.Center.X, (int)player.Center.Y, 34);
						int projectile = Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("FireGrenadeBoom"), 15, 5f, player.whoAmI);
						Main.projectile[projectile].thrown = false;
						Main.projectile[projectile].timeLeft = 2;				
						canJumpFirestorm = false;
						firestormCooldown = 0;
					}

					bool flag = false;
					if (flag = false && meteor == true)
					{
						flag = true;
						meteor = false;
					}

					if (player.velocity.Y == 0f || player.sliding || (player.autoJump && player.justJumped))
					{
						if (doubleJumpMeteor == true)
						{
							meteor = true; //refreshes the meteor jump
						}	
					}						

					else if (flag == true) 
					{
						dJumpEffectMeteor = true;
						player.jump = (int)(Player.jumpHeight * 1.5f);
						Main.PlaySound(2, (int)player.Center.X, (int)player.Center.Y, 34);
					}
				}
					
				if (player.justJumped == true && firestormCooldown >= 10)
				{
					canJumpFirestorm = true;
				}	
			}
			
			public void DoubleJumpVisuals()
			{
				if (dJumpEffectMeteor == true && doubleJumpMeteor == true && meteor == false && !player.jumpAgainCloud && (!player.jumpAgainSandstorm || !player.doubleJumpSandstorm) && ((player.gravDir == 1f && player.velocity.Y < 0f) || (player.gravDir == -1f && player.velocity.Y > 0f)))
				{
					int kys = Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 3, 424, 15, 5f, player.whoAmI);
					Main.projectile[kys].magic = false; //creates meteors
				}
			}
			
			public void ShinyOrbSpawn()
			{
				int damage = 45; //set damage
				float knockBack = 1.5f; //set kB
				if (Main.rand.Next(15) == 0)
				{
					int num = 0;
					for (int i = 0; i < 1000; i++) //search for amount of projctiles
					{
						if (Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI && (Main.projectile[i].type == mod.ProjectileType("ShinyEnergy")))
						{
							num++;
						}
					}
					if (Main.rand.Next(10) >= num && num < 10)
					{
						int num2 = 50;
						int num3 = 24;
						int num4 = 90;
						for (int j = 0; j < num2; j++)
						{
							int num5 = Main.rand.Next(200 - j * 2, 400 + j * 2);
							Vector2 center = player.Center;
							center.X += (float)Main.rand.Next(-num5, num5 + 1);
							center.Y += (float)Main.rand.Next(-num5, num5 + 1);
							if (!Collision.SolidCollision(center, num3, num3) && !Collision.WetCollision(center, num3, num3))
							{
								center.X += (float)(num3 / 2);
								center.Y += (float)(num3 / 2);
								if (Collision.CanHit(new Vector2(player.Center.X, player.position.Y), 1, 1, center, 1, 1) || Collision.CanHit(new Vector2(player.Center.X, player.position.Y - 50f), 1, 1, center, 1, 1))
								{
									int num6 = (int)center.X / 16;
									int num7 = (int)center.Y / 16;
									bool flag = false;
									if (Main.rand.Next(3) == 0 && Main.tile[num6, num7] != null && Main.tile[num6, num7].wall > 0)
									{
										flag = true;
									}
									else
									{
										center.X -= (float)(num4 / 2);
										center.Y -= (float)(num4 / 2);
										if (Collision.SolidCollision(center, num4, num4))
										{
											center.X += (float)(num4 / 2);
											center.Y += (float)(num4 / 2);
											flag = true;
										}
									}
									if (flag)
									{
										for (int k = 0; k < 1000; k++)
										{
											if (Main.projectile[k].active && Main.projectile[k].owner == player.whoAmI && Main.projectile[k].type == mod.ProjectileType("ShinyEnergy") && (center - Main.projectile[k].Center).Length() < 48f)
											{
												flag = false;
												break;
											}
										}
										if (flag && Main.myPlayer == player.whoAmI)
										{
											Projectile.NewProjectile(center.X, center.Y, 0f, 0f, mod.ProjectileType("ShinyEnergy"), damage, knockBack, player.whoAmI, 0f, 0f);
											return;
										}
									}
								}
							}
						}
					}
				}
			}
			
			public void EmeraldSpawn()
			{
				int damage = 135; //set damage
				float knockBack = 2f; //set kB
				if (Main.rand.Next(15) == 0)
				{
					int num = 0;
					for (int i = 0; i < 1000; i++) //search for amount of projctiles
					{
						if (Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI && (Main.projectile[i].type == mod.ProjectileType("EmeraldEnergy")))
						{
							num++;
						}
					}
					if (Main.rand.Next(10) >= num && num < 10)
					{
						int num2 = 50;
						int num3 = 24;
						int num4 = 90;
						for (int j = 0; j < num2; j++)
						{
							int num5 = Main.rand.Next(200 - j * 2, 400 + j * 2);
							Vector2 center = player.Center;
							center.X += (float)Main.rand.Next(-num5, num5 + 1);
							center.Y += (float)Main.rand.Next(-num5, num5 + 1);
							if (!Collision.SolidCollision(center, num3, num3) && !Collision.WetCollision(center, num3, num3))
							{
								center.X += (float)(num3 / 2);
								center.Y += (float)(num3 / 2);
								if (Collision.CanHit(new Vector2(player.Center.X, player.position.Y), 1, 1, center, 1, 1) || Collision.CanHit(new Vector2(player.Center.X, player.position.Y - 50f), 1, 1, center, 1, 1))
								{
									int num6 = (int)center.X / 16;
									int num7 = (int)center.Y / 16;
									bool flag = false;
									if (Main.rand.Next(3) == 0 && Main.tile[num6, num7] != null && Main.tile[num6, num7].wall > 0)
									{
										flag = true;
									}
									else
									{
										center.X -= (float)(num4 / 2);
										center.Y -= (float)(num4 / 2);
										if (Collision.SolidCollision(center, num4, num4))
										{
											center.X += (float)(num4 / 2);
											center.Y += (float)(num4 / 2);
											flag = true;
										}
									}
									if (flag)
									{
										for (int k = 0; k < 1000; k++)
										{
											if (Main.projectile[k].active && Main.projectile[k].owner == player.whoAmI && Main.projectile[k].type == mod.ProjectileType("EmeraldEnergy") && (center - Main.projectile[k].Center).Length() < 48f)
											{
												flag = false;
												break;
											}
										}
										if (flag && Main.myPlayer == player.whoAmI)
										{
											Projectile.NewProjectile(center.X, center.Y, 0f, 0f, mod.ProjectileType("EmeraldEnergy"), damage, knockBack, player.whoAmI, 0f, 0f);
											return;
										}
									}
								}
							}
						}
					}
				}
			}

			public void EmeraldHeal()
			{
				if ((double)Math.Abs(player.velocity.X) < 0.05 && (double)Math.Abs(player.velocity.Y) < 0.05 && player.itemAnimation == 0)
				{
					if (player.lifeRegenTime > 90 && player.lifeRegenTime < 1800)
					{
						player.lifeRegenTime = 1800;
					}
					player.lifeRegenTime += 6;
					player.lifeRegen += 6;
				}
				
				if (player.lifeRegen > 0 && player.statLife < player.statLifeMax2)
				{
					player.lifeRegenCount++;
					if ((Main.rand.Next(30000) < player.lifeRegenTime || Main.rand.Next(30) == 0))
					{
						int num5 = Dust.NewDust(player.position, player.width, player.height, 55, 0f, 0f, 200, new Color(7, 255, 180), 0.5f);
						Main.dust[num5].noGravity = true;
						Main.dust[num5].velocity *= 0.75f;
						Main.dust[num5].fadeIn = 1.3f;
						Vector2 vector = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
						vector.Normalize();
						vector *= (float)Main.rand.Next(50, 100) * 0.04f;
						Main.dust[num5].velocity = vector;
						vector.Normalize();
						vector *= 34f;
						Main.dust[num5].position = player.Center - vector;
					}
				}
			}
			
			public int beeType2()
			{
				if (Main.rand.Next(2) == 0)
				{
					return 566;
				}
				if (Main.rand.Next(2) == 0)
				{
					return 189;
				}
				return 181;
			}
		}
	}