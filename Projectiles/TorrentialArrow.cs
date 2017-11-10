using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class TorrentialArrow : ModProjectile
    {
		int timer = 0;
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 3;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10;
            //projectile.timeLeft = 600;
           // projectile.extraUpdates = 1;
            projectile.alpha = 0;
			projectile.tileCollide = true;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torrential Arrow");
		}
		
		
		public override void AI()
		{
			Dust dust1 = Main.dust[Dust.NewDust(projectile.Center, projectile.width, projectile.height, 33, 0.0f, 0.0f, 0, new Color(), 1.2f)];
			//dust1.fadeIn = 0.5f;
			dust1.noGravity = true;
		}
		
		public override bool OnTileCollide (Vector2 velocity1)
		{
			projectile.penetrate -= 1;
			
			if (projectile.penetrate == 0)
			{
				projectile.Kill();
			}
			
			else
			{
				
				Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
			}
			
			if ((double) projectile.velocity.Y != (double) velocity1.Y || (double) projectile.velocity.X != (double) velocity1.X)
                {
                  if ((double) projectile.velocity.X != (double) velocity1.X)
                    projectile.velocity.X = -velocity1.X;
                  if ((double) projectile.velocity.Y != (double) velocity1.Y)
                    projectile.velocity.Y = -velocity1.Y;
                }
			return false;
		}
		
		public override void Kill(int timeLeft)
		{
			
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 253);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.velocity = -projectile.oldVelocity;
			
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}
    }
}