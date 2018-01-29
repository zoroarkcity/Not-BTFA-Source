using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Acheron
{
    public class HomingThanatos : ModProjectile
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Homing Wisp");
        }
        public override void SetDefaults()
        {
            projectile.width = 36;  //Set the hitbox width
            projectile.height = 36;  //Set the hitbox height
            projectile.aiStyle = 1; //How the projectile works
            projectile.friendly = true;  //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.tileCollide = false; //Tells the game whether it is hostile to players or not
            projectile.melee = true;   //Tells the game whether it is a ranged projectile or not
            projectile.timeLeft = 180; //The amount of time the projectile is alive for
			projectile.extraUpdates = 1;
			projectile.scale = 1f;
            aiType = ProjectileID.Bullet;		
        }
        public override void AI()
        {
			
			Lighting.AddLight(projectile.position, 0f, 0.5f, 1f);
			if ((double) projectile.velocity.X < 0.0)
            {
                projectile.spriteDirection = -1;
                projectile.rotation = (float) Math.Atan2(-(double) projectile.velocity.Y, -(double) projectile.velocity.X);
            }
            else
            {
                projectile.spriteDirection = 1;
                projectile.rotation = (float) Math.Atan2((double) projectile.velocity.Y, (double) projectile.velocity.X);
            }
			if ((double) projectile.ai[0] >= 0.0 && (double) projectile.ai[0] < 200.0)
            {
                int index1 = (int) projectile.ai[0];
                if (Main.npc[index1].active && Main.npc[index1].friendly == false)
                {
                    float num1 = 8f;
                    Vector2 vector2 = new Vector2(projectile.position.X + (float) projectile.width * 0.5f, projectile.position.Y + (float) projectile.height * 0.5f);
                    float num2 = Main.npc[index1].position.X - vector2.X;
                    float num3 = Main.npc[index1].position.Y - vector2.Y;
                    float num4 = (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
                    float num5 = num1 / num4;
                    float num6 = num2 * num5;
                    float num7 = num3 * num5;
                    projectile.velocity.X = (float) (((double) projectile.velocity.X * 14.0 + (double) num6) / 15.0);
                    projectile.velocity.Y = (float) (((double) projectile.velocity.Y * 14.0 + (double) num7) / 15.0);
                }
                else
                {
                    float num1 = 400f;
                    for (int index2 = 0; index2 < 200; ++index2)
                    {
                        if (Main.npc[index2].CanBeChasedBy((object) projectile, false) && Main.npc[index2].friendly == false)
                        {
                            float num2 = Math.Abs(projectile.position.X + (float) (projectile.width / 2) - (Main.npc[index2].position.X + (float) (Main.npc[index2].width / 2))) + Math.Abs(projectile.position.Y + (float) (projectile.height / 2) - (Main.npc[index2].position.Y + (float) (Main.npc[index2].height / 2)));
                            if ((double) num2 < (double) num1 && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[index2].position, Main.npc[index2].width, Main.npc[index2].height))
                            {
                                num1 = num2;
                                projectile.ai[0] = (float) index2;
                            }
                        }
                    }
                }
                if (Main.rand.Next(4) == 0)
                {
                    int index = Dust.NewDust(projectile.Center, 8, 8, 111, 0.0f, 0.0f, 0, new Color(), 1f);
                    Main.dust[index].position = projectile.Center;
                    Main.dust[index].velocity *= 0.2f;
                    Main.dust[index].noGravity = true;
                    Main.dust[index].scale = 1f;
                }
            }
            else
			{
                projectile.Kill();
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			int num2 = Main.rand.Next(20, 40);
            for (int index1 = 0; index1 < num2; ++index1)
            {
                int index2 = Dust.NewDust(projectile.Center, 0, 0, 111, 0.0f, 0.0f, 100, new Color(), 0.8f);
                Main.dust[index2].velocity *= 1.2f;
                --Main.dust[index2].velocity.Y;
                Main.dust[index2].velocity += projectile.velocity;
                Main.dust[index2].noGravity = true;
            }
		}
		public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item45, projectile.position);
		}
    }
}