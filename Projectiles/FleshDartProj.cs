using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles {
    public class FleshDartProj : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.width = 14;
		projectile.height = 14;
		projectile.aiStyle = 1;
		projectile.penetrate = 1;
		projectile.ranged = true;
		projectile.friendly = true;
        projectile.timeLeft = 3000;
	}
	
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flesh Dart");
		}
		
	   public override void Kill(int timeLeft)
		{
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
			int amountOfProjectiles = Main.rand.Next(3, 5);
			
			for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-60, 61) * 0.3f;
					float sY = (float)Main.rand.Next(-60, 61) * 0.3f;
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, mod.ProjectileType("FleshBlood"), projectile.damage / 2, 5f, projectile.owner);
				}
		}
		
	}
	
	public class FleshBlood : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 5;
			projectile.height = 7;
			projectile.aiStyle = 1;
			projectile.penetrate = 1;
			projectile.ranged = true;
			projectile.friendly = true;
			projectile.timeLeft = 30;
			projectile.alpha = 255;
			projectile.extraUpdates = 5;
			
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flesh Dart");
		}
		
		public override void AI()
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 5, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
				
			}
		}
	}
}	