using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles.GhastlyEnt
{
	public class GhastlyKnife : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 1000;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Timber Kunai");
		}
		
		public override void Kill(int timeLeft)
		{
			{ 
        	}
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 61, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			int amountOfProjectiles = Main.rand.Next(1, 4);
			
			for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-60, 61) * 0.1f;
					float sY = (float)Main.rand.Next(-60, 61) * 0.1f;
					int z = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, mod.ProjectileType("Woodchip"), projectile.damage / 3, 5f, projectile.owner);
					Main.projectile[z].ranged = false;
					Main.projectile[z].thrown = true;
				}
		    if (Main.rand.Next(3) == 0)
				{
					float sT = (float)Main.rand.Next(-60, 61) * 0.1f;
					float sD = (float)Main.rand.Next(-60, 61) * 0.1f;
					int r = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sT, sD, mod.ProjectileType("AcornSeedF"), projectile.damage / 2, 5f, projectile.owner);
					Main.projectile[r].ranged = false;
					Main.projectile[r].thrown = true;
				}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}		
		public override void AI()
		{
			if (projectile.velocity.X >= 0)
			{
				projectile.velocity.X -= 0.10f;
			}
			if (projectile.velocity.X <= 0)
			{
				projectile.velocity.X += 0.10f;
			}
			if (projectile.velocity.X == 0)
			{
				projectile.velocity.X -= 0f;
			}
			projectile.velocity.Y += 0.10f;
			if (Main.rand.Next(5) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 61, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}
	}
}