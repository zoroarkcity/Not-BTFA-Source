using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles {
	public class ExplosiveSpark : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 0;
			projectile.penetrate = 2;
			projectile.melee = true;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.timeLeft = 80;
			projectile.tileCollide = true;
			projectile.light = 0.5f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spark");
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 137);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("SparkBoom"), 50, 5f, projectile.owner);
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
		}
		
		public override void AI()
		{

			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 137, 0f, 0f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].scale = 1.2f;
			projectile.velocity.X *= 0.96f;
			projectile.velocity.Y *= 0.96f;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.penetrate -= 1;;
		}
	}
}	