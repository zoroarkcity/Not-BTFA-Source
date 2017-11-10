using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles 
{
	public class BBloodBoom : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 120;
			projectile.height = 120;
			projectile.aiStyle = -1;
			projectile.penetrate = 5;
			projectile.melee = true;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.timeLeft = 1;
			projectile.tileCollide = false;
			projectile.light = 0.5f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Corruption");
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 20; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 14);
				Main.dust[dust].scale = 2f;
				Main.dust[dust].noGravity = true;			
			}
		}
	}
}	