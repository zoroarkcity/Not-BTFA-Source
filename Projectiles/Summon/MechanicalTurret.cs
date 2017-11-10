using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Summon
{
    public class MechanicalTurret : ModProjectile
    {
        bool shot = false;
        public override void SetDefaults()
        {
			projectile.width = 50;
            projectile.height = 42;
            projectile.timeLeft = Projectile.SentryLifeTime;
			projectile.friendly = false;
			projectile.hostile = false;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
			projectile.sentry = true;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mechanical Turret");
			Main.projFrames[projectile.type] = 3;
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }

        public override void AI()
        {
            

            projectile.velocity.Y = 5;
            //CONFIG INFO
            int range = 30;   //How many tiles away the projectile targets NPCs
            float shootVelocity = 11f; //magnitude of the shoot vector (speed of arrows shot)
            int shootSpeed = 20;

            //TARGET NEAREST NPC WITHIN RANGE
            float lowestDist = float.MaxValue;
            for (int i = 0; i < 200; ++i)
            {
                NPC npc = Main.npc[i];
                //if npc is a valid target (active, not friendly, and not a critter)
                if (npc.active && npc.CanBeChasedBy(projectile) && Collision.CanHitLine(projectile.Center, 0, 0, npc.Center, 0, 0))
                {
                    //if npc is within 50 blocks
                    float dist = projectile.Distance(npc.Center);
                    if (dist / 16 < range)
                    {
                        //if npc is closer than closest found npc
                        if (dist < lowestDist)
                        {
                            lowestDist = dist;

                            //target this npc
                            projectile.ai[1] = npc.whoAmI;
                        }
                    }
                }
            }
            NPC target = (Main.npc[(int)projectile.ai[1]] ?? new NPC()); //our target
            //firing
            if (target.active && projectile.Distance(target.Center) / 16 < range)
            {
                projectile.frameCounter++;
                if (projectile.frameCounter >= 6)
                {
                    projectile.frame++;
                    projectile.frameCounter = 0;
                    if (projectile.frame > 2)
                    {
                        projectile.frame = 0;
                    }
                }
            }
            else
            {
                projectile.frame = 0;
            }
            if (projectile.frame == 0)
            {
                shot = false;
            }
            if (projectile.frame == 1 && target.active && projectile.Distance(target.Center) / 16 < range && !shot)
            {
                Vector2 ShootArea = new Vector2(projectile.Center.X, projectile.Center.Y);
                Vector2 direction = target.Center - ShootArea;
                if (direction.X > 0)
                {
                    projectile.spriteDirection = 1;
                }
                else
                {
                    projectile.spriteDirection = -1;
                }
                direction.Normalize();
                direction.X *= shootVelocity;
                direction.Y *= shootVelocity;
                int proj2 = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, direction.X, direction.Y, mod.ProjectileType("Nail"), projectile.damage, 0, Main.myPlayer);
                Main.PlaySound(2, projectile.Center, 11);  //make bow shooty sound
                shot = true;

            }
        }
    }
}