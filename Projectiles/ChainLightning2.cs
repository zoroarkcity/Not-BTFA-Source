using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.Utilities;

namespace ForgottenMemories.Projectiles
{
	public class ChainLightning2 : ModProjectile
	{
		int SoundTimer;
		float ok;
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 20;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 600;
			projectile.extraUpdates = 4;
			projectile.alpha = 255;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (projectile.localAI[1] < 1f)
			{
				projectile.localAI[1] += 2f;
				projectile.position += projectile.velocity;
				projectile.velocity = Vector2.Zero;
			}
			projectile.damage = 0;
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
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lightning");
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
					DelegateMethods.c_1 = new Microsoft.Xna.Framework.Color(86, 255, 220) * 0.5f;
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
		
		public override void AI()
		{
			
			if (projectile.ai[0] == 0)
			{
				projectile.ai[0] = projectile.velocity.ToRotation();
			}
			
			if (projectile.localAI[1] == 0f && projectile.ai[0] >= 900f)
			{
				projectile.ai[0] -= 1000f;
				projectile.localAI[1] = -1f;
			}
			int num3 = projectile.frameCounter;
			projectile.frameCounter = num3 + 1;
			Lighting.AddLight(projectile.Center, 0.3f, 0.45f, 0.5f);
			if (projectile.velocity == Vector2.Zero)
			{
				if (projectile.frameCounter >= projectile.extraUpdates * 2)
				{
					projectile.frameCounter = 0;
					bool flag37 = true;
					for (int num863 = 1; num863 < projectile.oldPos.Length; num863 = num3 + 1)
					{
						if (projectile.oldPos[num863] != projectile.oldPos[0])
						{
							flag37 = false;
						}
						num3 = num863;
					}
					if (flag37)
					{
						projectile.Kill();
						return;
					}
				}
				if (Main.rand.Next(projectile.extraUpdates) == 0 && (projectile.velocity != Vector2.Zero || Main.rand.Next((projectile.localAI[1] == 2f) ? 2 : 6) == 0))
				{
					for (int num864 = 0; num864 < 2; num864 = num3 + 1)
					{
						float num865 = projectile.rotation + ((Main.rand.Next(2) == 1) ? -1f : 1f) * 1.57079637f;
						float num866 = (float)Main.rand.NextDouble() * 0.8f + 1f;
						Vector2 vector98 = new Vector2((float)Math.Cos((double)num865) * num866, (float)Math.Sin((double)num865) * num866);
						int num867 = Dust.NewDust(projectile.Center, 0, 0, 226, vector98.X, vector98.Y, 0, default(Color), 1f);
						Main.dust[num867].noGravity = true;
						Main.dust[num867].scale = 1.2f;
						num3 = num864;
					}
					if (Main.rand.Next(5) == 0)
					{
						Vector2 value40 = projectile.velocity.RotatedBy(1.5707963705062866, default(Vector2)) * ((float)Main.rand.NextDouble() - 0.5f) * (float)projectile.width;
						int num868 = Dust.NewDust(projectile.Center + value40 - Vector2.One * 4f, 8, 8, 31, 0f, 0f, 100, default(Color), 1.5f);
						Dust dust3 = Main.dust[num868];
						dust3.velocity *= 0.5f;
						Main.dust[num868].velocity.Y = -Math.Abs(Main.dust[num868].velocity.Y);
						return;
					}
				}
			}
			else if (projectile.frameCounter >= projectile.extraUpdates * 2)
			{
				projectile.frameCounter = 0;
				float num869 = projectile.velocity.Length();
				UnifiedRandom unifiedRandom2 = new UnifiedRandom((int)projectile.ai[1]);
				int num870 = 0;
				Vector2 vector99 = -Vector2.UnitY;
				Vector2 vector100;
				do
				{
					int num871 = unifiedRandom2.Next();
					projectile.ai[1] = (float)num871;
					num871 %= 100;
					float f2 = (float)num871 / 100f * 6.28318548f;
					vector100 = f2.ToRotationVector2();
					if (vector100.Y > 0f)
					{
						vector100.Y *= -1f;
					}
					bool flag38 = false;
					if (vector100.Y > -0.02f)
					{
						flag38 = true;
					}
					if (vector100.X * (float)(projectile.extraUpdates + 1) * 2f * num869 + projectile.localAI[0] > 40f)
					{
						flag38 = true;
					}
					if (vector100.X * (float)(projectile.extraUpdates + 1) * 2f * num869 + projectile.localAI[0] < -40f)
					{
						flag38 = true;
					}
					if (!flag38)
					{
						goto IL_26662;
					}
					num3 = num870;
					num870 = num3 + 1;
				}
				while (num3 < 100);
				projectile.velocity = Vector2.Zero;
				if (projectile.localAI[1] < 1f)
				{
					projectile.localAI[1] += 2f;
					goto IL_2666E;
				}
				goto IL_2666E;
				IL_26662:
				vector99 = vector100;
				IL_2666E:
				if (projectile.velocity != Vector2.Zero)
				{
					projectile.localAI[0] += vector99.X * (float)(projectile.extraUpdates + 1) * 2f * num869;
					projectile.velocity = vector99.RotatedBy((double)(projectile.ai[0] + 1.57079637f), default(Vector2)) * num869;
					projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
					if (Main.rand.Next(4) == 0 && Main.netMode != 1 && projectile.localAI[1] == 0f)
					{
						float num872 = (float)Main.rand.Next(-3, 4) * 1.04719758f / 3f;
						Vector2 vector101 = projectile.ai[0].ToRotationVector2().RotatedBy((double)num872, default(Vector2)) * projectile.velocity.Length();
						if (!Collision.CanHitLine(projectile.Center, 0, 0, projectile.Center + vector101 * 50f, 0, 0))
						{
							Projectile.NewProjectile(projectile.Center.X - vector101.X, projectile.Center.Y - vector101.Y, vector101.X, vector101.Y, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, vector101.ToRotation() + 1000f, projectile.ai[1]);
							return;
						}
					}
				}
			}
		}
	}
}