using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class DevilKnife : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 26;
			projectile.height = 26;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = 2;
			//projectile.timeLeft = 1000;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Devil Knife");
		}
		
		public override void Kill(int timeLeft)
		{
			if (Main.rand.Next(3) == 0)
        	{
        		Item.NewItem((int)projectile.Center.X, (int)projectile.Center.Y, projectile.width, projectile.height, mod.ItemType("DevilKnife"));
        	}
			
			if (Main.rand.Next(2) == 0)
        	{
				Vector2 vector2 = (projectile.velocity / 2).RotatedBy(MathHelper.ToRadians(Main.rand.Next(-30, 30)));
        		Projectile.NewProjectile((float) projectile.Center.X, (float) projectile.Center.Y, vector2.X, vector2.Y, mod.ProjectileType("LivingFlame"), (int) ((double) projectile.damage * 0.75), projectile.knockBack, projectile.owner, 0.0f, 0.0f);
        	}
			
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
				int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 7);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 360, false);
			target.AddBuff(mod.BuffType("DevilsFlame"), 360, false);
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D3 = Main.projectileTexture[projectile.type];
			int num156 = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
			int y3 = num156 * projectile.frame;
			Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(0, y3, texture2D3.Width, num156);
			Vector2 origin2 = rectangle.Size() / 2f;
			Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.position + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), lightColor, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(mod.GetTexture("GlowMasks/DevilKnifeMask"), projectile.position + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Color.White, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
		
		public override void AI()
		{
			if (projectile.velocity.X >= 0)
			{
				projectile.velocity.X -= 0.15f;
			}
			if (projectile.velocity.X <= 0)
			{
				projectile.velocity.X += 0.15f;
			}
			if (projectile.velocity.X == 0)
			{
				projectile.velocity.X -= 0f;
			}
			projectile.velocity.Y += 0.15f;
			if (Main.rand.Next(5) == 0)
			{
				int dust2 = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 6, 0f, 0f);
			}
		}
	}
}