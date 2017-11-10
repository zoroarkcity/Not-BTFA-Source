using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class CrystalBullet : ModProjectile
    {
		int bounce = 0;
        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 2;
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
			DisplayName.SetDefault("Prism Shot");
		}
		
		public override bool OnTileCollide (Vector2 velocity1)
		{
			
			if ((double) projectile.velocity.Y != (double) velocity1.Y || (double) projectile.velocity.X != (double) velocity1.X)
                {
                  if ((double) projectile.velocity.X != (double) velocity1.X)
                    projectile.velocity.X = -velocity1.X;
                  if ((double) projectile.velocity.Y != (double) velocity1.Y)
                    projectile.velocity.Y = -velocity1.Y;
                }
				
				int amountOfProjectiles = Main.rand.Next(2, 3);
			for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-60, 61) * 0.2f;
					float sY = (float)Main.rand.Next(-60, 61) * 0.2f;
					int p = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, 94, projectile.damage / 3, 0f, projectile.owner);
					Main.projectile[p].ranged = true;
					Main.projectile[p].magic = false;
					Main.projectile[p].timeLeft = 30;
					
				}
			bounce++;
			if (bounce >= 2)
			{
				return true;
			}
			return false;
		}
		
		public override void Kill(int timeLeft)
		{
			int amountOfProjectiles = Main.rand.Next(2, 3);
			for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-60, 61) * 0.2f;
					float sY = (float)Main.rand.Next(-60, 61) * 0.2f;
					int p = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, 94, projectile.damage / 2, 0f, projectile.owner);
					Main.projectile[p].ranged = true;
					Main.projectile[p].magic = false;
					Main.projectile[p].timeLeft = 30;
					
				}
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
		}


        public override void AI()
        {
            {
                int dust;
                dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 62, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                Main.dust[dust].scale = 0.4f;
				Main.dust[dust].noGravity = true;
            }
            {
                projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            }
        }
    }
}