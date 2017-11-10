using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class RockShard : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 12;
			projectile.height = 14;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.ranged = true;
			projectile.penetrate = 2;
			projectile.alpha = 255;
			projectile.light = 0.5f;
			projectile.timeLeft = 40;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rock");
			aiType = ProjectileID.Bullet;
		}
		
		public override void AI()
		{
			projectile.rotation += 0.2f;
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 1);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, projectile.position);
		}
	}
}