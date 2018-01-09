using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using System;

namespace ForgottenMemories.NPCs.GhastlyEnt
{
	public class SapSlime : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 60;
			npc.height = 48;
			npc.damage = 100;
			npc.defense = 28;
			npc.buffImmune[31] = true;
			npc.buffImmune[20] = true;
			npc.buffImmune[70] = true;
			npc.buffImmune[186] = true;;
			npc.lifeMax = 10000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 10000f;
			npc.knockBackResist = 0f;
			NPCID.Sets.TrailCacheLength[npc.type] = 10;
			NPCID.Sets.TrailingMode[npc.type] = 1;
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = 12000 + ((numPlayers) * 5000);
			npc.damage = 130;
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
				color26 = Microsoft.Xna.Framework.Color.Lerp(color26, Microsoft.Xna.Framework.Color.Orange, 0.5f);
				
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
			return true;
		}
		
		public override void AI()
        {
			npc.alpha -= 25;
			if (npc.alpha < 0)
				npc.alpha = 0;
		
			Player player = Main.player[npc.target];
			if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                npc.velocity.Y = 20;
				
				if (npc.timeLeft > 10)
				{
					npc.timeLeft = 10;
				}
            }
			npc.ai[0]++;
			npc.noTileCollide = false;
			npc.noGravity = false;
			npc.TargetClosest(true);
			Vector2 vector2 = (player.Center - npc.Center);
			vector2.Normalize();
			if (!Collision.CanHit(npc.Center, 1, 1, player.Center, 1, 1) || vector2.Length() >= 600)
			{
				npc.noTileCollide = true;
				npc.noGravity = true;
				npc.velocity = vector2 * 12;
			}
			else
			{
				if (npc.ai[0] <= 120 && npc.velocity.Y == 0)
				{
					Jump(player, 6);
				}
				if (120 < npc.ai[0] && npc.ai[0] <= 220 && npc.velocity.Y == 0)
				{
					Jump(player, 8);
				}
				if (220 < npc.ai[0] && npc.ai[0] <= 280 && npc.velocity.Y == 0)
				{
					npc.velocity.X *= 0.98f;
					int type = 0;
					switch (Main.rand.Next(2))
					{
						case 0: type = mod.ProjectileType("MiniSap");
							break;
						case 1: type = mod.ProjectileType("SapBall");
							break;
					}
					if (npc.ai[0] == 240 || npc.ai[0] == 260)
					{
						Shoot(player, type);
					}
				}
				if (npc.ai[0] >= 280 && npc.ai[0] <= 360)
				{
					GroundPound(player);
				}
				
				if (npc.ai[0] > 360)
				{
					npc.ai[0] = 0;
					npc.ai[1] = 0;
					npc.ai[2] = 0;
					npc.ai[3] = 0;
				}
			}
		}
		
		public void Jump (Player player, int vel)
		{
			npc.velocity.Y = -vel;
			npc.velocity.X = vel * npc.direction;
		}
		
		public void Shoot(Player player, int type)
		{
			for (int index = 0; index < 5; ++index)
			{
				Vector2 meem = new Vector2(index - 2, -2);
				meem.X = meem.X * (1f + (float) Main.rand.Next(-50, 51) * 0.0199999995529652f);
				meem.Y = meem.Y * (1f + (float) Main.rand.Next(-50, 51) * 0.0199999995529652f);
				meem.Normalize();
				meem = (meem * (float) (5.0 + (float) Main.rand.Next(-50, 51) * 0.00999999977648258f));
				int p = Projectile.NewProjectile((float) npc.Center.X, (float) npc.Center.Y, (float) meem.X, (float) meem.Y, type, (int)(npc.damage/4), 0.0f, Main.myPlayer, 0.0f, 0.0f);
				Main.PlaySound(SoundID.NPCHit1, npc.position);
				Main.projectile[p].netUpdate = true;
			}
		}
		
		public void GroundPound(Player player)
		{
			if (npc.ai[1] == 0)
			{
				npc.noTileCollide = true;
				npc.noGravity = true;
				npc.TargetClosest(true);
				Vector2 center = player.Center;
				center.Y -= 350f;
				Vector2 vector2_1 = (center - npc.Center);
				if ((double) Math.Abs((float) (npc.Center.X - Main.player[npc.target].Center.X)) < 40.0 && npc.Center.Y < Main.player[npc.target].Center.Y - 300.0)
				{
					npc.ai[1] = 1f;
				}
				else
				{
					vector2_1.Normalize();
					npc.velocity = (((npc.velocity * 5f)+ (vector2_1 * 12f))/ 6f);
				}
			}
			else
			{
				npc.ai[3]++;
				npc.knockBackResist = 0.0f;
				if ((double) npc.ai[2] == 0.0 && Collision.CanHit(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1) && !Collision.SolidCollision(npc.position, npc.width, npc.height))
					npc.ai[2] = 1;
				else if ((double) npc.ai[2] == 0.0)
				{
					npc.noTileCollide = true;
					npc.noGravity = true;
					npc.knockBackResist = 0.0f;
				}
				npc.velocity.Y += 0.2f;
				if (npc.velocity.Y <= 16.0)
					return;
				npc.velocity.Y = 16;
			}
		}
		
		public override void HitEffect(int hitDirection, double damage)
		{
			if(Main.rand.Next(3) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SmolSap"));
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Giant Sap Slime");
			Main.npcFrameCount[npc.type] = 2;
			animationType = NPCID.BlueSlime;
		}
	}
}
