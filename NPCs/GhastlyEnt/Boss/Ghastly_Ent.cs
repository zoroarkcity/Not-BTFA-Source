 using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.GhastlyEnt.Boss
{
	[AutoloadBossHead]
    public class Ghastly_Ent : ModNPC
    {
		protected float speedMultiplier = 1f;
		protected int dashTimer = 0;
		protected int leafTimer = 0;
		protected int secondStagePortals = 0;
		protected int leafAmount = 0;
		protected int eruptionFromGroundTimer = 0;
		protected int teleportation = 0;
		protected int homingLifeStealer = 0;
		protected int projectileTeleport = 0;
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 30000;
            npc.defense = 20;
            npc.knockBackResist = 0f;
            npc.width = 160;
            npc.height = 260;
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
			music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/Forests_Army");
			npc.npcSlots = 5;
			bossBag = mod.ItemType("MegaTreeBag");
        }
		
		/*public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = 50000 + ((numPlayers) * 20000);
			npc.damage = 90;
		}*/
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ghastly Ent");
			Main.npcFrameCount[npc.type] = 7;
		}

        public override void AI()
        {
			npc.netUpdate = true;
			if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
	  	    if (Main.player[npc.target].dead)
			{
				npc.active = false;
			}
			npc.spriteDirection = npc.direction;
            Player player = Main.player[npc.target];
			leafTimer++;
			homingLifeStealer++;
			teleportation++;
			if (Main.netMode != 1 && leafTimer >= 120 && secondStagePortals < 480)
			{
				Vector2 vector2_1 = new Vector2(npc.position.X - 40 + (float) npc.width * 0.5f, npc.position.Y - 100 + (float) npc.height * 0.5f);
				for (int index = 0; index < 4 + leafAmount; ++index)
				{
					Main.PlaySound(new Terraria.Audio.LegacySoundStyle(6, 0));
					Vector2 vector2_2 = new Vector2((float) (index - 2), -4f);
					vector2_2.X *= (float) (1.0 + (double) Main.rand.Next(-50, 51) * 0.00499999988824129);
					vector2_2.Y *= (float) (1.0 + (double) Main.rand.Next(-50, 51) * 0.00499999988824129);
					vector2_2.Normalize();
					vector2_2 *= (float) (8.0 + leafAmount + (double) Main.rand.Next(-50, 51) * 0.00999999977648258);
					Projectile.NewProjectile(vector2_1.X, vector2_1.Y, vector2_2.X, vector2_2.Y, mod.ProjectileType("Sharp_Leaf"), 9, 0.0f, Main.myPlayer, 0.0f, 0.0f);
				}
				leafTimer = 0;
			}
			if (Main.netMode != 1 && leafTimer >= 120 && secondStagePortals < 480)
			{
				Vector2 vector2_1 = new Vector2(npc.position.X - 40 + (float) npc.width * 0.5f, npc.position.Y - 100 + (float) npc.height * 0.5f);
				for (int index = 0; index < 4 + leafAmount; ++index)
				{
					Main.PlaySound(new Terraria.Audio.LegacySoundStyle(6, 0));
					Vector2 vector2_2 = new Vector2((float) (index - 2), -4f);
					vector2_2.X *= (float) (1.0 + (double) Main.rand.Next(-50, 51) * 0.00499999988824129);
					vector2_2.Y *= (float) (1.0 + (double) Main.rand.Next(-50, 51) * 0.00499999988824129);
					vector2_2.Normalize();
					vector2_2 *= (float) (8.0 + leafAmount + (double) Main.rand.Next(-50, 51) * 0.00999999977648258);
					Projectile.NewProjectile(vector2_1.X, vector2_1.Y, vector2_2.X, vector2_2.Y, mod.ProjectileType("Sharp_Leaf"), 9, 0.0f, Main.myPlayer, 0.0f, 0.0f);
				}
				leafTimer = 0;
			}
			secondStagePortals++;
			if (Main.netMode != 1 && secondStagePortals == 599 || secondStagePortals == 540 || secondStagePortals == 480 && (npc.life >= npc.lifeMax/1.5f))
			{
				npc.dontTakeDamage = true;
				Main.PlaySound(new Terraria.Audio.LegacySoundStyle(42, 44));
				if (secondStagePortals == 480)
					Projectile.NewProjectile(npc.position.X + 80, npc.position.Y - 160, 0f, 0f, mod.ProjectileType("Projectile_Portal"), 0, 0.0f, Main.myPlayer, 0.0f, 0.0f);
				else if (secondStagePortals == 540)
					Projectile.NewProjectile(npc.position.X - 160, npc.position.Y + 160, 0f, 0f, mod.ProjectileType("Projectile_Portal"), 0, 0.0f, Main.myPlayer, 0.0f, 0.0f);
				else if (secondStagePortals == 599)
					Projectile.NewProjectile(npc.position.X + 320, npc.position.Y + 160, 0f, 0f, mod.ProjectileType("Projectile_Portal"), 0, 0.0f, Main.myPlayer, 0.0f, 0.0f);
				npc.velocity = Vector2.Zero;
			}
			if (secondStagePortals >= 720)
			{
				secondStagePortals = 0;
				npc.dontTakeDamage = false;
			}
			if (secondStagePortals >= 480)
			{
				player.AddBuff(BuffID.Poisoned, 2);
				player.ManageSpecialBiomeVisuals("Vortex", player.active, new Vector2(npc.position.X + 80, npc.position.Y + 100));
				player.ManageSpecialBiomeVisuals("WaterDistortion", player.active, new Vector2(player.position.X, player.position.Y));
				player.ManageSpecialBiomeVisuals("HeatDistortion", player.active, new Vector2(player.position.X, player.position.Y));
			}
			
			eruptionFromGroundTimer++;
			if (Main.netMode != 1 && eruptionFromGroundTimer >= 180)
			{
				if (npc.life >= npc.lifeMax/1.5f)
				{
					Projectile.NewProjectile(npc.position.X + Main.rand.Next(-800, 800), npc.position.Y - 800, 0f, 1f, mod.ProjectileType("Cursed_Flame_Eruption_Alt"), 9, 0.0f, Main.myPlayer, 0.0f, 0.0f);
					Projectile.NewProjectile(npc.position.X + Main.rand.Next(-800, 800), npc.position.Y - 800, 0f, 2f, mod.ProjectileType("Cursed_Flame_Eruption_Alt"), 9, 0.0f, Main.myPlayer, 0.0f, 0.0f);
					Projectile.NewProjectile(npc.position.X + Main.rand.Next(-800, 800), npc.position.Y - 800, 0f, 3f, mod.ProjectileType("Cursed_Flame_Eruption_Alt"), 9, 0.0f, Main.myPlayer, 0.0f, 0.0f);
				}
				else if (npc.life >= npc.lifeMax/2.5f && npc.life < npc.lifeMax/1.5f)
				{
					Projectile.NewProjectile(npc.position.X + Main.rand.Next(-800, 800), npc.position.Y - 800, 0f, 1f, mod.ProjectileType("Cursed_Flame_Eruption_Alt"), 9, 0.0f, Main.myPlayer, 0.0f, 0.0f);
					Projectile.NewProjectile(npc.position.X + Main.rand.Next(-800, 800), npc.position.Y - 800, 0f, 2f, mod.ProjectileType("Cursed_Flame_Eruption_Alt"), 9, 0.0f, Main.myPlayer, 0.0f, 0.0f);
					Projectile.NewProjectile(npc.position.X + Main.rand.Next(-800, 800), npc.position.Y - 800, 0f, 3f, mod.ProjectileType("Cursed_Flame_Eruption_Alt"), 9, 0.0f, Main.myPlayer, 0.0f, 0.0f);
					Projectile.NewProjectile(npc.position.X + Main.rand.Next(-800, 800), npc.position.Y - 800, 0f, 3f, mod.ProjectileType("Cursed_Flame_Eruption_Alt"), 9, 0.0f, Main.myPlayer, 0.0f, 0.0f);
					Projectile.NewProjectile(npc.position.X + Main.rand.Next(-800, 800), npc.position.Y - 800, 0f, 3f, mod.ProjectileType("Cursed_Flame_Eruption_Alt"), 9, 0.0f, Main.myPlayer, 0.0f, 0.0f);
				}
				else if (npc.life < npc.lifeMax/2.5f)
				{
					Projectile.NewProjectile(npc.position.X + Main.rand.Next(-800, 800), npc.position.Y - 800, 0f, 1f, mod.ProjectileType("Cursed_Flame_Eruption_Alt"), 9, 0.0f, Main.myPlayer, 0.0f, 0.0f);
					Projectile.NewProjectile(npc.position.X + Main.rand.Next(-800, 800), npc.position.Y - 800, 0f, 2f, mod.ProjectileType("Cursed_Flame_Eruption_Alt"), 9, 0.0f, Main.myPlayer, 0.0f, 0.0f);
					Projectile.NewProjectile(npc.position.X + Main.rand.Next(-800, 800), npc.position.Y - 800, 0f, 3f, mod.ProjectileType("Cursed_Flame_Eruption_Alt"), 9, 0.0f, Main.myPlayer, 0.0f, 0.0f);
					Projectile.NewProjectile(npc.position.X + Main.rand.Next(-800, 800), npc.position.Y - 800, 0f, 3f, mod.ProjectileType("Cursed_Flame_Eruption_Alt"), 9, 0.0f, Main.myPlayer, 0.0f, 0.0f);
					Projectile.NewProjectile(npc.position.X + Main.rand.Next(-800, 800), npc.position.Y - 800, 0f, 3f, mod.ProjectileType("Cursed_Flame_Eruption_Alt"), 9, 0.0f, Main.myPlayer, 0.0f, 0.0f);
					Projectile.NewProjectile(npc.position.X + Main.rand.Next(-800, 800), npc.position.Y - 800, 0f, 3f, mod.ProjectileType("Cursed_Flame_Eruption_Alt"), 9, 0.0f, Main.myPlayer, 0.0f, 0.0f);
					Projectile.NewProjectile(npc.position.X + Main.rand.Next(-800, 800), npc.position.Y - 800, 0f, 3f, mod.ProjectileType("Cursed_Flame_Eruption_Alt"), 9, 0.0f, Main.myPlayer, 0.0f, 0.0f);
				}
				eruptionFromGroundTimer = 0;
			}
			
			if ((double) Vector2.Distance(player.Center, npc.Center) <= (double) 300f)
			{
				player.AddBuff(BuffID.Poisoned, 2);
				//player.ManageSpecialBiomeVisuals("Vortex", player.active, new Vector2(npc.position.X + 80, npc.position.Y + 100));
				//player.ManageSpecialBiomeVisuals("WaterDistortion", player.active, new Vector2(player.position.X, player.position.Y));
				//player.ManageSpecialBiomeVisuals("HeatDistortion", player.active, new Vector2(player.position.X, player.position.Y));
				npc.damage = 120; //ADJUST THIS, DAMAGE IS SUPPOSED TO INCREASE WHEN NPC IS CLOSE TO PLAYER
				npc.defense = 60; //ADJUST THIS, DAMAGE IS SUPPOSED TO INCREASE WHEN NPC IS CLOSE TO PLAYER
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
			
			if ((double) Vector2.Distance(player.Center, npc.Center) <= (double) 100f)
			{
				player.wingTime = 0;
				player.wingTimeMax = 0;
				player.mount.Dismount(player);
			}
			if (npc.life >= npc.lifeMax/1.5f) //666 >
				FirstStage();
			else if (npc.life >= npc.lifeMax/2.5f && npc.life < npc.lifeMax/1.5f)//400 > && 600 <
				SecondStage();
			else if (npc.life < npc.lifeMax/2.5f)
				ThirdStage();
			
			if (npc.position.Y < player.position.Y && secondStagePortals < 480)
			{
				bool flag1 = false;
				bool flag2 = npc.type == 330 && !Main.pumpkinMoon;
				if (npc.justHit)
				  npc.ai[2] = 0.0f;
				if (!flag2)
				{
				  if ((double) npc.ai[2] >= 0.0)
				  {
					int num1 = 16;
					bool flag3 = false;
					bool flag4 = false;
					if ((double) npc.position.X > (double) npc.ai[0] - (double) num1 && (double) npc.position.X < (double) npc.ai[0] + (double) num1)
					  flag3 = true;
					else if ((double) npc.velocity.X < 0.0 && npc.direction > 0 || (double) npc.velocity.X > 0.0 && npc.direction < 0)
					  flag3 = true;
					int num2 = num1 + 24;
					if ((double) npc.position.Y > (double) npc.ai[1] - (double) num2 && (double) npc.position.Y < (double) npc.ai[1] + (double) num2)
					  flag4 = true;
					if (flag3 && flag4)
					{
					  ++npc.ai[2];
					  if ((double) npc.ai[2] >= 30.0 && num2 == 16)
						flag1 = true;
					  if ((double) npc.ai[2] >= 60.0)
					  {
						npc.ai[2] = -200f;
						npc.direction *= -1;
						npc.velocity.X *= -2f;
						npc.collideX = false;
					  }
					}
					else
					{
					  npc.ai[0] = npc.position.X;
					  npc.ai[1] = npc.position.Y;
					  npc.ai[2] = 0.0f;
					}
					npc.TargetClosest(true);
				  }
				  else if (npc.type == 253)
				  {
					npc.TargetClosest(true);
					npc.ai[2] += 2f;
				  }
				  else
				  {
					if (npc.type == 330)
					  npc.ai[2] += 0.1f;
					else
					  ++npc.ai[2];
					if ((double) Main.player[npc.target].position.X + (double) (Main.player[npc.target].width / 2) > (double) npc.position.X + (double) (npc.width / 2))
					  npc.direction = -1;
					else
					  npc.direction = 1;
				  }
				}
				int index1 = (int) (((double) npc.position.X + (double) (npc.width / 2)) / 16.0) + npc.direction * 2;
				int num3 = (int) (((double) npc.position.Y + (double) npc.height) / 16.0);
				bool flag5 = true;
				bool flag6 = false;
				int num4 = 3;
		   
				for (int index2 = num3; index2 < num3 + num4; ++index2)
				{
				  if (Main.tile[index1, index2] == null)
					Main.tile[index1, index2] = new Tile();
				  if (Main.tile[index1, index2].nactive() && Main.tileSolid[(int) Main.tile[index1, index2].type] || (int) Main.tile[index1, index2].liquid > 0)
				  {
					if (index2 <= num3 + 1)
					  flag6 = true;
					flag5 = false;
					break;
				  }
				}
				if (Main.player[npc.target].npcTypeNoAggro[npc.type])
				{
				  bool flag3 = false;
				  for (int index2 = num3; index2 < num3 + num4 - 2; ++index2)
				  {
					if (Main.tile[index1, index2] == null)
					  Main.tile[index1, index2] = new Tile();
					if (Main.tile[index1, index2].nactive() && Main.tileSolid[(int) Main.tile[index1, index2].type] || (int) Main.tile[index1, index2].liquid > 0)
					{
					  flag3 = true;
					  break;
					}
				  }
				  npc.directionY = (!flag3).ToDirectionInt();
				}
				if (flag1)
				{
				  flag6 = false;
				  flag5 = true;
				}
				if (flag5)
				{
				  {
					npc.velocity.Y += 0.2f*speedMultiplier;
					if ((double) npc.velocity.Y > 3.0)
					  npc.velocity.Y = 6f*speedMultiplier;
				  }
				}
				else
				{
				  if (npc.directionY < 0 && (double) npc.velocity.Y > 0.0)
					npc.velocity.Y -= 0.2f*speedMultiplier;
				  if ((double) npc.velocity.Y < -4.0)
					npc.velocity.Y = -8f*speedMultiplier;
				}
				if (npc.collideX)
				{
				  npc.velocity.X = npc.oldVelocity.X * -0.4f;
				  if (npc.direction == -1 && (double) npc.velocity.X > 0.0 && (double) npc.velocity.X < 1.0)
					npc.velocity.X = 2f*speedMultiplier;
				  if (npc.direction == 1 && (double) npc.velocity.X < 0.0 && (double) npc.velocity.X > -1.0)
					npc.velocity.X = -2f*speedMultiplier;
				}
				if (npc.collideY)
				{
				  npc.velocity.Y = npc.oldVelocity.Y * -0.25f;
				  if ((double) npc.velocity.Y > 0.0 && (double) npc.velocity.Y < 1.0)
					npc.velocity.Y = 2f*speedMultiplier;
				  if ((double) npc.velocity.Y < 0.0 && (double) npc.velocity.Y > -1.0)
					npc.velocity.Y = -2f*speedMultiplier;
				}
				float num11 = 2f;
				if (npc.direction == -1 && (double) npc.velocity.X > -(double) num11)
				{
				  npc.velocity.X -= 0.2f*speedMultiplier;
				  if ((double) npc.velocity.X > (double) num11)
					npc.velocity.X -= 0.2f*speedMultiplier;
				  else if ((double) npc.velocity.X > 0.0)
					npc.velocity.X += 0.1f*speedMultiplier;
				  if ((double) npc.velocity.X < -(double) num11)
					npc.velocity.X = -num11*2*speedMultiplier;
				}
				else if (npc.direction == 1 && (double) npc.velocity.X < (double) num11)
				{
				  npc.velocity.X += 0.2f*speedMultiplier;
				  if ((double) npc.velocity.X < -(double) num11)
					npc.velocity.X += 0.2f*speedMultiplier;
				  else if ((double) npc.velocity.X < 0.0)
					npc.velocity.X -= 0.1f*speedMultiplier;
				  if ((double) npc.velocity.X > (double) num11)
					npc.velocity.X = num11*2*speedMultiplier;
				}
				float num12 = npc.type != 490 ? 1.5f : 1f;
				if (npc.directionY == -1 && (double) npc.velocity.Y > -(double) num12)
				{
				  npc.velocity.Y -= 0.08f*speedMultiplier;
				  if ((double) npc.velocity.Y > (double) num12)
					npc.velocity.Y -= 0.1f*speedMultiplier;
				  else if ((double) npc.velocity.Y > 0.0)
					npc.velocity.Y += 0.06f*speedMultiplier;
				  if ((double) npc.velocity.Y < -(double) num12)
					npc.velocity.Y = -num12*2*speedMultiplier;
				}
				else if (npc.directionY == 1 && (double) npc.velocity.Y < (double) num12)
				{
				  npc.velocity.Y += 0.08f*speedMultiplier;
				  if ((double) npc.velocity.Y < -(double) num12)
					npc.velocity.Y += 0.1f*speedMultiplier;
				  else if ((double) npc.velocity.Y < 0.0)
					npc.velocity.Y -= 0.06f*speedMultiplier;
				  if ((double) npc.velocity.Y > (double) num12)
					npc.velocity.Y = num12*2*speedMultiplier;
				}
			  }
			else if (secondStagePortals < 480) 
			{
				Vector2 vector2 = new Vector2(npc.position.X + (float) npc.width * 0.5f, npc.position.Y + (float) npc.height * 0.5f);
				float num2 = Main.player[npc.target].position.X + (float) (Main.player[npc.target].width / 2) - vector2.X;
				float num3 = Main.player[npc.target].position.Y + (float) (Main.player[npc.target].height / 2) - vector2.Y;
				float num4 = 8f / (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
				npc.velocity.X = num2 * num4 * (speedMultiplier / 2f + 0.25f);
				npc.velocity.Y = num3 * num4 * (speedMultiplier / 2f + 0.25f);
			}
		}
		
		public void FirstStage()
		{
			speedMultiplier = 0.5f;
			leafAmount = 0;
		}
		public void SecondStage()
		{
			speedMultiplier = 1f;
			leafAmount = 2;
		}
		public void ThirdStage()
		{
			speedMultiplier = 1.5f;
			leafAmount = 4;
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(3, 6), false);
		}
		
		 public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			scale = 1.5f;
			return null;
        }
		
		public override void FindFrame(int frameHeight)
		{
			const int Frame_1 = 0;
			const int Frame_2 = 1;
			const int Frame_3 = 2;
			const int Frame_4 = 3;
			const int Frame_5 = 4;
			const int Frame_6 = 5;
			const int Frame_7 = 6;
			
			npc.frameCounter++;
			if (npc.frameCounter < 6)
			{
				npc.frame.Y = Frame_1 * frameHeight;
			}
			else if (npc.frameCounter < 12)
			{
				npc.frame.Y = Frame_2 * frameHeight;
			}
			else if (npc.frameCounter < 18)
			{
				npc.frame.Y = Frame_3 * frameHeight;
			}
			else if (npc.frameCounter < 24)
			{
				npc.frame.Y = Frame_4 * frameHeight;
			}
			else if (npc.frameCounter < 30)
			{
				npc.frame.Y = Frame_5 * frameHeight;
			}
			else if (npc.frameCounter < 36)
			{
				npc.frame.Y = Frame_6 * frameHeight;
			}
			else if (npc.frameCounter < 42)
			{
				npc.frame.Y = Frame_7 * frameHeight;
			}
			else
			{
				npc.frameCounter = 0;
			}

		}	
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
			var effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(Main.npcTexture[npc.type], npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
							 drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
			return false;
		}
		public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			BTFAUtility.DrawNPCGlowMask(spriteBatch, npc, mod.GetTexture("NPCs/GhastlyEnt/Boss/Ghastly_Ent_Glow"));
		}	
		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.GreaterHealingPotion; //Applies to Bosses regardless of world difficulty- pre hm is always lesser, hm is always greater   
		}		
		public override void NPCLoot()
		{
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GhastlyEnt/GhastlyEntGore1"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GhastlyEnt/GhastlyEntGore2"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GhastlyEnt/GhastlyEntGore2"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GhastlyEnt/GhastlyEntGore3"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GhastlyEnt/GhastlyEntGore4"), 1f);
			TGEMWorld.downedGhastlyEnt = true;

			if (Main.expertMode)
			{
                npc.DropBossBags();
			}
			else
			{
			    switch (Main.rand.Next(6))
			    {
				    case 0: 
					    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("Fist_of_the_Hallow_Ent")));
					    break;
				    case 1: 
					    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("ForestBlast")));
					    break;
				    case 2: 
					    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("LeafScythe")));
					    break;
				    case 3: 
					    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("LivingTreeSword")));
					    break;
				    case 4: 
					    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("WoodChipper")));
					    break;
				    case 5: 
					    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("TreeStaff")));
					    break;
				    default:
					    break;
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("ForestEnergy")), Main.rand.Next(22, 35));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("BlossomBranch")), Main.rand.Next(5, 10));
			    TGEMWorld.TryForBossMask(npc.Center, npc.type);
				}
			}
		}
    }
}
