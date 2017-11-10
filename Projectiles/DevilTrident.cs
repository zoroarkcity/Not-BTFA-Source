using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class DevilTrident : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 27;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.light = 0.5f;
			projectile.alpha = (int) byte.MaxValue;
			projectile.friendly = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lucifer's Trident");
		}
		
		public override void AI()
		{
			int index = Dust.NewDust(new Vector2((float) projectile.position.X, (float) (projectile.position.Y + 4.0)), 8, 8, 6, (float) projectile.oldVelocity.X, (float) projectile.oldVelocity.Y, 100, new Color(), 0.6f);
            Dust dust = Main.dust[index];
            dust.velocity = (dust.velocity * -0.25f);
		}
		
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("DevilsFlame"), 360, false);
			target.AddBuff(24, 360, false);
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item10, projectile.position);
            for (int index1 = 4; index1 < 31; ++index1)
            {
				float num1 = (float) (projectile.oldVelocity.X * (30.0 / (double) index1));
				float num2 = (float) (projectile.oldVelocity.Y * (30.0 / (double) index1));
				int index2 = Dust.NewDust(new Vector2((float) projectile.position.X - num1, (float) projectile.position.Y - num2), 8, 8, 162, (float) projectile.oldVelocity.X, (float) projectile.oldVelocity.Y, 100, new Color(), 1.4f);
				Main.dust[index2].noGravity = true;
				Dust dust1 = Main.dust[index2];
				dust1.velocity = (dust1.velocity * 0.5f);
				int index3 = Dust.NewDust(new Vector2((float) projectile.position.X - num1, (float) projectile.position.Y - num2), 8, 8, 162, (float) projectile.oldVelocity.X, (float) projectile.oldVelocity.Y, 100, new Color(), 0.9f);
				Dust dust2 = Main.dust[index3];
				dust2.velocity = (dust2.velocity * 0.5f);
            }
			
			if (projectile.owner == Main.myPlayer)
			{
				Projectile.NewProjectile((float) projectile.Center.X, (float) projectile.Center.Y, 0.0f, 0.0f, mod.ProjectileType("Luciferno"), (int) ((double) projectile.damage * 0.75), projectile.knockBack, projectile.owner, 0.0f, 0.0f);
				for (int i = 0; i < Main.rand.Next(3) + 1; i++)
				{
					Vector2 vector2 = (-projectile.velocity).RotatedBy(MathHelper.ToRadians(Main.rand.Next(-30, 30)));
					Projectile.NewProjectile(projectile.Center, vector2, 295, (int) ((double) projectile.damage * 0.75), projectile.knockBack, projectile.owner, 0f, 0f);
				}
			}
		}
	}
}