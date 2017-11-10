using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles 
{
	public class BloodBoom : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 100;
			projectile.height = 100;
			projectile.aiStyle = -1;
			projectile.penetrate = 1;
			projectile.melee = true;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.timeLeft = 10;
			projectile.tileCollide = false;
			projectile.light = 0.5f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloody Execution");
		}
		
		public override bool PreAI()
		{
			int amountOfDust = 5;
			for (int i = 0; i < amountOfDust; ++i)
			{
				projectile.tileCollide = false;
				int dust;
				dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("BloodDust"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			return false;
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 5);
				Main.dust[dust].scale = 2f;
				Main.dust[dust].noGravity = true;			
			}
		}
	}
}	