using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Acheron
{
	public class HomingSoulCurly : ModProjectile
	{
        //ai[0] holds target player ID
        //ai[1] is used to determine centerpoint offset and whether it rotates CW or CCW
        
        private Vector2 centerpoint = Vector2.Zero;
        private Vector2 lastPosition = Vector2.Zero; //used to simulate velocity for dust calcs
        private double radiusLength = 1;
        private bool hasSpawned = false;

        private float increment = (float)Math.PI / 90f;
        //denominator is equal to frames needed to rotate about 180 degrees
        
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lost Soul");
		}

		public override void SetDefaults()
		{
			projectile.width = 2;
            projectile.height = 2;
			projectile.timeLeft = 120;
			projectile.penetrate = -1;
			projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
		}

        private void MakeDust()
        {
            for (int index1 = 0; index1 < 5; ++index1)
            {
                Vector2 distance = Vector2.Subtract(projectile.Center, lastPosition);
                float num1 = distance.X / 3f * (float)index1;
                float num2 = distance.Y / 3f * (float)index1;
                int num3 = 4;
                int index2 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width - num3 * 2, projectile.height - num3 * 2, 20, 0.0f, 0.0f, 100, new Color(), 1.4f);
                Main.dust[index2].noGravity = true;
                Main.dust[index2].velocity *= 0.1f;
                Main.dust[index2].velocity += distance * 0.1f;
                Main.dust[index2].position.X -= num1;
                Main.dust[index2].position.Y -= num2;
                Main.dust[index2].scale = 1.1f;
            }
        }

		public override void AI()
        {
            if (!hasSpawned)
            {
                Player player = Main.player[(int)projectile.ai[0]];

                Vector2 distance = Vector2.Subtract(projectile.Center, player.Center);
                distance = Vector2.Multiply(distance, 0.5f);

                Vector2 distanceOrtho = new Vector2(-1 * distance.Y * projectile.ai[1], distance.X * projectile.ai[1]);

                centerpoint = Vector2.Add(player.Center, distance);
                centerpoint = Vector2.Add(centerpoint, distanceOrtho);

                Vector2 radius = Vector2.Subtract(projectile.Center, centerpoint);
                radiusLength = (double) radius.Length();

                projectile.rotation = (float) Math.Atan2((double) radius.Y, (double) radius.X);

                lastPosition = projectile.Center;

                hasSpawned = true;
            }
            else
            {
                projectile.position.X = centerpoint.X + (int) (radiusLength * Math.Cos(projectile.rotation)) - projectile.width / 2;
                projectile.position.Y = centerpoint.Y + (int) (radiusLength * Math.Sin(projectile.rotation)) - projectile.height / 2;
                projectile.rotation -= increment * projectile.ai[1];
            }

            MakeDust();
            lastPosition = projectile.Center;

            if (projectile.timeLeft < 60)
            {
                //slow down gradually before despawning
                increment *= 0.975f;
            }
		}

        public override void Kill(int timeLeft)
        {
            Player player = Main.player[(int)projectile.ai[0]];

            Vector2 Vel = player.Center - projectile.Center;
            Vel.Normalize();
            Vel *= 9.5f;
            Vel += player.velocity;
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Vel.X, Vel.Y, mod.ProjectileType("HomingSoul"), projectile.damage, 1, Main.myPlayer, 1f, 0);
        }
	}
}
