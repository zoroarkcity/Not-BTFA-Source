using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Spiritflame
{
	public class SpiritfireDagger : ModProjectile
	{
		Vector2 gayvector = new Vector2(0f, -5f);
		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 22;
			projectile.aiStyle = 1;
			projectile.thrown = true;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 2;
			projectile.tileCollide = true;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
			projectile.timeLeft = 360;
			projectile.light = 0.5f;
			//projectile.scale = 0.5f;
			//projectile.extraUpdates = 1;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spiritfire Dagger");
		}
		
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
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
			Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.position + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), lightColor, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(mod.GetTexture("GlowMasks/SpiritfireDagger"), projectile.position + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Color.White, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(mod.GetTexture("GlowMasks/SpiritfireDagger"), projectile.position + (gayvector * 1.5f) + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color25, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(mod.GetTexture("GlowMasks/SpiritfireDagger"), projectile.position + (-gayvector * 1.5f) + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color25, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			gayvector = gayvector.RotatedBy(System.Math.PI / 35);
			return false;
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 160);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
			if (Main.rand.Next(3) == 0)
        	{
        		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("SpiritfireDagger"));
        	}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			target.AddBuff(mod.BuffType("Spiritflame"), 180, false);
			Main.PlaySound(SoundID.Item34, (int)projectile.position.X, (int)projectile.position.Y);
			Projectile.NewProjectile(projectile.Center, Vector2.Zero, mod.ProjectileType("SpiritflameBoom"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
		}
		
		public override bool OnTileCollide (Vector2 velocity1)
		{
			projectile.penetrate -= 1;
			
			if (projectile.penetrate == 0)
			{
				projectile.Kill();
			}
			
			Projectile.NewProjectile(projectile.Center, Vector2.Zero, mod.ProjectileType("SpiritflameBoom"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
			Main.PlaySound(SoundID.Item34, (int)projectile.position.X, (int)projectile.position.Y);
			
			if ((double) projectile.velocity.Y != (double) velocity1.Y || (double) projectile.velocity.X != (double) velocity1.X)
                {
                  if ((double) projectile.velocity.X != (double) velocity1.X)
                    projectile.velocity.X = -velocity1.X;
                  if ((double) projectile.velocity.Y != (double) velocity1.Y)
                    projectile.velocity.Y = -velocity1.Y;
                }
			return false;
		}
	}
}