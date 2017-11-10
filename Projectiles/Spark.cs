using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles {
	public class Spark : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 0;
			projectile.penetrate = 1;
			projectile.melee = true;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.timeLeft = 80;
			projectile.tileCollide = false;
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
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 64);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 63);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
		
		public override void AI()
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 64, 0f, 0f);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].scale = 1.2f;
			}
			
			if (Main.rand.Next(2) == 0)
			{
				int dust2;
				dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 63, 0f, 0f);
				Main.dust[dust2].noGravity = true;
				Main.dust[dust2].scale = 1.2f;
			}
			
			projectile.velocity.X *= 0.96f;
			projectile.velocity.Y *= 0.96f;
		}
	}
}	