using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class ForbiddenJavelin : ModProjectile
	{
		int timer = 5;
		float frick = 1f;
		bool reverse;
		public override void SetDefaults()
		{
			projectile.width = 11;
			projectile.height = 11;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 1000;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Forbidden Javelin");
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item14, projectile.position);
			projectile.position.X += (float) (projectile.width / 2);
			projectile.position.Y += (float) (projectile.height / 2);
			projectile.width = (int) (128.0 * (double) projectile.scale);
			projectile.height = (int) (128.0 * (double) projectile.scale);
			projectile.position.X -= (float) (projectile.width / 2);
			projectile.position.Y -= (float) (projectile.height / 2);
			for (int index1 = 0; index1 < 16; ++index1)
			{
			  int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 57, 0.0f, 0.0f, 100, new Color(), 2.5f);
			  Main.dust[index2].noGravity = true;
			  Main.dust[index2].velocity *= 3f;
			}
			for (int index1 = 0; index1 < 16; ++index1)
			{
			  int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 32, 0.0f, 0.0f, 100, new Color(), 2.5f);
			  Main.dust[index2].noGravity = true;
			  Main.dust[index2].velocity *= 3f;
			}
			for (int index1 = 0; index1 < 2; ++index1)
			{
			  int index2 = Gore.NewGore(projectile.position + new Vector2((float) (projectile.width * Main.rand.Next(100)) / 100f, (float) (projectile.height * Main.rand.Next(100)) / 100f) - Vector2.One * 10f, new Vector2(), Main.rand.Next(61, 64), 1f);
			  Main.gore[index2].velocity *= 0.3f;
			  Main.gore[index2].velocity.X += (float) Main.rand.Next(-10, 11) * 0.05f;
			  Main.gore[index2].velocity.Y += (float) Main.rand.Next(-10, 11) * 0.05f;
			}
			if (projectile.owner == Main.myPlayer)
			{
			  projectile.localAI[1] = -1f;
			  projectile.maxPenetrate = 0;
			  projectile.Damage();
			}
			if (Main.rand.Next(5) == 0)
        	{
        		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("ForbiddenJavelin"));
        	}
		}
		
		public override void AI()
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust2 = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 32, 0f, 0f);
			}
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Microsoft.Xna.Framework.Color color25 = Lighting.GetColor((int)((double)projectile.position.X + (double)projectile.width * 0.5) / 16, (int)(((double)projectile.position.Y + (double)projectile.height * 0.5) / 16.0));
			color25 *= 0.35f;
			Texture2D texture2D3 = Main.projectileTexture[projectile.type];
			int num156 = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
			int y3 = num156 * projectile.frame;
			Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(0, y3, texture2D3.Width, num156);
			Vector2 origin2 = rectangle.Size() / 2f;
			if (timer >= 5)
			{
				if (!reverse)
				{
					frick += 0.1f;
				}
				else 
				{
					frick -= 0.1f;
				}
				timer = 0;
			}
			if (frick >= 1.5f)
			{
				reverse = true;
			}
			if (frick <= 1f)
			{
				reverse = false;
			}
			timer++;
			Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.position + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color25, projectile.rotation, origin2, frick, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.position + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), lightColor, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
	}
}