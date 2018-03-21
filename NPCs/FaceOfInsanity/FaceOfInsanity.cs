using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace ForgottenMemories.NPCs.FaceOfInsanity
{
	[AutoloadBossHead]
    public class FaceOfInsanity : ModNPC
    {
		int aiTimer = 0; //only used in first phase atm
		int BloodTimer = 0;
		int BloodRainTimer = 0;
		int DashTimer = 0;
        int outOfRangeTimer = 0;
		int blindTimer = 0;
		bool phase2 = false;
		float maxSpook = 1f;
		const float spookyDashSpeed = 38f;
        float fadeLimit = 128f;
		bool spookyDashing = false;
		bool spawnedInBloodMoon = false;
		
		float moveX = 0f;
		float moveY = 0f;
		
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 20000;
            npc.damage = 80;
            npc.defense = 22;
            npc.knockBackResist = 0f;
            npc.width = 128;
            npc.height = 154;
            npc.value = Item.buyPrice(0, 8, 0, 0);
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.HitSound = SoundID.NPCHit8;
			npc.DeathSound = SoundID.NPCDeath13;
            npc.npcSlots = 5;
			//NPCID.Sets.TrailCacheLength[npc.type] = 10;
			//NPCID.Sets.TrailingMode[npc.type] = 1;
            if (ForgottenMemories.instance.songsLoaded)
                music = ModLoader.GetMod("BTFASongs").GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/darknessthatchillsmenshearts");
            else
                music = MusicID.Boss4;

			if (Main.bloodMoon)
				spawnedInBloodMoon = true;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arterius");
			Main.npcFrameCount[npc.type] = 5;
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = 24000 + ((numPlayers) * 2400);
			npc.damage = 130;
			npc.defense = 34;
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
			SpriteEffects spriteEffects = SpriteEffects.None;
			Microsoft.Xna.Framework.Color color25 = Lighting.GetColor((int)((double)npc.position.X + (double)npc.width * 0.5) / 16, (int)(((double)npc.position.Y + (double)npc.height * 0.5) / 16.0));
			Texture2D texture2D3 = mod.GetTexture("NPCs/Acheron/AcheronGhost");
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
			if (phase2)
			{
				Texture2D texture2D4 = mod.GetTexture("NPCs/FaceOfInsanity/ArteriusP2");
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
				Microsoft.Xna.Framework.Color color29 = npc.GetAlpha(color25);
				Main.spriteBatch.Draw(texture2D4, npc.position + npc.Size / 2f - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle2), color29, num165 + npc.rotation * num160 * (float)(num161 - 1) * -(float)spriteEffects.HasFlag(SpriteEffects.FlipHorizontally).ToDirectionInt(), origin3, npc.scale, effects, 0f);
				return false;
			}
			else
			{
				var allahuakbar = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
				spriteBatch.Draw(Main.npcTexture[npc.type], npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
								 lightColor, npc.rotation, npc.frame.Size() / 2, npc.scale, allahuakbar, 0);
			}
			return false;
		}
		
		public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			if(phase2)
				BTFAUtility.DrawNPCGlowMask(spriteBatch, npc, mod.GetTexture("NPCs/FaceOfInsanity/ArteriusP2_Glow"));
			
			else
				BTFAUtility.DrawNPCGlowMask(spriteBatch, npc, mod.GetTexture("NPCs/FaceOfInsanity/Arterius_Glow"));
		}
		
		public void SpookyDash()
		{
			Vector2 direction = Vector2.Subtract(Main.player[npc.target].Center, npc.Center);
			//Main.player[npc.target].GetModPlayer<BTFAPlayer>(mod).spookTimer = 120;

			if (phase2)
				spookyDashing = true;

			double angle = Math.Atan2(direction.Y, direction.X);
			npc.velocity = new Vector2(spookyDashSpeed, 0).RotatedBy(angle);
			Main.PlaySound(15, (int)Main.player[npc.target].Center.X, (int)Main.player[npc.target].Center.Y, 2);
		}

        public void ShootEyeBeams(Player player, bool leadShots)
        {
            Vector2 eye1 = new Vector2(npc.Center.X - 36, npc.Center.Y - 4);
            Vector2 eye2 = new Vector2(npc.Center.X + 36, npc.Center.Y - 4);
            Vector2 Vel1 = player.Center - eye1;
            Vector2 Vel2 = player.Center - eye2;
            Vel1.Normalize();
            Vel2.Normalize();
            Vel1 *= 8;
            Vel2 *= 8;
            if (leadShots)
            {
                Vel1 += player.velocity / 2;
                Vel2 += player.velocity / 2;
            }
            Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 33);
            int p1 = Projectile.NewProjectile(eye1, Vel1, mod.ProjectileType("BrimstoneSmall"), npc.damage * 4, 0, npc.target, 0, 0); //20
            Main.projectile[p1].netUpdate = true;

            int p2 = Projectile.NewProjectile(eye2, Vel2, mod.ProjectileType("BrimstoneSmall"), npc.damage * 4, 0, npc.target, 0, 0); //20
            Main.projectile[p2].netUpdate = true;

            if (Main.expertMode)
			{
				Main.projectile[p1].damage = npc.damage / 6; //25
				Main.projectile[p2].damage = npc.damage / 6;
			}
        }

        public void ShootBigBeam()
        {
            Player player = Main.player[npc.target];
            Vector2 cross = new Vector2(npc.Center.X, npc.Center.Y - 30);
            Vector2 Vel = player.Center - cross;
 			Vel.Normalize();
 			Vel *= 20;
 			Vel += player.velocity / 3;
			int p = Projectile.NewProjectile(cross, Vel, mod.ProjectileType("BrimstoneBig"), npc.damage / 2, 0, npc.target, 0, 0); //40
			Main.projectile[p].netUpdate = true;
			Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 73);

            if (Main.expertMode)
            {
                Main.projectile[p].damage = npc.damage * 4 / 15; //40
            }
        }

        public void ShootSpinalBolts()
        {
            Player player = Main.player[npc.target];
            Vector2 cross = new Vector2(npc.Center.X, npc.Center.Y - 30);
            Vector2 distance = player.Center - cross;

            int boltsPerVolley = 4;
            float gravity = 0.35f;
            float time = 60f;
            if (Main.expertMode)
            {
                boltsPerVolley = 6;
                distance += player.velocity * 30;
            }
            
            Vector2 Vel = new Vector2(distance.X / time, distance.Y / time - 0.5f * gravity * time);

            for (int i = 0; i < boltsPerVolley; i++)
            {
                Vector2 velocity = Vel + new Vector2((float)Main.rand.Next(-5, 6) / 2f, (float)Main.rand.Next(-5, 6) / 2f);
                int p = Projectile.NewProjectile(cross, velocity, mod.ProjectileType("SpinalBoltEvil"), npc.damage / 5, 0, Main.myPlayer, 1f, 0); //16
                if (Main.expertMode)
                    Main.projectile[p].damage = npc.damage / 6; //25
            }

            Main.PlaySound(29, (int)npc.position.X, (int)npc.position.Y, 9);
        }

		public void CheckOutOfRange()
        {
            //Vector2 targetLocation = new Vector2(player.Center.X, player.Center.Y - 250);
            Vector2 distance = Vector2.Subtract(Main.player[npc.target].Center, npc.Center);
            bool outOfRange = distance.Length() > 1500;

            if (outOfRange)
            {
                npc.Center = Main.player[npc.target].Center + new Vector2(0, 550); //teleport below player
                SpookyDash();
                outOfRangeTimer = 60;
            }
        }

		public void ProcessBlinding()
		{
			blindTimer++;

			if (blindTimer == 28)
			{
				for (int i = 0; i < 255; i++)
				{
					Vector2 distance = Main.player[i].Center - npc.Center;
					if (distance.Length() <= 1500)
					{
						if (Main.player[i].buffImmune[BuffID.Darkness])
							Main.player[i].buffImmune[BuffID.Darkness] = false; //ignore immunity
						Main.player[i].AddBuff(BuffID.Darkness, 29);
					}
				}
				blindTimer = 0;
			}
		}

        public override void AI()
        {
			npc.spriteDirection = 1;
			npc.TargetClosest(true);
            Player player = Main.player[npc.target];

			ProcessBlinding();
			
			if ((npc.life < npc.lifeMax * 2 / 3 && Main.expertMode) || npc.life < npc.lifeMax / 2)
			{
				npc.ai[0] = 1;
			}
			
			if (!phase2 && npc.ai[0] == 0)
			{
				aiTimer++;

                if (npc.Center.X > player.Center.X + 10 && moveX > -8f)
                    moveX -= 0.2f;
                if (npc.Center.X > player.Center.X + 10 && moveX > 0f)
                    moveX -= 1f;

                if (npc.Center.X < player.Center.X - 10 && moveX < 8f)
                    moveX += 0.2f;
                if (npc.Center.X < player.Center.X - 10 && moveX < 0f)
                    moveX += 1f;

                if (npc.Center.Y < player.Center.Y - 370 && moveY < 8f)
                    moveY += 0.2f;
                if (npc.Center.Y < player.Center.Y - 370 && moveY < 0f)
                    moveY += 1f;

                if (npc.Center.Y > player.Center.Y - 350 && moveY > -8f)
                    moveY -= 0.2f;
                if (npc.Center.Y > player.Center.Y - 350 && moveY > 0f)
                    moveY -= 1f;

                Vector2 Velocity = new Vector2(moveX, moveY);
                
                bool abovePlayer = ((npc.Center.Y < Main.player[npc.target].Center.Y - 250));

                if (outOfRangeTimer > 0)
                {
                    npc.velocity *= 0.97f;
                    outOfRangeTimer--;
                }
                else
                {
                    if (abovePlayer)
					{
						if (Main.expertMode)
							Velocity *= 2f/3f;
						else
							Velocity /= 3f;
					}

                    npc.velocity = Velocity;

                    CheckOutOfRange();
                }
				
				//left these % in because the desync is a feature
                if (abovePlayer)
                {
                    if (aiTimer % 130 == 0 && Main.expertMode)
                    {
                        Vector2 cross = new Vector2(npc.Center.X, npc.Center.Y - 30);
                        Vector2 velocity = Vector2.Subtract(player.Center, cross);
                        velocity.Normalize();
                        velocity *= 8;
                        velocity += player.velocity / 2;
                        int p = Projectile.NewProjectile(cross, velocity, mod.ProjectileType("SpinalBoltEvil"), npc.damage / 6, 0, Main.myPlayer, 0, 0); //25, EXPERT ONLY
                    }
                    if (aiTimer % 110 == 0)
                        ShootBlood(mod.NPCType("ExplosiveZitEnemy"), false);
                    if (aiTimer % 90 == 0)
                        ShootBlood(mod.ProjectileType("zBloodStream"), true);
                }
				
				if (aiTimer % 360 <= 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("PinkEye"));
				}
				
			}
			
			if (npc.ai[0] == 1 && !phase2)
			{
				if (npc.alpha < 255)
				{
					npc.alpha += 5;
				}
				else
				{
					phase2 = true;
					Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 2);
				}
				
				npc.velocity = Vector2.Zero;
			}
			
			if (phase2)
			{
				if (npc.alpha > 0 && npc.ai[3] == 0)
				{
					npc.ai[1] = 0;
					npc.alpha -= 5;
					if (maxSpook > 1f) //quicker transitions after spooky dashes
						npc.alpha -= 10;
				}
				else
				{
					if(npc.ai[2] == 0)
					{
						npc.ai[1]++;

                        if(npc.Center.X > player.Center.X && moveX > -3f)
							moveX -= 0.2f;
						if(npc.Center.X > player.Center.X && moveX > 0f)
							moveX -= 1f;
						
						if(npc.Center.X < player.Center.X && moveX < 3f)
							moveX += 0.2f;
						if(npc.Center.X < player.Center.X && moveX < 0f)
							moveX += 1f;
						
						if(npc.Center.Y < player.Center.Y && moveY < 2f)
							moveY += 0.2f;
						if(npc.Center.Y < player.Center.Y && moveY < 0f)
							moveY += 1f;
						
						if(npc.Center.Y > player.Center.Y && moveY > -2f)
							moveY -= 0.2f;
						if(npc.Center.Y > player.Center.Y && moveY > 0f)
							moveY -= 1f;

                        Vector2 Velocity = new Vector2(moveX, moveY);
                        if (Main.expertMode)
                            Velocity *= 1.25f;
                        npc.velocity = Velocity;
					}
					
					//stop, begin fade for spooky dash
                    if (npc.ai[1] == 360)
					{
						if (npc.life < npc.lifeMax / 3 && npc.ai[2] == 0)
						{
							npc.ai[2] = 1;
							npc.velocity = Vector2.Zero;

							if (Main.expertMode)
							{
								npc.dontTakeDamage = true;
								ShootSpinalBolts();
								if (npc.life < npc.lifeMax / 6)
									ShootBigBeam();

								if (maxSpook != 1f) //shorten time spent fading after first cycle
									fadeLimit = 90f;

								if (maxSpook < 7f) //gain 2 extra dashes per cycle, up to 6
									maxSpook += 2f;
							}
							else
							{
								if (npc.life < npc.lifeMax / 6)
									ShootSpinalBolts();

								if (npc.life < npc.lifeMax / 9)
									ShootBigBeam();
							}
						}
						else //messy. this section above and below feels very messy
						{
                            ShootBigBeam();
							if (Main.expertMode && maxSpook > 1f)
                                ShootSpinalBolts();
						}

						npc.ai[1] = 0;
					}
					
					if (npc.ai[2] > 0)
					{
						npc.ai[3]++; //timer
						
						if (npc.ai[3] < fadeLimit) //stop and fade
						{
                            //Main.player[npc.target].GetModPlayer<BTFAPlayer>(mod).spookTimer = 120;
							
							if (fadeLimit == 120f)
                                npc.alpha += 2;
                            else
                                npc.alpha += 3;
						}
						else if (npc.ai[3] == fadeLimit)
						{
							npc.Center = Main.player[npc.target].Center + new Vector2(0, -500); //teleport above player
							npc.dontTakeDamage = false;

							Main.bloodMoon = true;

                            SpookyDash();
						}
						else
						{
							npc.velocity *= 0.97f; //slowdown
							float speed = npc.velocity.Length();

							npc.alpha = (int) (255f * (spookyDashSpeed - speed) / spookyDashSpeed); //visibility is proportional to speed

							if (speed < 2.5f)
							{
								npc.ai[2]++;
                                
								if (npc.ai[2] != maxSpook && Main.expertMode)
								{
                                    if (npc.ai[2] == 3f)
										ShootBigBeam();
									ShootEyeBeams(player, true);
                                    SpookyDash();
								}
								else //reset
								{
                                    npc.ai[2] = 0;
									npc.ai[3] = 0;
									npc.alpha = 225;

									spookyDashing = false;

									if (!spawnedInBloodMoon)
										Main.bloodMoon = false;
								}
							}
						}
					}
					else if (npc.ai[1] == 180)
					{
                        ShootSpinalBolts();
						if (Main.expertMode && maxSpook > 1f)
							ShootBigBeam();
					}
					else if (npc.ai[1] == 45 || npc.ai[1] == 90 || npc.ai[1] == 135 || npc.ai[1] == 225 || npc.ai[1] == 270 || npc.ai[1] == 315)
					{
                        ShootEyeBeams(player, false);
					}
				}

				//if (aiTimer % 300 <= 0 && Main.expertMode) NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("PinkEye"));
			}
			
			if (Main.dayTime || !player.active || player.dead) //despawn
            {
                npc.TargetClosest(false);
                npc.velocity.Y = -20;
				npc.ai[0] = 0;
				if (npc.timeLeft > 10)
				{
					npc.timeLeft = 10;
				}
				if (!spawnedInBloodMoon && spookyDashing)
					Main.bloodMoon = false;
            }
		}

		public override bool StrikeNPC (ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
		{
			if (maxSpook > 1f)
				damage *= 0.9;
			
			if (spookyDashing)
			{
				damage *= 0.5;
				return false;
			}

			return true;
		}

		public override bool CheckDead()
		{
			if (spookyDashing && !spawnedInBloodMoon)
				Main.bloodMoon = false;
			
			return true;
		}
		
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.3f; 
			npc.frameCounter %= Main.npcFrameCount[npc.type]; 
			int frame = (int)npc.frameCounter; 
			npc.frame.Y = frame * frameHeight; 
		}
		
		public void ShootBlood(int type, bool rain)
		{
			if (!rain)
			{
                for (int index = 0; index < Main.rand.Next(4, 6); index++)
                    NPC.NewNPC((int)(npc.Center.X + Main.rand.Next(-50, 51)), (int)npc.Center.Y + 70, type, 0, 0f, 0f, 0f, 0f, npc.target);

                if (Main.expertMode)
				{
					for (int index = 0; index < Main.rand.Next(1, 3); index++)
						NPC.NewNPC((int)(npc.Center.X + Main.rand.Next(-50, 51)), (int)npc.Center.Y + 70, type, 0, 0f, 0f, 0f, 0f, npc.target);
				}

				Main.PlaySound(29, (int)npc.position.X, (int)npc.position.Y, 9);
			}
			else
			{
				for (int index = 0; index < Main.rand.Next(3, 6); index++)
				{
					Vector2 offset = new Vector2(Main.rand.Next(-200, 201), -200);
					Vector2 direction = Main.player[npc.target].Center - (npc.Center + offset);
					direction.Normalize();
					direction *= 7;
					int p = Projectile.NewProjectile(npc.Center + offset, direction, type, npc.damage / 8, 1, Main.myPlayer, 0, 0); //10
					Main.projectile[p].netUpdate = true;
					if (Main.expertMode)
                        Main.projectile[p].damage = npc.damage / 10; //15
				}
			}
			npc.netUpdate = true;
		}
		
		public override void NPCLoot()
		{
			TGEMWorld.TryForBossMask(npc.Center, npc.type);
			if (Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("ArteriusBag")));
			}
			
			else
			{
				switch (Main.rand.Next(4))
				{
					case 0: 
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("HemorrhageStaff")));
						break;
					case 1: 
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("SeveredTongue")));
						break;
					case 2:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("BloodLeech")), Main.rand.Next(250, 271));
						break;
					case 3:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("GoredLung")));
						break;
					default:
						break;
				}
			}
			TGEMWorld.downedArterius = true;
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Arterius/ArteriusGore1"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Arterius/ArteriusGore2"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Arterius/ArteriusGore3"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Arterius/ArteriusGore4"), 1f);
		}
	}
}
