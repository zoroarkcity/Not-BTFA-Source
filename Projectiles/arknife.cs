using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class arknife : ModProjectile
	{
		bool dying = false;
		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 22;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 250;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
			projectile.extraUpdates = 1;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arknife");
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
			SpriteEffects spriteEffects = SpriteEffects.None;
			Microsoft.Xna.Framework.Color color25 = Lighting.GetColor((int)((double)projectile.position.X + (double)projectile.width * 0.5) / 16, (int)(((double)projectile.position.Y + (double)projectile.height * 0.5) / 16.0));
			Texture2D texture2D3 = Main.projectileTexture[projectile.type];
			int num156 = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
			int y3 = num156 * projectile.frame;
			Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(0, y3, texture2D3.Width, num156);
			Vector2 origin2 = rectangle.Size() / 2f;
			int arg_5ADA_0 = projectile.type;
			int arg_5AE7_0 = projectile.type;
			int arg_5AF4_0 = projectile.type;
			int num157 = 10;
			int num158 = 2;
			int num159 = 1;
			float value3 = 1f;
			float num160 = 0f;
			
			
			int num161 = num159;
			while ((num158 > 0 && num161 < num157) || (num158 < 0 && num161 > num157))
			{
				Microsoft.Xna.Framework.Color color26 = color25;
				color26 = projectile.GetAlpha(color26);		
				{
					goto IL_6899;
				}
				color26 = Microsoft.Xna.Framework.Color.Lerp(color26, Microsoft.Xna.Framework.Color.Blue, 0.5f);
				
				IL_6881:
				num161 += num158;
				continue;
				IL_6899:
				float num164 = (float)(num157 - num161);
				if (num158 < 0)
				{
					num164 = (float)(num159 - num161);
				}
				color26 *= num164 / ((float)ProjectileID.Sets.TrailCacheLength[projectile.type] * 1.5f);
				Vector2 value4 = projectile.oldPos[num161];
				float num165 = projectile.rotation;
				SpriteEffects effects = spriteEffects;
				if (ProjectileID.Sets.TrailingMode[projectile.type] == 2)
				{
					num165 = projectile.oldRot[num161];
					effects = ((projectile.oldSpriteDirection[num161] == -1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None);
				}
				Main.spriteBatch.Draw(texture2D3, value4 + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color26, num165 + projectile.rotation * num160 * (float)(num161 - 1) * -(float)spriteEffects.HasFlag(SpriteEffects.FlipHorizontally).ToDirectionInt(), origin2, projectile.scale, effects, 0f);
				goto IL_6881;
			}
					
			Microsoft.Xna.Framework.Color color29 = projectile.GetAlpha(color25);
			Main.spriteBatch.Draw(texture2D3, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color29, projectile.rotation, origin2, projectile.scale, spriteEffects, 0f);
			return false;
		}
		

		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			if (Main.rand.Next(6) == 0 && projectile.alpha <= 200 && dying == false)
			{
				Vector2 vector2 = projectile.Center + Vector2.Normalize(projectile.velocity) * 10f;
				Dust dust1 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 20, 0.0f, 0.0f, 0, new Color(), 1f)];
				dust1.position = vector2;
				dust1.velocity = projectile.velocity.RotatedBy(1.57079637050629, new Vector2()) * 0.11f + projectile.velocity / 4f;
				dust1.position += projectile.velocity.RotatedBy(1.57079637050629, new Vector2());
				dust1.fadeIn = 0.5f;
				dust1.noGravity = true;
				Dust dust2 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 20, 0.0f, 0.0f, 0, new Color(), 1f)];
				dust2.position = vector2;
				dust2.velocity = projectile.velocity.RotatedBy(-1.57079637050629, new Vector2()) * 0.11f + projectile.velocity / 4f;
				dust2.position += projectile.velocity.RotatedBy(-1.57079637050629, new Vector2());
				dust2.fadeIn = 0.5f;
				dust2.noGravity = true;
				for (int index1 = 0; index1 < 1; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 20, 0.0f, 0.0f, 0, new Color(), 1f);
					Main.dust[index2].velocity *= 0.5f;
					Main.dust[index2].scale *= 1.3f;
					Main.dust[index2].fadeIn = 1f;
					Main.dust[index2].noGravity = true;
				}
			}
			projectile.alpha += 3;
			
			if (dying)
			{
				projectile.alpha += 10;
			}
			
			if (projectile.alpha >= 250)
			{
				projectile.Kill();
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (!dying)
			{
				dying = true;
				projectile.tileCollide = false;
				projectile.velocity.Y /= 2;
				projectile.velocity.X /= 2;
			}
			projectile.friendly = false;
		}
		
		public override bool OnTileCollide (Vector2 velocity1)
		{
			dying = true;
			projectile.tileCollide = false;
			projectile.velocity.Y = velocity1.Y / 2;
			projectile.velocity.X = velocity1.X / 2;
			return false;
		}
	}
}