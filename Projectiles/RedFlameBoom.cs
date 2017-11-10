using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles {
	public class RedFlameBoom : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 100;
			projectile.height = 100;
			projectile.aiStyle = -1;
			projectile.penetrate = 5;
			projectile.melee = true;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.timeLeft = 3;
			projectile.tileCollide = false;
			projectile.light = 0.5f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Flames");
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 40; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 60);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
		}
		
		public override void AI()
		{
			if (Main.rand.Next(5) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 60, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}
	}
}	