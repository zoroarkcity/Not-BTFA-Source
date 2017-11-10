using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class LaserBolt : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 200;
			projectile.alpha = 255;
			projectile.tileCollide = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laser");
		}
		
		public override void AI()
		{
			int num;
			for (int num164 = 0; num164 < 10; num164 = num + 1)
			{
				float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)num164;
				float y2 = projectile.position.Y - projectile.velocity.Y / 10f * (float)num164;
				int num165 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 60, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num165].position.X = x2;
				Main.dust[num165].position.Y = y2;
				Dust dust3 = Main.dust[num165];
				dust3.velocity *= 0f;
				Main.dust[num165].noGravity = true;
				num = num164;
			}
				
				
			Vector2 targetPos = projectile.Center;
            float targetDist = 350f;
            bool targetAcquired = false;
			
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].CanBeChasedBy(projectile) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[i].Center, 1, 1) && Main.npc[i].immune[projectile.owner] == 0)
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
                float homingSpeedFactor = 10f;
                Vector2 homingVect = targetPos - projectile.Center;
                float dist = projectile.Distance(targetPos);
                dist = homingSpeedFactor / dist;
                homingVect *= dist;

                projectile.velocity = (projectile.velocity * 20 + homingVect) / 21f;
            }
		}
	}
}