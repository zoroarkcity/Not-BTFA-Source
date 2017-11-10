using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class JungleBolt : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 150;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Forbidden Staff");
		}
		
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 39, 0f, 0f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			if (Main.rand.Next(5) == 0)
			{
				int dust2;
				dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 44, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust2].scale = 1.5f;
				Main.dust[dust2].noGravity = true;
			}
			if (Main.rand.Next(50) == 0)
			{
				Vector2 impact = projectile.Center;
				impact.X += Main.rand.Next(-30, 31);
				impact.Y += Main.rand.Next(-30, 31);
				int p = Projectile.NewProjectile(impact.X, impact.Y, 0f, 0f, 567 + Main.rand.Next(2), projectile.damage, 2f, projectile.owner);
				Main.projectile[p].magic = true;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i <= 2; i++)
			{
				Vector2 impact = projectile.Center;
				impact.X += Main.rand.Next(-120, 121);
				impact.Y += Main.rand.Next(-120, 121);
				int p = Projectile.NewProjectile(impact.X, impact.Y, 0f, 0f, 567 + Main.rand.Next(2), projectile.damage / 2, 2f, projectile.owner);
				Main.projectile[p].magic = true;
			}
		}
	}
}