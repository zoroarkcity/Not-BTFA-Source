using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class GraniteEnergy : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 4;
			projectile.height = 4;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 1;
			projectile.magic = true;
			projectile.alpha = 255;
			projectile.timeLeft = 360;
			projectile.extraUpdates = 1;
			projectile.light = 0.5f;
			projectile.scale = 1.2f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Energy");
		}
		
		public override void AI()
		{
			for (int index1 = 0; index1 < 5; ++index1)
			{
				float num1 = projectile.velocity.X / 3f * (float) index1;
				float num2 = projectile.velocity.Y / 3f * (float) index1;
				int num3 = 4;
				int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, 226, 0.0f, 0.0f, 0, new Color(), 1f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 0.1f;
				Main.dust[index2].velocity += projectile.velocity * 0.1f;
				Main.dust[index2].position.X -= num1;
				Main.dust[index2].position.Y -= num2;
			}
			
						
			Vector2 targetPos = projectile.Center;
            float targetDist = 350f;
            bool targetAcquired = false;
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

            if (targetAcquired && projectile.friendly)
            {
                float homingSpeedFactor = 6f;
                Vector2 homingVect = targetPos - projectile.Center;
                float dist = projectile.Distance(targetPos);
                dist = homingSpeedFactor / dist;
                homingVect *= dist;
                projectile.velocity = (projectile.velocity * 20 + homingVect) / 21f;
            }
		}
		
		public override bool OnTileCollide (Vector2 velocity1)
		{
			
			if (projectile.friendly && ((double) projectile.velocity.Y != (double) velocity1.Y || (double) projectile.velocity.X != (double) velocity1.X))
                {
                  if ((double) projectile.velocity.X != (double) velocity1.X)
                    projectile.velocity.X = -velocity1.X;
                  if ((double) projectile.velocity.Y != (double) velocity1.Y)
                    projectile.velocity.Y = -velocity1.Y;
                }
			else
			{
				return true;
			}
			return false;
		}
	}
}