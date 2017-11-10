using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class Flambullet : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 1;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flambullet");
		}
		
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 127, 0f, 0f);
			Main.dust[dust].noGravity = true;
		}
		
		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X * -0.2f, projectile.velocity.Y * -0.2f, mod.ProjectileType("FlameBoom"), projectile.damage, 0f, projectile.owner, 0f, 0f);
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 34);
		}
	}
}