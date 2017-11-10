using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Magic
{
    public class CosmodiumBolt2 : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.hostile = false;
            projectile.magic = true;
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.alpha = 255;
            projectile.timeLeft = 300;

        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmodium Bolt");
		}

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 43);
            for (int k = 0; k < 19; k++)
            {
               int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 242, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
                Main.dust[dust].scale = 2f;
            }
        }

        public override void AI()
        {
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 242, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].scale = 2f;
            Vector2 targetPos = projectile.Center;
            float targetDist = 350f;
            bool targetAcquired = false;

            //loop through first 200 NPCs in Main.npc
            //this loop finds the closest valid target NPC within the range of targetDist pixels
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].CanBeChasedBy(projectile) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[i].Center, 1, 1))
                {
                    float dist = projectile.Distance(Main.npc[i].Center);
                    if (dist < targetDist)
                    {
                        targetDist = dist;
                        targetPos = Main.npc[i].Center;
                        targetAcquired = true;
                    }
                }
            }

            //change trajectory to home in on target
            if (targetAcquired)
            {
                float homingSpeedFactor = 3f;
                Vector2 homingVect = targetPos - projectile.Center;
                float dist = projectile.Distance(targetPos);
                dist = homingSpeedFactor / dist;
                homingVect *= dist;

                projectile.velocity = (projectile.velocity * 20 + homingVect) / 21f;
            }
        }
    }

        
}
