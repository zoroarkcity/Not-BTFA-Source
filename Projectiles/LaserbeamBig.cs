using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Enums;
using System;

namespace ForgottenMemories.Projectiles
{
	public class LaserbeamBig : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			//projectile.aiStyle = 84;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.alpha = 255;
			projectile.tileCollide = false;
			projectile.hide = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laser");
			Main.projFrames[projectile.type] = 3;
		}
		
		public override void CutTiles()
		{
			DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
			Utils.PlotTileLine(projectile.Center, projectile.Center + projectile.velocity * projectile.localAI[1], (float)projectile.width * projectile.scale, new Utils.PerLinePoint(DelegateMethods.CutTiles));
		}
		
		public override bool? CanCutTiles()
		{
			return true;
		}
		
		public override bool? Colliding(Rectangle myRect, Rectangle targetRect)
		{
			float num = 0f;
			if (Collision.CheckAABBvLineCollision(targetRect.TopLeft(), targetRect.Size(), projectile.Center, projectile.Center + projectile.velocity * projectile.localAI[1], 22f * projectile.scale, ref num))
			{
				return true;
			}
			return null;
		}
		
		public override void AI()
		{
			Vector2? vector77 = null;
			if (Main.projectile[(int)projectile.ai[1]].active && Main.projectile[(int)projectile.ai[1]].type == mod.ProjectileType("LaserbeamStaff"))
			{
				Vector2 value26 = Vector2.Normalize(Main.projectile[(int)projectile.ai[1]].velocity);
				projectile.position = Main.projectile[(int)projectile.ai[1]].Center + value26 * 16f - new Vector2((float)projectile.width, (float)projectile.height) / 2f + new Vector2(0f, -Main.projectile[(int)projectile.ai[1]].gfxOffY);
				projectile.velocity = Vector2.Normalize(Main.projectile[(int)projectile.ai[1]].velocity);
			}
			else
			{
				projectile.Kill();
			}
			if (projectile.velocity.HasNaNs() || projectile.velocity == Vector2.Zero)
			{
				projectile.velocity = -Vector2.UnitY;
			}
			
			projectile.ai[0] += 1f;
			if (projectile.ai[0] >= 300f)
			{
				projectile.Kill();
				return;
			}
			projectile.scale = (float)Math.Sin((double)(projectile.ai[0] * 3.14159274f / 300f)) * 10f;
			if (projectile.scale > 1f)
			{
				projectile.scale = 1f;
			}
			
			float num803 = projectile.velocity.ToRotation();
			projectile.rotation = num803 - 1.57079637f;
			projectile.velocity = num803.ToRotationVector2();
			float num804 = 0f;
			float num805 = 0f;
			Vector2 samplingPoint = projectile.Center;
			if (vector77.HasValue)
			{
				samplingPoint = vector77.Value;
			}
			
			num804 = 2f;
			num805 = 0f;
			
			float[] array3 = new float[(int)num804];
			Collision.LaserScan(samplingPoint, projectile.velocity, num805 * projectile.scale, 2400f, array3);
			float num806 = 0f;
			int num3;
			for (int num807 = 0; num807 < array3.Length; num807 = num3 + 1)
			{
				num806 += array3[num807];
				num3 = num807;
			}
			num806 /= num804;
			float amount = 0.5f;
			projectile.localAI[1] = MathHelper.Lerp(projectile.localAI[1], num806, amount);
			Vector2 vector82 = projectile.Center + projectile.velocity * (projectile.localAI[1] - 8f);
			for (int num818 = 0; num818 < 2; num818 = num3 + 1)
			{
				float num819 = projectile.velocity.ToRotation() + ((Main.rand.Next(2) == 1) ? -1f : 1f) * 1.57079637f;
				float num820 = (float)Main.rand.NextDouble() * 0.8f + 1f;
				Vector2 vector83 = new Vector2((float)Math.Cos((double)num819) * num820, (float)Math.Sin((double)num819) * num820);
				int num821 = Dust.NewDust(vector82, 0, 0, 130, vector83.X, vector83.Y, 0, default(Color), 1f);
				Main.dust[num821].noGravity = true;
				Main.dust[num821].scale = 1.2f;
				num3 = num818;
			}
			if (Main.rand.Next(5) == 0)
			{
				Vector2 value31 = projectile.velocity.RotatedBy(1.5707963705062866, default(Vector2)) * ((float)Main.rand.NextDouble() - 0.5f) * (float)projectile.width;
				int num822 = Dust.NewDust(vector82 + value31 - Vector2.One * 4f, 8, 8, 130, 0f, 0f, 100, default(Color), 1.5f);
				Dust dust3 = Main.dust[num822];
				dust3.velocity *= 0.5f;
				Main.dust[num822].velocity.Y = -Math.Abs(Main.dust[num822].velocity.Y);
			}
			DelegateMethods.v3_1 = new Vector3(0.4f, 0.85f, 0.9f);
			Utils.PlotTileLine(projectile.Center, projectile.Center + projectile.velocity * projectile.localAI[1], (float)projectile.width * projectile.scale, new Utils.PerLinePoint(DelegateMethods.CastLight));
			
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			//if (projectile.velocity == Vector2.Zero)
			//{
			//	return;
			//}
			Texture2D texture2D22 = Main.projectileTexture[projectile.type];
			float num230 = projectile.localAI[1];
			Microsoft.Xna.Framework.Color color45 = new Microsoft.Xna.Framework.Color(255, 255, 255, 0) * 0.9f;
			Microsoft.Xna.Framework.Rectangle rectangle8 = new Microsoft.Xna.Framework.Rectangle(0, 0, texture2D22.Width, 22);
			Vector2 value21 = new Vector2(0f, Main.player[projectile.owner].gfxOffY);
			Main.spriteBatch.Draw(texture2D22, projectile.Center.Floor() - Main.screenPosition + value21, new Microsoft.Xna.Framework.Rectangle?(rectangle8), color45, projectile.rotation, rectangle8.Size() / 2f, projectile.scale, SpriteEffects.None, 0f);
			num230 -= 33f * projectile.scale;
			Vector2 value22 = projectile.Center.Floor();
			value22 += projectile.velocity * projectile.scale * 10.5f;
			rectangle8 = new Microsoft.Xna.Framework.Rectangle(0, 25, texture2D22.Width, 28);
			if (num230 > 0f)
			{
				float num231 = 0f;
				while (num231 + 1f < num230)
				{
					if (num230 - num231 < (float)rectangle8.Height)
					{
						rectangle8.Height = (int)(num230 - num231);
					}
					Main.spriteBatch.Draw(texture2D22, value22 - Main.screenPosition + value21, new Microsoft.Xna.Framework.Rectangle?(rectangle8), color45, projectile.rotation, new Vector2((float)(rectangle8.Width / 2), 0f), projectile.scale, SpriteEffects.None, 0f);
					num231 += (float)rectangle8.Height * projectile.scale;
					value22 += projectile.velocity * (float)rectangle8.Height * projectile.scale;
				}
			}
			rectangle8 = new Microsoft.Xna.Framework.Rectangle(0, 56, texture2D22.Width, 22);
			Main.spriteBatch.Draw(texture2D22, value22 - Main.screenPosition + value21, new Microsoft.Xna.Framework.Rectangle?(rectangle8), color45, projectile.rotation, texture2D22.Frame(1, 1, 0, 0).Top(), projectile.scale, SpriteEffects.None, 0f);
			return true;
		}
	}
}