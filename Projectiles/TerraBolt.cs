using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class TerraBolt	: ModProjectile
	{
		Vector2 vel;
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.ignoreWater = false;
			projectile.timeLeft = 1000;
			projectile.alpha = 255;
			projectile.scale = 0.33f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Terra Bolt");
		}
		
		public override void AI()
        {
			
			if (projectile.alpha > 0)
			{
				projectile.alpha -= 10;
			}
			if (projectile.alpha < 0)
			{
				projectile.alpha = 0;
			}
			
			if (projectile.alpha == 0)
			{
				int index1 = Dust.NewDust(new Vector2((float) (projectile.position.X - projectile.velocity.X * 4.0 + 2.0), (float) (projectile.position.Y + 2.0 - projectile.velocity.Y * 4.0)), 8, 8, 107, (float) projectile.oldVelocity.X, (float) projectile.oldVelocity.Y, 100, new Color(), 1.25f);
				Dust dust1 = Main.dust[index1];
				dust1.velocity = (dust1.velocity * -0.25f);
				int index2 = Dust.NewDust(new Vector2((float) (projectile.position.X - projectile.velocity.X * 4.0 + 2.0), (float) (projectile.position.Y + 2.0 - projectile.velocity.Y * 4.0)), 8, 8, 107, (float) projectile.oldVelocity.X, (float) projectile.oldVelocity.Y, 100, new Color(), 1.25f);
				Dust dust2 = Main.dust[index2];
				dust2.velocity = (dust2.velocity * -0.25f);
				Dust dust3 = Main.dust[index2];
				dust3.position = (dust3.position - (projectile.velocity * 0.5f));
			}
			
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			Lighting.AddLight((int) projectile.Center.X / 16, (int) projectile.Center.Y / 16, 0.8f, 0f, 0.9f);
			float num1 = 100f;
			float num2 = 3f;
			if ((double) projectile.ai[1] == 0.0)
			{
				projectile.localAI[0] += num2;
				vel = projectile.velocity;
				if ((double) projectile.localAI[0] > (double) num1)
					projectile.localAI[0] = num1;
			}
			else
			{
				projectile.localAI[0] -= num2;
				if ((double) projectile.localAI[0] <= 0.0)
				{
					projectile.Kill();
					return;
				}
			}
        }
		
		public override bool OnTileCollide(Vector2 OldVel)
		{
			projectile.ai[1]++;
			projectile.velocity = Vector2.Zero;
			return false;
		}
		
		public override bool? Colliding(Rectangle myRect, Rectangle targetRect)
		{
			float num11 = 0f;
			Vector2 lineStart = projectile.Center - (Vector2.Normalize(vel) * projectile.localAI[0] * 3);
			Vector2 lineEnd = projectile.Center;
			if (Collision.CheckAABBvLineCollision(targetRect.TopLeft(), targetRect.Size(), lineStart, lineEnd, projectile.scale, ref num11))
			{
				return true;
			}
			return false;
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Microsoft.Xna.Framework.Color color25 = Lighting.GetColor((int)((double)projectile.position.X + (double)projectile.width * 0.5) / 16, (int)(((double)projectile.position.Y + (double)projectile.height * 0.5) / 16.0));
			float num150 = (float)(Main.projectileTexture[projectile.type].Width - projectile.width) * 0.5f + (float)projectile.width * 0.5f;
			Microsoft.Xna.Framework.Rectangle value7 = new Microsoft.Xna.Framework.Rectangle((int)Main.screenPosition.X - 500, (int)Main.screenPosition.Y - 500, Main.screenWidth + 1000, Main.screenHeight + 1000);
			if (projectile.getRect().Intersects(value7))
			{
				Vector2 value8 = new Vector2(projectile.position.X - Main.screenPosition.X + num150, projectile.position.Y - Main.screenPosition.Y + (float)(projectile.height / 2) + projectile.gfxOffY);
				float num176 = 100f;
				float scaleFactor = 3f;
				if (projectile.ai[1] == 1f)
				{
					num176 = (float)((int)projectile.localAI[0]);
				}
				int num43;
				for (int num177 = 1; num177 <= (int)projectile.localAI[0]; num177 = num43 + 1)
				{
					Vector2 value9 = Vector2.Normalize(vel) * (float)num177 * scaleFactor;
					Microsoft.Xna.Framework.Color color32 = projectile.GetAlpha(color25);
					color32 *= (num176 - (float)num177) / num176;
					color32.A = 0;
					SpriteBatch arg_7727_0 = Main.spriteBatch;
					Texture2D arg_7727_1 = Main.projectileTexture[projectile.type];
					Vector2 arg_7727_2 = value8 - value9;
					Microsoft.Xna.Framework.Rectangle? sourceRectangle2 = null;
					float scale = projectile.scale;
					arg_7727_0.Draw(arg_7727_1, arg_7727_2, sourceRectangle2, color32, projectile.rotation, new Vector2(num150, (float)(projectile.height / 2)), scale, SpriteEffects.None, 0f);
					num43 = num177;
				}
			}
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 420, false);
			target.AddBuff(BuffID.Frostburn, 420, false);
			target.AddBuff(BuffID.CursedInferno, 420, false);
			target.AddBuff(153, 420, false);
			target.AddBuff(mod.BuffType("BlightInferno"), 420, false);
		}
	}
}