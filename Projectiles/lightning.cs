using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.Utilities;

namespace ForgottenMemories.Projectiles
{
	public class lightning : ModProjectile
	{
		int SoundTimer;
		float ok;
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.penetrate = -1;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10;
			projectile.melee = true;
			//projectile.aiStyle = 88;
			projectile.friendly = true;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 20;
			projectile.alpha = 255;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.extraUpdates = 4;
			projectile.timeLeft = 600;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Doom Lightning");
		}
		
		public override bool? Colliding(Rectangle myRect, Rectangle targetRect)
		{
			for (int i = 0; i < projectile.oldPos.Length; i++)
			{
				if (projectile.oldPos[i].X == 0f && projectile.oldPos[i].Y == 0f)
				{
					break;
				}
				myRect.X = (int)projectile.oldPos[i].X;
				myRect.Y = (int)projectile.oldPos[i].Y;
				if (myRect.Intersects(targetRect))
				{
					return true;
				}
			}
			return false;
		}
		
		public override void AI()
		{
			if (projectile.position.Y > (double) projectile.ai[1])
				projectile.tileCollide = true;
			
			if (projectile.ai[0] == 0)
			{
				projectile.ai[0] = projectile.velocity.ToRotation();
			}
			SoundTimer++;
			if (SoundTimer >= 50)
			{
				if (Main.rand.Next(2) == 0)
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 93);
				
				SoundTimer = 0;
			}
			else
			{
				int num3 = projectile.frameCounter;
				projectile.frameCounter = num3 + 1;
				Lighting.AddLight(projectile.Center, 0.3f, 0.45f, 0.5f);
				if (projectile.velocity == Vector2.Zero)
				{
					if (projectile.frameCounter >= projectile.extraUpdates * 2)
					{
						projectile.frameCounter = 0;
						bool flag35 = true;
						for (int num854 = 1; num854 < projectile.oldPos.Length; num854 = num3 + 1)
						{
							if (projectile.oldPos[num854] != projectile.oldPos[0])
							{
								flag35 = false;
							}
							num3 = num854;
						}
						if (flag35)
						{
							projectile.Kill();
							return;
						}
					}
				}
				else if (projectile.frameCounter >= projectile.extraUpdates * 2)
				{
					projectile.frameCounter = 0;
					float num860 = projectile.velocity.Length();
					UnifiedRandom unifiedRandom = new UnifiedRandom((int)ok);
					int num861 = 0;
					Vector2 vector96 = -Vector2.UnitY;
					Vector2 vector97;
					do
					{
						int num862 = unifiedRandom.Next();
						ok = (float)num862;
						num862 %= 100;
						float f = (float)num862 / 100f * 6.28318548f;
						vector97 = f.ToRotationVector2();
						if (vector97.Y > 0f)
						{
							vector97.Y *= -1f;
						}
						bool flag36 = false;
						if (vector97.Y > -0.02f)
						{
							flag36 = true;
						}
						if (vector97.X * (float)(projectile.extraUpdates + 1) * 2f * num860 + projectile.localAI[0] > 40f)
						{
							flag36 = true;
						}
						if (vector97.X * (float)(projectile.extraUpdates + 1) * 2f * num860 + projectile.localAI[0] < -40f)
						{
							flag36 = true;
						}
						if (!flag36)
						{
							goto IL_260B5;
						}
						num3 = num861;
						num861 = num3 + 1;
					}
					while (num3 < 100);
						projectile.velocity = Vector2.Zero;
						projectile.localAI[1] = 1f;
					goto IL_260C1;
					IL_260B5:
					vector96 = vector97;
					IL_260C1:
					if (projectile.velocity != Vector2.Zero)
					{
						projectile.localAI[0] += vector96.X * (float)(projectile.extraUpdates + 1) * 2f * num860;
						projectile.velocity = vector96.RotatedBy((double)(projectile.ai[0] + 1.57079637f), default(Vector2)) * num860;
						projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
						return;
					}
				}
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("BlightFlame"), 500, false);
			if (projectile.localAI[1] < 1f)
			{
				projectile.localAI[1] += 2f;
				projectile.position += projectile.velocity;
				projectile.velocity = Vector2.Zero;
			}
			projectile.damage = 0;
			projectile.velocity *= 0;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (projectile.localAI[1] < 1f)
			{
				projectile.localAI[1] += 2f;
				projectile.position += projectile.velocity;
				projectile.velocity = Vector2.Zero;
			}
			return false;
		}
		
		public override void PostAI()
		{
			if (projectile.frameCounter == 0 || projectile.oldPos[0] == Vector2.Zero)
			{
				for (int num31 = projectile.oldPos.Length - 1; num31 > 0; num31--)
				{
					projectile.oldPos[num31] = projectile.oldPos[num31 - 1];
				}
				projectile.oldPos[0] = projectile.position;
				if (projectile.velocity == Vector2.Zero && projectile.type == 466)
				{
					float num32 = projectile.rotation + 1.57079637f + ((Main.rand.Next(2) == 1) ? -1f : 1f) * 1.57079637f;
					float num33 = (float)Main.rand.NextDouble() * 2f + 2f;
					Vector2 vector2 = new Vector2((float)Math.Cos((double)num32) * num33, (float)Math.Sin((double)num32) * num33);
					int num34 = Dust.NewDust(projectile.oldPos[projectile.oldPos.Length - 1], 0, 0, 229, vector2.X, vector2.Y, 0, default(Color), 1f);
					Main.dust[num34].noGravity = true;
					Main.dust[num34].scale = 1.7f;
				}
			}
		}
		
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(99, 38, 255, 255);
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Microsoft.Xna.Framework.Color color25 = Lighting.GetColor((int)((double)projectile.position.X + (double)projectile.width * 0.5) / 16, (int)(((double)projectile.position.Y + (double)projectile.height * 0.5) / 16.0));
			Vector2 end3 = projectile.position + new Vector2((float)projectile.width, (float)projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition;
			Texture2D tex4 = Main.extraTexture[33];
			projectile.GetAlpha(color25);
			Vector2 scale17 = new Vector2(projectile.scale) / 2f;
			int num43;
			for (int num297 = 0; num297 < 2; num297 = num43 + 1)
			{
				float num298 = (projectile.localAI[1] == -1f || projectile.localAI[1] == 1f) ? -0.2f : 0f;
				if (num297 == 0)
				{
					scale17 = new Vector2(projectile.scale) * (0.5f + num298);
					DelegateMethods.c_1 = new Microsoft.Xna.Framework.Color(99, 38, 255) * 0.5f;
				}
				else
				{
					scale17 = new Vector2(projectile.scale) * (0.3f + num298);
					DelegateMethods.c_1 = new Microsoft.Xna.Framework.Color(255, 255, 255, 0) * 0.5f;
				}
				DelegateMethods.f_1 = 1f;
				for (int num299 = projectile.oldPos.Length - 1; num299 > 0; num299 = num43 - 1)
				{
					if (!(projectile.oldPos[num299] == Vector2.Zero))
					{
						Vector2 start3 = projectile.oldPos[num299] + new Vector2((float)projectile.width, (float)projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition;
						Vector2 end4 = projectile.oldPos[num299 - 1] + new Vector2((float)projectile.width, (float)projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition;
						Utils.DrawLaser(Main.spriteBatch, tex4, start3, end4, scale17, new Utils.LaserLineFraming(DelegateMethods.LightningLaserDraw));
					}
					num43 = num299;
				}
				if (projectile.oldPos[0] != Vector2.Zero)
				{
					DelegateMethods.f_1 = 1f;
					Vector2 start4 = projectile.oldPos[0] + new Vector2((float)projectile.width, (float)projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition;
					Utils.DrawLaser(Main.spriteBatch, tex4, start4, end3, scale17, new Utils.LaserLineFraming(DelegateMethods.LightningLaserDraw));
				}
				num43 = num297;
			}
			return false;
		}
	}
}