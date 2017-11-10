using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class ShinyEnergy : ModProjectile
    {
		int dustcounter = 0;
        public override void SetDefaults()
        {
            projectile.hostile = false;
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = -1;
            projectile.friendly = true;
			projectile.tileCollide = false;
            projectile.penetrate = 1;
            projectile.alpha = 255;
            projectile.timeLeft = 300;

        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shiny Energy");
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("ShinyBoom"), damage, knockback, projectile.owner);
		}

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 43);
        }

        public override void AI()
        {
			
			for (int index1 = 0; index1 < 5; ++index1)
			{
				float num1 = projectile.velocity.X / 3f * (float) index1;
				float num2 = projectile.velocity.Y / 3f * (float) index1;
				int num3 = 4;
				int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, 55, 0.0f, 0.0f, 200, default(Color), 1.2f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 0.1f;
				Main.dust[index2].velocity += projectile.velocity * 0.1f;
				Main.dust[index2].position.X -= num1;
				Main.dust[index2].position.Y -= num2;
			}
			if (Main.rand.Next(5) == 0)
			{
				int num = 4;
				int index = Dust.NewDust(new Vector2(projectile.position.X + (float) num, projectile.position.Y + (float) num), projectile.width - num * 2, projectile.height - num * 2, 55, 0.0f, 0.0f, 200, default(Color), 0.6f);
				Main.dust[index].velocity *= 0.25f;
				Main.dust[index].velocity += projectile.velocity * 0.5f;
			}
			
			float num940 = 0f + (float)Main.rand.Next(-2,2);
			float num941 = 0f + (float)Main.rand.Next(-2,2);
			if (Main.rand.Next(60) == 0)
			{
				projectile.velocity.X = projectile.velocity.X + 0.1f * num941;
				projectile.velocity.Y = projectile.velocity.Y + 0.1f * num940;
			}
			if (Main.rand.Next(60) == 0)
			{
				projectile.velocity.X = projectile.velocity.X - 0.1f * num941;
				projectile.velocity.Y = projectile.velocity.Y - 0.1f * num940;
			}
            Vector2 targetPos = projectile.Center;
            float targetDist = 1000f;
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
