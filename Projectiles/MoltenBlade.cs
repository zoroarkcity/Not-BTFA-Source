using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class MoltenBlade : ModProjectile
	{
		int a;
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
			projectile.tileCollide = false;
			projectile.timeLeft = 1000;
			projectile.light = 0.5f;
			projectile.scale = 1f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Molten Blade");
		}
		
		public override void AI()
		{
			if (a == 0)
			{
				float num = 16f;
				for (int index1 = 0; (double) index1 < (double) num; ++index1)
				{
					Vector2 v = (Vector2.UnitX * 0.0f + -Vector2.UnitY.RotatedBy((double) index1 * (6.28318548202515 / (double) num), new Vector2()) * new Vector2(1f, 4f)).RotatedBy((double) projectile.velocity.ToRotation(), new Vector2());
					int index2 = Dust.NewDust(projectile.Center, 0, 0, 6, 0.0f, 0.0f, 0, new Color(), 1f);
					Main.dust[index2].scale = 1.5f;
					Main.dust[index2].fadeIn = 1.3f;
					Main.dust[index2].noGravity = true;
					Main.dust[index2].position = projectile.Center + v;
					Main.dust[index2].velocity = projectile.velocity * 0.0f + v.SafeNormalize(Vector2.UnitY) * 1f;
				}
				a++;
			}
			if (projectile.timeLeft <= 990)
			{
				projectile.tileCollide = true;
			}
			if (Main.rand.Next(2) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 0.785f;
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
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
				int num157 = 8;
				int num158 = 2;
				int num159 = 1;
				float value3 = 1f;
				float num160 = 0f;
				
				{
					//num157 = 3;
					num158 = 1;
					value3 = 8f;
					//rectangle = new Microsoft.Xna.Framework.Rectangle(25 * projectile.frame, 0, 36, 14);
					origin2 = rectangle.Size() / 2f;
				}
				
				
				int num161 = num159;
				while ((num158 > 0 && num161 < num157) || (num158 < 0 && num161 > num157))
				{
					Microsoft.Xna.Framework.Color color26 = color25;
					color26 = projectile.GetAlpha(color26);		
					{
						goto IL_6899;
					}
					
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
					color26.A /= (byte)2;
					Main.spriteBatch.Draw(texture2D3, value4 + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color26, num165 + projectile.rotation * num160 * (float)(num161 - 1) * -(float)spriteEffects.HasFlag(SpriteEffects.FlipHorizontally).ToDirectionInt(), origin2, projectile.scale, effects, 0f);
					goto IL_6881;
				}
			}
			
			{
				Texture2D texture2D3 = Main.projectileTexture[projectile.type];
				int num156 = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
				int y3 = num156 * projectile.frame;
				Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(0, y3, texture2D3.Width, num156);
				Vector2 origin2 = rectangle.Size() / 2f;
				Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.position + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Color.White, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			}
			return false;
		}
		
		public override void Kill(int timeLeft)
		{
			int kms = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("hellboom"), projectile.damage, 5f, projectile.owner);
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(24, 180, false);
			target.AddBuff(mod.BuffType("DevilsFlame"), 180, false);
		}
	}
}