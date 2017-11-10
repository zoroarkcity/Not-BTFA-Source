using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles.GhastlyEnt {
public class SapBallFriendly : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.width = 18;
		projectile.height = 30;
		projectile.penetrate = 1;
		projectile.hostile = false;
		projectile.friendly = true;
		projectile.melee = true;
		projectile.alpha = 0;
		projectile.aiStyle = 1;
	}
	
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corrosive Sap");	
			aiType = ProjectileID.Bullet;
		}
	
	
		public override void AI()
	{
		if (projectile.velocity.X >= 0)
		{
			projectile.velocity.X -= 0.05f;
		}
		if (projectile.velocity.X <= 0)
		{
			projectile.velocity.X += 0.05f;
		}
		projectile.velocity.Y += 0.1f;
		if (Main.rand.Next(3) == 0)
		{
			Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 64, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
		}
	}
	
		   public override void Kill(int timeLeft)
		{
			Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 1);
			int amountOfProjectiles = Main.rand.Next(1, 3);
			
			for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-60, 61) * 0.1f;
					float sY = (float)Main.rand.Next(-60, 61) * 0.1f;
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, mod.ProjectileType("MiniSapFriendly"), projectile.damage/3, 5f, projectile.owner);
				}
		}
	
}	
}