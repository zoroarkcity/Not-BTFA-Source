using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Utilities;
using Terraria.World.Generation;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Acheron
{
	[AutoloadBossHead]
    public class Acheron : ModNPC
    {
		Vector2 TPLocation;
		bool phase2;
		bool transitioned = false;
        bool willFireCurly = false;
		bool willGhostAtBarrier = true;
		int u, uu, uuu;

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 7000;
            npc.damage = 44;
            npc.defense = 0;
            npc.knockBackResist = 0f;
            npc.width = 98;
            npc.height = 112;
            npc.value = Item.buyPrice(0, 8, 0, 0);
			npc.buffImmune[31] = true;
			npc.buffImmune[20] = true;
			npc.buffImmune[70] = true;
			npc.buffImmune[186] = true;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.HitSound = SoundID.NPCHit49;
            npc.npcSlots = 15;
			NPCID.Sets.TrailCacheLength[npc.type] = 10;
			NPCID.Sets.TrailingMode[npc.type] = 1;
			music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/out");
			//music = MusicID.Boss3;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
			{
				npc.lifeMax = 8000 + ((numPlayers) * 2500);
				npc.damage = 96;
			}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Acheron");
			Main.npcFrameCount[npc.type] = 6;
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
			while (((num158 > 0 && num161 < num157) || (num158 < 0 && num161 > num157)))
			{
				Microsoft.Xna.Framework.Color color26 = color25;
				color26 = npc.GetAlpha(color26);		
				{
					goto IL_6899;
				}
				color26 = Microsoft.Xna.Framework.Color.Lerp(color26, Microsoft.Xna.Framework.Color.Blue, 0.5f);
				color26.A += (byte)(150);
				
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
				Main.spriteBatch.Draw(texture2D3, value4 + npc.Size / 2f - Main.screenPosition + new Vector2(15f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color26, num165 + npc.rotation * num160 * (float)(num161 - 1) * -(float)spriteEffects.HasFlag(SpriteEffects.FlipHorizontally).ToDirectionInt(), origin2, npc.scale, effects, 0f);
				Main.spriteBatch.Draw(texture2D3, value4 + npc.Size / 2f - Main.screenPosition + new Vector2(-15f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color26, num165 + npc.rotation * num160 * (float)(num161 - 1) * -(float)spriteEffects.HasFlag(SpriteEffects.FlipHorizontally).ToDirectionInt(), origin2, npc.scale, effects, 0f);
				goto IL_6881;
			}
			if (phase2)
			{
				Texture2D texture2D4 = mod.GetTexture("NPCs/Acheron/AcheronP2");
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
			var allahuakbar = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(Main.npcTexture[npc.type], npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
							 lightColor, npc.rotation, npc.frame.Size() / 2, npc.scale, allahuakbar, 0);
			return false;
		}
		
		public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			BTFAUtility.DrawNPCGlowMask(spriteBatch, npc, mod.GetTexture("NPCs/Acheron/Acheron_Glow"));
		}

		public void SpawnBarriers()
		{
			u = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + (int)(npc.height/2), mod.NPCType("AcheronBarrier"));
			uu = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + (int)(npc.height/2), mod.NPCType("AcheronBarrier"));
			uuu = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + (int)(npc.height/2), mod.NPCType("AcheronBarrier"));
			Main.npc[u].Center += new Vector2(0, 150);
			Main.npc[uu].Center += new Vector2(0, 150).RotatedBy(MathHelper.ToRadians(120));
			Main.npc[uuu].Center += new Vector2(0, 150).RotatedBy(MathHelper.ToRadians(240));
			Main.npc[u].ai[1] = npc.whoAmI;
			Main.npc[uu].ai[1] = npc.whoAmI;
			Main.npc[uuu].ai[1] = npc.whoAmI;
		}
		
        public override void AI()
        {
			npc.TargetClosest(true);
			npc.spriteDirection = npc.direction;
            Player player = Main.player[npc.target];
			if (npc.life < npc.lifeMax / 2)
			{
				phase2 = true;
				npc.ai[3]++;
			}
			
			if (!transitioned && phase2)
			{
				for (int index1 = 0; index1 < 5; ++index1)
				{
					int dust;
					Vector2 newVect = new Vector2 (8, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(45)));
					Vector2 newVect2 = newVect.RotatedBy(MathHelper.ToRadians(45));
					Vector2 newVect3 = newVect.RotatedBy(MathHelper.ToRadians(90));
					Vector2 newVect4 = newVect.RotatedBy(MathHelper.ToRadians(135));
					Vector2 newVect5 = newVect.RotatedBy(MathHelper.ToRadians(180));
					Vector2 newVect6 = newVect.RotatedBy(MathHelper.ToRadians(225));
					Vector2 newVect7 = newVect.RotatedBy(MathHelper.ToRadians(270));
					Vector2 newVect8 = newVect.RotatedBy(MathHelper.ToRadians(315));
					dust = Dust.NewDust(npc.Center, 0, 0, 20, newVect.X, newVect.Y);
					int dust2 = Dust.NewDust(npc.Center, 0, 0, 20, newVect2.X, newVect2.Y);
					int dust3 = Dust.NewDust(npc.Center, 0, 0, 20, newVect3.X, newVect3.Y);
					int dust4 = Dust.NewDust(npc.Center, 0, 0, 20, newVect4.X, newVect4.Y);
					int dust5 = Dust.NewDust(npc.Center, 0, 0, 20, newVect5.X, newVect5.Y);
					int dust6 = Dust.NewDust(npc.Center, 0, 0, 20, newVect6.X, newVect6.Y);
					int dust7 = Dust.NewDust(npc.Center, 0, 0, 20, newVect7.X, newVect7.Y);
					int dust8 = Dust.NewDust(npc.Center, 0, 0, 20, newVect8.X, newVect8.Y);
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

				if (Main.expertMode)
				{
					npc.defense = 28;
					SpawnBarriers();
				}
				else
					npc.defense = 12;

				Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
				transitioned = true;
			}
			
			npc.ai[0]++;
			
			if (npc.alpha > 255)
				npc.alpha = 255;
			
			if (npc.ai[0] < 120)
			{
				Move(player);
			}
			else if (npc.ai[0] < 135)
			{
				Teleport(player);
			}
			else if (npc.ai[0] < 180)
			{
				Souls(player);
			}
			else
			{
				npc.ai[0] = 0;
				npc.ai[2] = 0;
			}
			
			if (npc.ai[3] > 600 && phase2)
			{
				int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("SoulWell"), npc.damage / 3, 0, Main.myPlayer, 0, 0); //14.67
				if (Main.expertMode)
					Main.projectile[p].damage = npc.damage / 5; //19.2

				npc.ai[3] = 0;
				npc.netUpdate = true;
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
		
		public void Move(Player player)
		{
			npc.TargetClosest(true);
			Vector2 vector2;
			vector2 = new Vector2(npc.Center.X, npc.Center.Y);
			float num1 = (float) (player.Center.X - vector2.X);
			float num2 = (float) (player.Center.Y - vector2.Y);
			float num3 = 18f / (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
			float num4 = num1 * num3;
			float num5 = num2 * num3;
			npc.velocity.X = ((npc.velocity.X * 100f + (float) num4) / 101f);
			npc.velocity.Y = ((npc.velocity.Y * 100f + (float) num5) / 101f);
		}

		public void Teleport(Player player)
		{
			Vector2 vel = new Vector2(player.Center.X, player.Center.Y - 350) - npc.Center;
			vel.Normalize();
			vel *= 25;
			npc.velocity = vel;
			if (npc.ai[2] == 0)
			{
				int type = mod.NPCType("AcheronGhost");

				if (Main.expertMode && phase2 && willGhostAtBarrier)
				{
					int g1 = NPC.NewNPC((int)Main.npc[u].Center.X, (int)Main.npc[u].Center.Y, type);
					int g2 = NPC.NewNPC((int)Main.npc[uu].Center.X, (int)Main.npc[uu].Center.Y, type);
					int g3 = NPC.NewNPC((int)Main.npc[uuu].Center.X, (int)Main.npc[uuu].Center.Y, type);
					/*Main.npc[g1].damage = 113;
					Main.npc[g2].damage = 113;
					Main.npc[g3].damage = 113;*/
				}
				else
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, type);
				}

				npc.ai[2]++;
			}
		}

		public void Phase2Attack(Player player)
		{
			if (willFireCurly)
			{
				int p1 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("HomingSoulCurly"), npc.damage / 4, 1, Main.myPlayer, player.whoAmI, 1f); //11
				int p2 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("HomingSoulCurly"), npc.damage / 4, 1, Main.myPlayer, player.whoAmI, -1f); //11
				if (Main.expertMode)
				{
					Main.projectile[p1].damage = npc.damage / 5; //19.2
					Main.projectile[p2].damage = npc.damage / 5; //19.2
				}
			}
			else
			{
				Vector2 distance = Vector2.Subtract(player.Center, npc.Center); //always aims "head" of starburst at player
				double rotation = Math.Atan2((double) distance.Y, (double) distance.X);
				for (int index = 0; index < 5; index++)
				{
					Vector2 Vel = new Vector2(10, 0).RotatedBy(rotation + index * (2*MathHelper.Pi/5));
					int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Vel.X, Vel.Y, mod.ProjectileType("HomingSoul2"), npc.damage / 3, 1, Main.myPlayer, 0, 0); //14.67
					if (Main.expertMode)
						Main.projectile[p].damage = npc.damage / 5; //19.2
				}
			}
		}

		public void Souls(Player player)
		{
			npc.velocity = Vector2.Zero;
			if (!phase2 && (npc.ai[0] == 155 || npc.ai[0] == 160 || npc.ai[0] == 170))
			{
				Vector2 Position = new Vector2(npc.Center.X + (320 - 2*npc.ai[0]), npc.Center.Y);
				Vector2 Vel = player.Center - Position;
				Vel.Normalize();
				Vel *= 9.5f;
				Vel += player.velocity;
				int p = Projectile.NewProjectile(Position.X, Position.Y, Vel.X, Vel.Y, mod.ProjectileType("HomingSoul"), npc.damage / 4, 1, Main.myPlayer, 0, 0); //11
				if (Main.expertMode)
					Main.projectile[p].damage = npc.damage / 6; //16
			}
			else if (npc.ai[0] == 160)
			{
				Phase2Attack(player);

				if (Main.expertMode && npc.life <= npc.lifeMax / 10) //uses both attacks simultaneously at low health in expert
				{
					willFireCurly = !willFireCurly;
					Phase2Attack(player);
					willGhostAtBarrier = false; //immediately set to true after, always spawns three ghosts at once when near dead
				}

				willFireCurly = !willFireCurly;
				willGhostAtBarrier = !willGhostAtBarrier;
			}
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
			int u = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + (int)(npc.height/2), mod.NPCType("AcheronDeath"));
			Main.npc[u].frameCounter = npc.frameCounter;
		}
	}
}
