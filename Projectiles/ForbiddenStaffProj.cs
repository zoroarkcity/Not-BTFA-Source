using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class ForbiddenStaffProj : ModProjectile
	{
		Vector2 gayvector = new Vector2(0f, -6f);
		float frick = 2f;
		bool reverse;
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Forbidden Staff");
		}
		
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			target.immune[projectile.owner] = 13;
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Microsoft.Xna.Framework.Color color25 = Color.White;
			Texture2D texture2D3 = Main.projectileTexture[projectile.type];
			int num156 = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
			int y3 = num156 * projectile.frame;
			Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(0, y3, texture2D3.Width, num156);
			Vector2 origin2 = rectangle.Size() / 2f;
			if (!reverse)
			{
				frick += 0.1f;
			}
			else 
			{
				frick -= 0.1f;
			}
			if (frick >= 5f)
			{
				reverse = true;
			}
			if (frick <= 1.9f)
			{
				reverse = false;
			}
			for (int i = 0; i < 8; ++i)
			{
				Main.spriteBatch.Draw(mod.GetTexture("Projectiles/ForbiddenStaffProj2"), projectile.position + (-gayvector.RotatedBy(MathHelper.ToRadians(45 * i)) * frick) + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color25, projectile.rotation, origin2, 1f, SpriteEffects.None, 0f);
			}
			Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.position + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Color.White, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			gayvector = gayvector.RotatedBy(System.Math.PI / 35);
			return false;
		}
		
		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("Forboom"), projectile.damage, 5f, projectile.owner);
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
		}
	}
}