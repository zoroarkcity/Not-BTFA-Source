using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles 
{
	public class BlightBoomRange : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 100;
			projectile.height = 100;
			//projectile.aiStyle = 2;
			projectile.penetrate = -1;
			projectile.timeLeft = 10;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.tileCollide = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Fire");
		}

		public bool CanDamage()
		{
			if (projectile.ai[0] != 0f && projectile.ai[1] != 0f)
				return false;
			return true;
		}

		public override void AI()
		{
			for (int i = 0; i < 3; ++i)
			{
				int startRotation = Main.rand.Next(45);

				for (int j = 0; j < 8; j++)
				{
					Vector2 newVect = new Vector2(18f * projectile.scale, 0).RotatedBy(MathHelper.ToRadians(45 * j + startRotation));
					int dust = Dust.NewDust(projectile.Center, 0, 0, 173, newVect.X, newVect.Y);
					Main.dust[dust].scale = Main.rand.Next(20) * 0.1f;
					Main.dust[dust].noGravity = true;
				}
			}
		}

		public override void Kill(int timeLeft)
		{
			if (projectile.ai[0] != 0f && projectile.ai[1] != 0f)
			{
				Vector2 velocity = new Vector2(projectile.ai[0], projectile.ai[1]);
				velocity -= projectile.Center;
				velocity.Normalize();
				velocity *= 5;
				Vector2 Source = projectile.Center - velocity * 5;
				int p = Projectile.NewProjectile(Source.X, Source.Y, velocity.X, velocity.Y, mod.ProjectileType("BlightBeam"), projectile.damage, projectile.knockBack, projectile.owner);
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("BlightFlame"), 580, false);
		}
	}
}	