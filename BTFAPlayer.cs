using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ForgottenMemories
{
	public class BTFAPlayer : ModPlayer
	{
		
		public bool GroundPound;
		public bool Pound;
		public bool AquaPowers;
		public bool isGlitch;
		public bool breakShop;
		public static int rubixCubeSwitcher;
		public bool CosmicPowers;
		public bool hauntedCandle;
		public bool duneBonus;
		public float rangedVelocity;
		public float magicAttackSpeed;
		public bool boneHearts;
		public bool chlorophyllPod;
		public bool chlorophyllPodStage1;
		public bool chlorophyllPodStage2;
		public bool chlorophyllPodStage3;
		private const int saveVersion = 0;
        public bool Servant = false;
		public bool cryotine1 = false;
		public bool BlightFlameRing = false;
		public bool EaterMinion = false;
		public bool BlightstoneDragon = false;
		public bool BlightFlameProj;
		int BlightCounter = 0;
		public bool WoodlouseMinion = false;
		public bool CreeperMinion = false;
		public bool BlightConserve = false;
		public bool ShadowflameSpirit = false;
		public bool BloodSlime = false;
        public static bool hasProjectile;
		public bool slimeGuard = false;
		public bool BlightOrb = false;
		public bool ChaoticSet = false;
		public bool stardustCrown = false;
		public bool ghastlywood = false;
		public bool MagnoliacBool = true;
		public bool GentBool = true;
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
			GroundPound = false;
			AquaPowers = false;
			isGlitch = false;
			CosmicPowers = false;
			hauntedCandle = false;
			duneBonus = false;
			boneHearts = false;
			chlorophyllPod = false;
			chlorophyllPodStage1 = false;
			chlorophyllPodStage2 = false;
			chlorophyllPodStage3 = false;
			magicAttackSpeed = 1f;
			rangedVelocity = 1f;
			rubixCubeSwitcher = 0;
			BlightstoneDragon = false;
			BlightFlameRing = false;
			BlightFlameProj = false;
			BloodSlime = false;
			BlightOrb = false;
            Servant = false;
			cryotine1 = false;
            WoodlouseMinion = false;
			CreeperMinion = false;
			ShadowflameSpirit = false;
			EaterMinion = false;
			slimeGuard = false;
			BlightConserve = false;
			ChaoticSet = false;
			stardustCrown = false;
			ghastlywood = false;
			MagnoliacBool = true;
			GentBool = true;
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
		
		public override void PostUpdate()
	    {
			if(TGEMWorld.forestInvasionUp)
            {
				if ((Main.invasionSize <= 20 && Main.invasionSize >0) && !Main.hardMode && !NPC.AnyNPCs(mod.NPCType("Magnoliac")) && MagnoliacBool)
				{
					if (!NPC.AnyNPCs(mod.NPCType("MagnoliacSwitchingPhase")))
					{
						if (!NPC.AnyNPCs(mod.NPCType("MagnoliacSecondStage")))
						{
							NPC.NewNPC((int)(player.position.X), (int)(player.position.Y - 1200), (mod.NPCType("Magnoliac")));
							MagnoliacBool = false;
							Main.NewText("A beast flaps it's wings to descend !", 175, 75, 255);
						}	
					}
                }
				if ((Main.invasionSize <= 50 && Main.invasionSize >0) && Main.hardMode && !NPC.AnyNPCs(mod.NPCType("Magnoliac")) && MagnoliacBool)
				{
					if (!NPC.AnyNPCs(mod.NPCType("MagnoliacSwitchingPhase")))
					{
						if (!NPC.AnyNPCs(mod.NPCType("MagnoliacSecondStage")))
						{
							NPC.NewNPC((int)(player.position.X), (int)(player.position.Y - 1200), (mod.NPCType("Magnoliac")));
							MagnoliacBool = false;
							Main.NewText("A beast flaps it's wings to descend !", 175, 75, 255);
						}	
					}
                }
				if ((Main.invasionSize <= 20 && Main.invasionSize >0) && Main.hardMode && !NPC.AnyNPCs(mod.NPCType("GhastlyEnt")) && GentBool)
				{
					GentBool = false;
					NPC.NewNPC((int)(player.position.X), (int)(player.position.Y - 1200), (mod.NPCType("GhastlyEnt")));
					Main.NewText("Father of nature awakens !", 175, 75, 255);
                }
			}
		}
		
		public override void ProcessTriggers(TriggersSet triggersSet)
		{		
			if (ForgottenMemories.InGameWikiHotkey.JustPressed)
			{
				Projectile.NewProjectile(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y, 0f, 0f, mod.ProjectileType("InGameWikiMechanism"), 0, 0, player.whoAmI);
			}	
		}
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
			if (chlorophyllPod)
			{
			    player.lifeRegen = ((player.lifeRegen/100)*5) + player.lifeRegen;
				player.moveSpeed = (player.moveSpeed*0.05f) + player.moveSpeed;		
				player.meleeCrit = player.meleeCrit + 5;
				chlorophyllPodStage1 = true;
				chlorophyllPodStage2 = false;
				chlorophyllPodStage3 = false;
			}
			if (chlorophyllPod && chlorophyllPodStage1)
			{
				player.lifeRegen = ((player.lifeRegen/100)*10) + player.lifeRegen;
				player.moveSpeed = (player.moveSpeed*0.1f) + player.moveSpeed;		
				player.meleeCrit = player.meleeCrit + 10;
				chlorophyllPodStage1 = false;
				chlorophyllPodStage2 = true;
				chlorophyllPodStage3 = false;
			}
			if (chlorophyllPodStage2 && chlorophyllPod)
			{
				player.lifeRegen = ((player.lifeRegen/100)*15) + player.lifeRegen;
				player.moveSpeed = (player.moveSpeed*0.15f) + player.moveSpeed;		
				player.meleeCrit = player.meleeCrit + 15;
				chlorophyllPodStage1 = false;
				chlorophyllPodStage2 = false;
				chlorophyllPodStage3 = true;
			}
			
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
		
		public override void OnHitNPCWithProj(Projectile projectile, NPC target, int damage, float knockBack, bool Crit)
		{
			if (projectile.thrown == true && Main.rand.Next(5) == 0 && !target.immortal && boneHearts)
			{
				int number = Item.NewItem((int) target.position.X, (int) target.position.Y, target.width, target.height, mod.ItemType("BoneHeart"), 1, false, 0, false, false);
				Main.item[number].velocity.Y = (float)((double) Main.rand.Next(-20, 1) * 0.200000002980232);
				Main.item[number].velocity.X = (float)((double) Main.rand.Next(10, 31) * 0.200000002980232 * (double) projectile.direction);
				if (Main.netMode == 1)
					NetMessage.SendData(21, -1, -1, (NetworkText) null, number, 0.0f, 0.0f, 0.0f, 0, 0, 0);
			}
			if (chlorophyllPod)
			{
			    player.AddBuff(mod.BuffType("ChlorophyllBuffOne"), 4 * 60);
			}
			if (Main.LocalPlayer.FindBuffIndex(mod.BuffType("ChlorophyllBuffOne")) > -1 && chlorophyllPod)
			{
				player.AddBuff(mod.BuffType("ChlorophyllBuffOne"), 4 * 60);
				chlorophyllPodStage2 = true;
			}
			else 
			{
				chlorophyllPodStage2 = false;
			}
			if (Main.LocalPlayer.FindBuffIndex(mod.BuffType("ChlorophyllBuffOne")) > -1 && chlorophyllPodStage2 && chlorophyllPod)
			{
				chlorophyllPodStage3 = true;
			}
			else
			{
				chlorophyllPodStage3 = false;
			}
			
			if (stardustCrown == true)
			{
				if (ProjectileID.Sets.SentryShot[projectile.type])
				{
					target.AddBuff(mod.BuffType("StardustInferno"), 1800, false);
				}
			}
			
			if (BlightFlameProj == true && (projectile.thrown == true || projectile.ranged == true) && Main.rand.Next(5) == 0)
			{
				int p = Projectile.NewProjectile (target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("BlightBoomRange"), damage, knockBack, player.whoAmI);
			}
			
			if (ghastlywood == true && projectile.magic == true && Crit == true)
			{
				Player player = Main.player[projectile.owner];
				Vector2 mouse = Main.MouseWorld;
				Vector2 newMove = mouse - player.Center;
				newMove.Normalize();
				float memes = newMove.X * 3f;
				float memes2 = newMove.Y * 3f;
				memes += (float)Main.rand.Next(-40, 41) * 0.003f;
				memes2 += (float)Main.rand.Next(-40, 41) * 0.003f;
				int z = Projectile.NewProjectile(player.Center.X, player.Center.Y, memes, memes2, 206, projectile.damage, 0f, projectile.owner, 0f, 0f);
			}
			
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
		
		public override bool ConsumeAmmo(Item weapon, Item ammo)
		{
			if (BlightConserve == true && Main.rand.Next(4) == 0)
			{
				return false;
			}
			
			return true;
		}
		
		public override void SetupStartInventory(IList<Item> items)
		{
			Item item = new Item();
			if (Main.rand.Next(5) == 0)
			{
				item.SetDefaults(mod.ItemType("OldBlade"));
				items.RemoveAt(0);
				items.Insert(0, item);
			}
			
			
			Item item2 = new Item();
			if (Main.rand.Next(5) == 0)
			{
				item2.SetDefaults(mod.ItemType("OldPick"));
				items.RemoveAt(1);
				items.Insert(1, item2);
			}
			
			
			Item item3 = new Item();
			if (Main.rand.Next(5) == 0)
			{
				item3.SetDefaults(mod.ItemType("OldAxe"));
				items.RemoveAt(2);
				items.Insert(2, item3);
			}
			
			Item btfadex = new Item();
			btfadex.SetDefaults(mod.ItemType("BTFADex"));
			btfadex.stack = 1;
			items.Add(btfadex);
		}
		
		public override void PreUpdate() 
		{
			if (player.ZoneSnow && Main.raining && (player.position.Y / 16) <= Main.worldSurface)
            {
                if (Main.rand.Next(600) == 0)
                {
                    Item.NewItem((int)player.position.X + Main.rand.Next(-2000, 2000), (int)player.position.Y - Main.rand.Next(233), 1, 1, mod.ItemType("Galeshard"));
                }
            }
			if (GroundPound == true && player.controlUp && player.velocity.Y > 0)
			{
				player.velocity.Y *= 0.75f;
				Projectile.NewProjectile(player.position.X, player.position.Y + 40, 0f, 0f, mod.ProjectileType("RedFlames"), 70, 0f, player.whoAmI, 0f, 0f);
			}
			if (GroundPound == true && player.controlDown && player.velocity.Y != 0f)
			{
				Projectile.NewProjectile(player.position.X, player.position.Y + 40, 0f, 0f, mod.ProjectileType("RedFlames"), 70, 0f, player.whoAmI, 0f, 0f);
				player.velocity.Y = 30f;
			}
			if (GroundPound == true && player.controlDown && player.velocity.Y != 0f)
			{
				Pound = true;
			}
			
			if (GroundPound && Pound && player.controlDown)
			{
				if (player.velocity.Y == 0f)
				{
					Projectile.NewProjectile(player.position.X, player.position.Y + 40, 0f, 0f, mod.ProjectileType("RedFlameBoom"), 105, 0f, player.whoAmI, 0f, 0f);
					Pound = false;
				}
				
			}
			
			if (AquaPowers == true && Main.rand.Next(50) == 0)
			{
				float spX = (float)Main.rand.Next(-30, 30) * 0.05f;
				float spY = (float)Main.rand.Next(-30, 30) * 0.05f;
				int projectile2 = Projectile.NewProjectile(player.Center.X, player.Center.Y, spX, spY, mod.ProjectileType("buble"), 18, 0f, player.whoAmI, 0f, 0f);
				Main.projectile[projectile2].melee = false;
			}
			
			if (CosmicPowers == true && player.statLife <= (int)(player.statLifeMax2 / 2))
			{
				player.AddBuff(mod.BuffType("CosmicBoon"), 2, false);
			}
			
			if (player.ownedProjectileCounts[mod.ProjectileType("SlimeGuard")] < 1 && slimeGuard == true)
			{
				Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, mod.ProjectileType("SlimeGuard"), 15, 1f, player.whoAmI, 0f, 0f);
			}	
			
			if (player.ownedProjectileCounts[mod.ProjectileType("BlightOrb")] < 1 && BlightOrb == true)
			{
				Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, mod.ProjectileType("BlightOrb"), 45, 1f, player.whoAmI, 0f, 0f);
				Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, mod.ProjectileType("BlightOrb2"), 95, 1f, player.whoAmI, 0f, 0f);
			}
			
			if (player.ownedProjectileCounts[mod.ProjectileType("BlightFireOrbit")] < 12 && BlightFlameRing == true)
			{
				Vector2 Ring = new Vector2(150, 0).RotatedBy(MathHelper.ToRadians(player.ownedProjectileCounts[mod.ProjectileType("BlightFireOrbit")] * 30));
				int p = Projectile.NewProjectile((player.position.X + Ring.X), (player.position.Y + Ring.Y), 0f, 0f, mod.ProjectileType("BlightFireOrbit"), 0, 0f, player.whoAmI, 0f, 0f);
				Main.projectile[p].position += new Vector2 (Main.projectile[p].width/4, Main.projectile[p].height/4);
			}
			
			if (player.ownedProjectileCounts[mod.ProjectileType("BlightLaserOrbit")] < 1 && BlightFlameRing == true)
			{
				BlightCounter++;
				if (BlightCounter >= 180)
				{
					int p = Projectile.NewProjectile((player.position.X + 150), (player.position.Y), 0f, 0f, mod.ProjectileType("BlightLaserOrbit"), 120, 0f, player.whoAmI, 0f, 0f);
					Main.projectile[p].position += new Vector2 (Main.projectile[p].width/2, Main.projectile[p].height/2);
					BlightCounter = 0;
				}
			}
			
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
		
		public override bool Shoot (Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (item.ranged == true)
			{
				speedX *= rangedVelocity;
				speedY *= rangedVelocity;
			}
			return true;
		}
		
		public override void UpdateBadLifeRegen()
		{
			if (ChaoticSet == true && player.statLife < (int)(player.statLifeMax2 * 0.75))
			{
				player.lifeRegen += 2;
				player.AddBuff (105, 1, false);
			}
			
			if (ChaoticSet == true && player.statLife < (int)(player.statLifeMax2/2))
			{
				player.lifeRegen += 6;
			}
			
			if (ChaoticSet == true && player.statLife < (int)(player.statLifeMax2 * 0.25))
			{
				player.lifeRegen += 4;
			}
				
		}
		
		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			if (CosmicPowers == true)
			{
				int amountOfProjectiles = Main.rand.Next(1, 3);
				for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-40, 40) * 0.1f;
					float pX = (float)Main.rand.Next(-120, 120) * 2;
					int projectile = Projectile.NewProjectile(player.Center.X + pX, player.Center.Y - 500, sX, 5, mod.ProjectileType("CosmirockMeteor"), 45, 0f, player.whoAmI, 0f, 0f);
					Main.projectile[projectile].melee = false;
					Main.projectile[projectile].timeLeft = 1000;
				}
			}
			if (duneBonus == true)
			{
				player.AddBuff(mod.BuffType("DuneWinds"), 10 * 60);
				
				int dust;
				Vector2 newVect = new Vector2 (10, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(45)));
				Vector2 newVect2 = newVect.RotatedBy(MathHelper.ToRadians(45));
				Vector2 newVect3 = newVect.RotatedBy(MathHelper.ToRadians(90));
				Vector2 newVect4 = newVect.RotatedBy(MathHelper.ToRadians(135));
				Vector2 newVect5 = newVect.RotatedBy(MathHelper.ToRadians(180));
				Vector2 newVect6 = newVect.RotatedBy(MathHelper.ToRadians(225));
				Vector2 newVect7 = newVect.RotatedBy(MathHelper.ToRadians(270));
				Vector2 newVect8 = newVect.RotatedBy(MathHelper.ToRadians(315));
				dust = Dust.NewDust(player.Center, 0, 0, 32, newVect.X, newVect.Y);
				int dust2 = Dust.NewDust(player.Center, 0, 0, 32, newVect2.X, newVect2.Y);
				int dust3 = Dust.NewDust(player.Center, 0, 0, 32, newVect3.X, newVect3.Y);
				int dust4 = Dust.NewDust(player.Center, 0, 0, 32, newVect4.X, newVect4.Y);
				int dust5 = Dust.NewDust(player.Center, 0, 0, 32, newVect5.X, newVect5.Y);
				int dust6 = Dust.NewDust(player.Center, 0, 0, 32, newVect6.X, newVect6.Y);
				int dust7 = Dust.NewDust(player.Center, 0, 0, 32, newVect7.X, newVect7.Y);
				int dust8 = Dust.NewDust(player.Center, 0, 0, 32, newVect8.X, newVect8.Y);
				Main.dust[dust].noGravity = true;
				Main.dust[dust2].noGravity = true;
				Main.dust[dust3].noGravity = true;
				Main.dust[dust4].noGravity = true;
				Main.dust[dust5].noGravity = true;
				Main.dust[dust6].noGravity = true;
				Main.dust[dust7].noGravity = true;
				Main.dust[dust8].noGravity = true;
				Main.dust[dust].scale = 2;
				Main.dust[dust2].scale = 2;
				Main.dust[dust3].scale = 2;
				Main.dust[dust4].scale = 2;
				Main.dust[dust5].scale = 2;
				Main.dust[dust6].scale = 2;
				Main.dust[dust7].scale = 2;
				Main.dust[dust8].scale = 2;
			}
			
			if (ChaoticSet == true)
			{
				for (int i = 0; i < 7; ++i)
				{
					float sX = (float)Main.rand.Next(-40, 40) * 0.15f;
					float sY = (float)Main.rand.Next(-120, 0) * 0.15f;
					int projectile = Projectile.NewProjectile(player.Center.X, player.Center.Y, sX, sY, 280, 90, 5f, player.whoAmI);
					Main.projectile[projectile].timeLeft = 120;
					Main.projectile[projectile].magic = false;
				}
			}
			
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
		
		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason 	damageSource)		
		{
			damageTaken = damage;
			return true;
		}
	}
}