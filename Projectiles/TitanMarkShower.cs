using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class TitanMarkShower : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titan Mark Shower");
			Main.projFrames[projectile.type] = 2;
		}

		public override void SetDefaults()
		{
			projectile.width = 102;
            projectile.height = 102;
			projectile.timeLeft = 200;
			projectile.penetrate = -1;
			projectile.hostile = true;
		}

        public override bool CanHitPlayer(Player target)
        {
            return false;
        }

		public void RainMeteors()
		{
			int type = mod.ProjectileType("BallMeteor");

            for (int i = 0; i < 3; i++)
            {
                Vector2 offset = new Vector2((float) Main.rand.Next(-300, 301), (float) Main.rand.Next(-1000, -701));
                Vector2 spawnPosition = projectile.Center + offset;
                spawnPosition.Y -= (float) (100 * i);

                Vector2 velocity = Vector2.Subtract(projectile.Center, spawnPosition);
                if (velocity.Y < 0f) //always goes down
                    velocity.Y *= -1f;
                if (velocity.Y < 20f) //always at least 20
                    velocity.Y = 20f;
                velocity.Normalize();
                velocity *= 8.5f;

                float velX = velocity.X;
                float velY = velocity.Y + (float) Main.rand.Next(-40, 41) * 0.02f;

                Projectile.NewProjectile(spawnPosition.X, spawnPosition.Y, velX, velY, type, projectile.damage, 1, Main.myPlayer, 0f, projectile.Center.Y);
            }
		}

		public override void AI()
        {
            if (projectile.timeLeft <= 60)
            {
				projectile.frame = 0;

                if (projectile.timeLeft == 60 || projectile.timeLeft == 40 || projectile.timeLeft == 20)
				{
					RainMeteors();
				}
            }
			else
			{
				Player target = Main.player[(int) projectile.ai[0]];
				if (target.active && !target.dead)
					projectile.Center = target.Center;
				
				if (projectile.timeLeft % 15 == 0)
				{
					if (projectile.frame == 0)
						projectile.frame++;
					else
						projectile.frame--;
				}
			}
		}
	}
}
