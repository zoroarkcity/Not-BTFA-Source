using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles.GhastlyEntBoss 
{
	public class RedApple : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 2;
			projectile.penetrate = 1;
			projectile.timeLeft = 300;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.scale = 1.2f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Apple");
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 7);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}
	}
}	