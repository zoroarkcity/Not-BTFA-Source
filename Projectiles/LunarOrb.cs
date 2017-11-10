using Microsoft.Xna.Framework.Graphics;
using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class LunarOrb : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.tileCollide = true;
			projectile.penetrate = 3;
			projectile.light = 0.5f;
			projectile.alpha = 0;
			projectile.timeLeft = 100;
			Main.projFrames[projectile.type] = 5;
			projectile.scale = 1f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lunar Bolt");
		}
		
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			projectile.frameCounter++;
			if (projectile.frameCounter >= 2)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			} 
			projectile.velocity *= 1.0125f;
			if (Main.rand.Next(6) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 226, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 0.5f;
				Main.dust[dust].noGravity = true;
			}
			
			Vector2 targetPos = projectile.Center;
            float targetDist = 450f;
            bool targetAcquired = false;
			for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].CanBeChasedBy(projectile))
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

            if (targetAcquired)
            {
                float homingSpeedFactor = 12f;
                Vector2 homingVect = targetPos - projectile.Center;
                float dist = projectile.Distance(targetPos);
                dist = homingSpeedFactor / dist;
                homingVect *= dist;

                projectile.velocity = (projectile.velocity * 20 + homingVect) / 21f;
				projectile.timeLeft++;
				projectile.tileCollide = false;
            }
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 10; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 226);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
	}
}