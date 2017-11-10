using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Utilities;

namespace ForgottenMemories.Projectiles
{
	public class Shadowmeme : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 4;
			projectile.height = 4;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 3;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;
			projectile.light = 0.5f;
			projectile.scale = 0.5f;
			projectile.timeLeft = 600;
			projectile.extraUpdates = 10;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadowbeam");
		}
		
		public override bool OnTileCollide(Vector2 velocity1)
		{
			if ((double) projectile.velocity.Y != (double) velocity1.Y || (double) projectile.velocity.X != (double) velocity1.X)
			{
			  if ((double) projectile.velocity.X != (double) velocity1.X)
				projectile.velocity.X = -velocity1.X;
			  if ((double) projectile.velocity.Y != (double) velocity1.Y)
				projectile.velocity.Y = -velocity1.Y;
			}
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.damage = (int)(projectile.damage * 1.1);
			
			int[] numArray = new int[10];
			int maxValue = 0;
			int num2 = 700;
			int num3 = 20;
			for (int index2 = 0; index2 < 200; ++index2)
			{
			  if (Main.npc[index2] != target && Main.npc[index2].CanBeChasedBy((object) this, false))
			  {
				float num4 = (projectile.Center - Main.npc[index2].Center).Length();
				if ((double) num4 > (double) num3 && (double) num4 < (double) num2 && Collision.CanHitLine(projectile.Center, 1, 1, Main.npc[index2].Center, 1, 1))
				{
				  numArray[maxValue] = index2;
				  ++maxValue;
				  if (maxValue >= 9)
					break;
				}
			  }
			}
			if (maxValue > 0)
			{
			  int index2 = Main.rand.Next(maxValue);
			  Vector2 vector2 = Main.npc[numArray[index2]].Center - projectile.Center;
			  float num4 = projectile.velocity.Length();
			  vector2.Normalize();
			  projectile.velocity = vector2 * num4;
			  projectile.netUpdate = true;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 20; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173);
				Main.dust[dust].scale = 2.5f;
				Main.dust[dust].noGravity = true;
			}
		}
		
		public override void AI()
		{
			if (projectile.ai[0] == 0)
			{
				projectile.ai[0] = projectile.velocity.ToRotation();
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
					UnifiedRandom unifiedRandom = new UnifiedRandom((int)projectile.ai[1]);
					int num861 = 0;
					Vector2 vector96 = -Vector2.UnitY;
					Vector2 vector97;
					do
					{
						int num862 = unifiedRandom.Next();
						projectile.ai[1] = (float)num862;
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
						//projectile.velocity = vector96.RotatedBy((double)(projectile.ai[0] + 1.57079637f), default(Vector2)) * num860;
						//projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
						return;
					}
				}
			}
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Microsoft.Xna.Framework.Color color25 = Lighting.GetColor((int)((double)projectile.position.X + (double)projectile.width * 0.5) / 16, (int)(((double)projectile.position.Y + (double)projectile.height * 0.5) / 16.0));
			Vector2 end3 = projectile.position + new Vector2((float)projectile.width, (float)projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition;
			Texture2D tex4 = Main.extraTexture[33];
			projectile.GetAlpha(color25);
			Vector2 scale17 = new Vector2(projectile.scale) / 8f;
			int num43;
			for (int num297 = 0; num297 < 2; num297 = num43 + 1)
			{
				float num298 = (projectile.localAI[1] == -1f || projectile.localAI[1] == 1f) ? -0.2f : 0f;
				if (num297 == 0)
				{
					scale17 = new Vector2(projectile.scale) * (0.5f + num298);
					DelegateMethods.c_1 = new Microsoft.Xna.Framework.Color(158, 22, 254) * 0.5f;
				}
				else
				{
					scale17 = new Vector2(projectile.scale) * (0.3f + num298);
					DelegateMethods.c_1 = new Microsoft.Xna.Framework.Color(228, 196, 255, 0) * 0.5f;
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
