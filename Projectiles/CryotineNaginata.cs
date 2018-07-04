using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class CryotineNaginata : ModProjectile
    {
    	
        public override void SetDefaults()
        {
			projectile.CloneDefaults(699);
			projectile.usesIDStaticNPCImmunity = false;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cryotine Naginata");
		}
		
		public override bool? Colliding(Rectangle myRect, Rectangle targetRect)
		{
			float f2 = projectile.rotation - 0.7853982f * (float)Math.Sign(projectile.velocity.X) + ((projectile.spriteDirection == -1) ? 3.14159274f : 0f);
			float num4 = 0f;
			float scaleFactor = -95f;
			if (Collision.CheckAABBvLineCollision(targetRect.TopLeft(), targetRect.Size(), projectile.Center, projectile.Center + f2.ToRotationVector2() * scaleFactor, 23f * projectile.scale, ref num4))
			{
				return true;
			}
			return false;
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
				Main.spriteBatch.Draw(texture2D3, value4 + projectile.Size / 2f - Main.screenPosition - new Vector2(58, -60).RotatedBy(projectile.rotation) + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color26, num165 + projectile.rotation * num160 * (float)(num161 - 1) * -(float)spriteEffects.HasFlag(SpriteEffects.FlipHorizontally).ToDirectionInt(), origin2, projectile.scale, effects, 0f);
				goto IL_6881;
			}
					
			Microsoft.Xna.Framework.Color color29 = projectile.GetAlpha(color25);
			Main.spriteBatch.Draw(texture2D3, projectile.Center - Main.screenPosition - new Vector2(58, -60).RotatedBy(projectile.rotation) + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color29, projectile.rotation, origin2, projectile.scale, spriteEffects, 0f);
			return false;
		}

        public override void AI()
        {
        	Player player = Main.player[projectile.owner];
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			projectile.direction = player.direction;
			player.heldProj = projectile.whoAmI;
			projectile.Center = vector;
			if (player.dead)
			{
				projectile.Kill();
				return;
			}
			if (!player.frozen)
			{
				projectile.spriteDirection = (projectile.direction = player.direction);
				projectile.alpha -= 127;
				if (projectile.alpha < 0)
				{
					projectile.alpha = 0;
				}
				if (projectile.localAI[0] > 0f)
				{
					projectile.localAI[0] -= 1f;
				}
				float num = (float)player.itemAnimation / (float)player.itemAnimationMax;
				float num2 = 1f - num;
				float num3 = projectile.velocity.ToRotation();
				float num4 = projectile.velocity.Length();
				float num5 = 22f;
				Vector2 value = new Vector2(1f, 0f).RotatedBy((double)(3.14159274f + num2 * 6.28318548f), default(Vector2));
				Vector2 spinningpoint = value * new Vector2(num4, projectile.ai[0]);
				projectile.position += spinningpoint.RotatedBy((double)num3, default(Vector2)) + new Vector2(num4 + num5, 0f).RotatedBy((double)num3, default(Vector2));
				Vector2 destination = vector + spinningpoint.RotatedBy((double)num3, default(Vector2)) + new Vector2(num4 + num5 + 40f, 0f).RotatedBy((double)num3, default(Vector2));
				projectile.rotation = player.AngleTo(destination) + 0.7853982f * (float)player.direction;
				if (projectile.spriteDirection == -1)
				{
					projectile.rotation += MathHelper.Pi/2;
				}
				player.DirectionTo(projectile.Center);
				Vector2 value2 = player.DirectionTo(destination);
				Vector2 vector2 = projectile.velocity.SafeNormalize(Vector2.UnitY);
				float num6 = 2f;
				int num7 = 0;
				while ((float)num7 < num6)
				{
					Dust dust = Dust.NewDustDirect(projectile.Center, 14, 14, 135, 0f, 0f, 110, default(Color), 1f);
					dust.velocity = player.DirectionTo(dust.position) * 2f;
					dust.position = projectile.Center + vector2.RotatedBy((double)(num2 * 6.28318548f * 2f + (float)num7 / num6 * 6.28318548f), default(Vector2)) * 10f;
					dust.scale = 1f + 0.6f * Main.rand.NextFloat();
					dust.velocity += vector2 * 3f;
					dust.noGravity = true;
					num7++;
				}
				for (int i = 0; i < 1; i++)
				{
					if (Main.rand.Next(3) == 0)
					{
						Dust dust2 = Dust.NewDustDirect(projectile.Center, 20, 20, 135, 0f, 0f, 110, default(Color), 1f);
						dust2.velocity = player.DirectionTo(dust2.position) * 2f;
						dust2.position = projectile.Center + value2 * -110f;
						dust2.scale = 0.45f + 0.4f * Main.rand.NextFloat();
						dust2.fadeIn = 0.7f + 0.4f * Main.rand.NextFloat();
						dust2.noGravity = true;
						dust2.noLight = true;
					}
				}
			}
			if (player.itemAnimation == 2)
			{
				projectile.Kill();
				player.reuseDelay = 2;
			}
        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Frostburn, (60 * Main.rand.Next(1, 4)), false);
			target.AddBuff(mod.BuffType("Frozen"), 60, false);
		}
    }
}