using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Summon
{
    public class FernlingMinion : ModProjectile
    {
    	
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 32;
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.minionSlots = 0.5f;
            projectile.alpha = 0;
            projectile.timeLeft = 18000;
            Main.projFrames[projectile.type] = 8;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            projectile.penetrate = -1;
            projectile.timeLeft *= 5;
            projectile.minion = true;
            projectile.tileCollide = false;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fernling");
		}

        public override void AI()
		{
			Player player = Main.player[projectile.owner];
			BTFAPlayer modPlayer = (BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer");
			if (player.dead)
			{
				modPlayer.Fernling = false;
			}
			if (modPlayer.Fernling)
			{
				projectile.timeLeft = 2;
			}
			
			for (int index = 0; index < 1000; ++index)
			{
				if (index != projectile.whoAmI && Main.projectile[index].active && (Main.projectile[index].owner == projectile.owner && Main.projectile[index].type == projectile.type) && (double) Math.Abs((float) (projectile.position.X - Main.projectile[index].position.X)) + (double) Math.Abs((float) (projectile.position.Y - Main.projectile[index].position.Y)) < (double) projectile.width)
				{
					if (projectile.position.X < Main.projectile[index].position.X)
					{
						projectile.velocity.X -= 0.05f;
					}
					else
					{
						projectile.velocity.X += 0.05f;
					}
					if (projectile.position.Y < Main.projectile[index].position.Y)
					{
						projectile.velocity.Y -= 0.05f;
					}
					else
					{
						projectile.velocity.Y += 0.05f;
					}
				}
			}
			float num1 = (float) projectile.position.X;
			float num2 = (float) projectile.position.Y;
			float num3 = 900f;
			bool flag = false;
			int num4 = 500;
			if ((double) projectile.ai[1] != 0.0 || projectile.friendly)
				num4 = 1400;
			if ((double) Math.Abs((float) (projectile.Center.X - Main.player[projectile.owner].Center.X)) + (double) Math.Abs((float) (projectile.Center.Y - Main.player[projectile.owner].Center.Y)) > (double) num4)
				projectile.ai[0] = 1f;
			if ((double) projectile.ai[0] == 0.0)
			{
				projectile.tileCollide = true;
				NPC minionAttackTargetNpc = projectile.OwnerMinionAttackTargetNPC;
				if (minionAttackTargetNpc != null && minionAttackTargetNpc.CanBeChasedBy((object) this, false))
				{
					float num5 = (float) minionAttackTargetNpc.position.X + (float) (minionAttackTargetNpc.width / 2);
					float num6 = (float) minionAttackTargetNpc.position.Y + (float) (minionAttackTargetNpc.height / 2);
					float num7 = Math.Abs((float) projectile.position.X + (float) (projectile.width / 2) - num5) + Math.Abs((float) projectile.position.Y + (float) (projectile.height / 2) - num6);
					if ((double) num7 < (double) num3 && Collision.CanHit(projectile.position, projectile.width, projectile.height, minionAttackTargetNpc.position, minionAttackTargetNpc.width, minionAttackTargetNpc.height))
					{
						num3 = num7;
						num1 = num5;
						num2 = num6;
						flag = true;
					}
				}
				if (!flag)
				{
					for (int index = 0; index < 200; ++index)
					{
						if (Main.npc[index].CanBeChasedBy((object) this, false))
						{
							float num5 = (float) Main.npc[index].position.X + (float) (Main.npc[index].width / 2);
							float num6 = (float) Main.npc[index].position.Y + (float) (Main.npc[index].height / 2);
							float num7 = Math.Abs((float) projectile.position.X + (float) (projectile.width / 2) - num5) + Math.Abs((float) projectile.position.Y + (float) (projectile.height / 2) - num6);
							if ((double) num7 < (double) num3 && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[index].position, Main.npc[index].width, Main.npc[index].height))
							{
								num3 = num7;
								num1 = num5;
								num2 = num6;
								flag = true;
							}
						}
					}
				}
			}
			else
				projectile.tileCollide = false;
			if (!flag)
			{
				projectile.friendly = true;
				float num5 = 8f;
				if ((double) projectile.ai[0] == 1.0)
					num5 = 12f;
				Vector2 vector2 = new Vector2((float) (projectile.position.X + (double) projectile.width * 0.5), (float) (projectile.position.Y + (double) projectile.height * 0.5));
				float num6 = (float) (Main.player[projectile.owner].Center.X - vector2.X);
				float num7 = (float) (Main.player[projectile.owner].Center.Y - vector2.Y - 60.0);
				float num8 = (float) Math.Sqrt((double) num6 * (double) num6 + (double) num7 * (double) num7);
				if ((double) num8 < 100.0 && (double) projectile.ai[0] == 1.0 && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
					projectile.ai[0] = 0.0f;
				if ((double) num8 > 2000.0)
				{
					projectile.position.X = (Main.player[projectile.owner].Center.X - (projectile.width / 2));
					projectile.position.Y = (Main.player[projectile.owner].Center.Y - (projectile.width / 2));
				}
				if ((double) num8 > 70.0)
				{
					float num9 = num5 / num8;
					float num10 = num6 * num9;
					float num11 = num7 * num9;
					projectile.velocity.X = ((projectile.velocity.X * 20 + num10) / 21);
					projectile.velocity.Y = ((projectile.velocity.Y * 20 + num11) / 21);
				}
				else
				{
					if (projectile.velocity.X == 0.0 && projectile.velocity.Y == 0.0)
					{
						projectile.velocity.X = -0.15f;
						projectile.velocity.Y = -0.05f;
					}
					projectile.velocity *= 1.01f;
				}
				projectile.friendly = false;
				projectile.rotation = (float) (projectile.velocity.X * 0.05f);
				projectile.frameCounter = projectile.frameCounter + 1;
				if (projectile.frameCounter >= 4)
				{
					projectile.frameCounter = 0;
					projectile.frame = projectile.frame + 1;
				}
				if (projectile.frame > 3)
					projectile.frame = 0;
				if ((double) Math.Abs((float) projectile.velocity.X) <= 0.2)
					return;
				projectile.spriteDirection = -projectile.direction;
			}
			else
			{
				if ((double) projectile.ai[1] == -1.0)
					projectile.ai[1] = 17f;
				if ((double) projectile.ai[1] > 0.0)
				{
					projectile.ai[1]--;
				}
				if ((double) projectile.ai[1] == 0.0)
				{
					projectile.friendly = true;
					float num5 = 8f;
					Vector2 vector2 = new Vector2((float) (projectile.position.X + (double) projectile.width * 0.5), (float) (projectile.position.Y + (double) projectile.height * 0.5));
					float num6 = num1 - (float) vector2.X;
					float num7 = num2 - (float) vector2.Y;
					float num8 = (float) Math.Sqrt((double) num6 * (double) num6 + (double) num7 * (double) num7);
					if ((double) num8 < 100.0)
						num5 = 10f;
					float num9 = num5 / num8;
					float num10 = num6 * num9;
					float num11 = num7 * num9;
					projectile.velocity.X = ((projectile.velocity.X * 14 + num10) / 15);
					projectile.velocity.Y = ((projectile.velocity.Y * 14 + num11) / 15);
				}
				else
				{
					projectile.friendly = false;
					if ((double) Math.Abs((float) projectile.velocity.X) + (double) Math.Abs((float) projectile.velocity.Y) < 10.0)
						projectile.velocity *= 1.05f;
				}
				projectile.rotation = (float) (projectile.velocity.X * 0.05f);
				projectile.frameCounter = projectile.frameCounter + 1;
				if (projectile.frameCounter >= 4)
				{
					projectile.frameCounter = 0;
					projectile.frame = projectile.frame + 1;
				}
				if (projectile.frame < 4)
					projectile.frame = 4;
				if (projectile.frame > 7)
					projectile.frame = 4;
				if ((double) Math.Abs((float) projectile.velocity.X) <= 0.2)
					return;
				projectile.spriteDirection = -projectile.direction;
			}
		}
        
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
			{
				projectile.velocity.X = -oldVelocity.X/2;
			}
			if (projectile.velocity.Y != oldVelocity.Y)
			{
				projectile.velocity.Y = -oldVelocity.Y/2;
			}
            return false;
        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.ai[1] = -1;
			projectile.netUpdate = true;
		}
    }
}
