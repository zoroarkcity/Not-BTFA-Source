using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class DarkMagicFriendly : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 5;
			projectile.height = 5;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 1;
			projectile.alpha = 255;
			projectile.tileCollide = true;
			projectile.timeLeft = 180;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Magic");
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Curse"), 60, false);
		}
		
		public override void AI()
		{
			for (int index1 = 0; index1 < 10; ++index1)
                {
                    float x = projectile.position.X - projectile.velocity.X / 10f * (float) index1;
                    float y = projectile.position.Y - projectile.velocity.Y / 10f * (float) index1;
                    int index2 = Dust.NewDust(new Vector2(x, y), 1, 1, 173, 0.0f, 0.0f, 0, new Color(), 1f);
                    Main.dust[index2].alpha = projectile.alpha;
                    Main.dust[index2].position.X = x;
                    Main.dust[index2].position.Y = y;
			        Main.dust[index2].scale = (float) Main.rand.Next(70, 110) * 0.013f;
                    Main.dust[index2].velocity *= 0.0f;
                    Main.dust[index2].noGravity = true;
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
                    float num1 = 1000f;
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
            }
            else
			{
                projectile.Kill();
			}
		}
	}
}