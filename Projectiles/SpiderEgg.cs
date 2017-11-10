using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class SpiderEgg : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 24;
			projectile.height = 26;
			projectile.aiStyle = 2;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 200;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spider Egg");
		}
		
		public override void AI()
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 65, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1f;
				Main.dust[dust].noGravity = true;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("SpiderWeb"), 50, 5f, projectile.owner);
		}
	}
}