using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class GraniteBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 20;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
            projectile.extraUpdates = 1;
            projectile.alpha = 0;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Shot");
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 59);
				Main.dust[dust].scale = 2f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
		}


        public override void AI()
        {
            {
                int dust;
                dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 59, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                Main.dust[dust].scale = 0.5f;
				Main.dust[dust].noGravity = true;
            }
            {
                projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            }
        }
    }
}