using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Summon
{
    public class BlightOrb : ModProjectile
	{
    	public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 46;
			projectile.height = 46;
			projectile.friendly = true;
			Main.projPet[projectile.type] = true;
			projectile.minion = true;
			projectile.minionSlots = 0;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Orb");
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}
		
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.penetrate == 0)
            {
                projectile.Kill();
            }
            return false;
        }
		
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			BTFAPlayer modPlayer = player.GetModPlayer<BTFAPlayer>(mod);
			if (player.dead)
			{
				modPlayer.BlightOrb = false;
			}
			if (modPlayer.BlightOrb)
			{
				projectile.timeLeft = 2;
			}
			
			Lighting.AddLight(projectile.Center, 0.4f, 0.4f, 0f);
			if ((double) projectile.localAI[1] > 0.0)
				 --projectile.localAI[1];
			 
			 
			if ((double) projectile.ai[0] == 2.0)
			{
				--projectile.ai[1];
				projectile.tileCollide = false;
				if ((double) projectile.ai[1] > 3.0)
				{
					if (projectile.numUpdates < 20)
					{
						for (int index = 0; index < 3; ++index)
						{
							Dust dust = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, 0.0f, 0.0f, 0, new Color(), 1f)];
							dust.noGravity = true;
							dust.position = projectile.Center;
							dust.velocity *= 3f;
							dust.velocity += projectile.velocity * 3f;
							dust.fadeIn = 1f;
						}
					}
					
					float num1 = (float) (2.0 - (double) projectile.numUpdates / 30.0);
					if ((double) projectile.scale > 0.0)
					{
						float num2 = 2f;
						for (int index = 0; (double) index < (double) num2; ++index)
						{
							Dust dust = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, 0.0f, 0.0f, 0, new Color(), 1f)];
							dust.noGravity = true;
							dust.position = projectile.Center + Vector2.UnitY.RotatedBy((double) projectile.numUpdates * 0.104719758033752 + (double) projectile.whoAmI * 0.785398185253143 + 1.57079637050629, new Vector2()) * (float) (projectile.height / 2) - projectile.velocity * ((float) index / num2);
							dust.velocity = projectile.velocity / 3f;
							dust.fadeIn = num1 / 2f;
							dust.scale = num1;
						}
					}
				}
				
				if ((double) projectile.ai[1] != 0.0)
					return;
				projectile.ai[1] = 30f;
				projectile.ai[0] = 0.0f;
				Vector2 vector2 = projectile.velocity / 5f;
				projectile.velocity = vector2;
				projectile.velocity.Y = 0.0f;
				projectile.extraUpdates = 0;
				projectile.numUpdates = 0;
				projectile.netUpdate = true;
				float num = 15f;
				for (int index = 0; (double) index < (double) num; ++index)
				{
					Dust dust = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, 0.0f, 0.0f, 0, new Color(), 1f)];
					dust.noGravity = true;
					dust.position = projectile.Center - projectile.velocity * 5f;
					dust.velocity *= 3f;
					dust.velocity += projectile.velocity * 3f;
					dust.fadeIn = 1f;
					if (Main.rand.Next(3) != 0)
					{
						dust.fadeIn = 2f;
						dust.scale = 2f;
						dust.velocity /= 8f;
					}
				}
				for (int index = 0; (double) index < (double) num; ++index)
				{
					Dust dust = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, 0.0f, 0.0f, 0, new Color(), 1f)];
					dust.noGravity = true;
					dust.position = projectile.Center;
					dust.velocity *= 3f;
					dust.velocity += projectile.velocity * 3f;
					dust.fadeIn = 1f;
					if (Main.rand.Next(3) != 0)
					{
					  dust.fadeIn = 2f;
					  dust.scale = 2f;
					  dust.velocity /= 8f;
					}
				  }
				  projectile.extraUpdates = 0;
				  projectile.numUpdates = 0;
				}
				if (projectile.extraUpdates > 1)
					projectile.extraUpdates = 0;
				if (projectile.numUpdates > 1)
					projectile.numUpdates = 0;
				
			  if ((double) projectile.localAI[0] > 0.0)
					--projectile.localAI[0];
				
			  float num3 = 0.05f;
			  float width = (float) projectile.width;
			  
			  for (int index = 0; index < 1000; ++index)
			  {
					if (index != projectile.whoAmI && Main.projectile[index].active && (Main.projectile[index].owner == projectile.owner && Main.projectile[index].type == projectile.type) && (double) Math.Abs(projectile.position.X - Main.projectile[index].position.X) + (double) Math.Abs(projectile.position.Y - Main.projectile[index].position.Y) < (double) width)
					{
						if ((double) projectile.position.X < (double) Main.projectile[index].position.X)
							projectile.velocity.X -= num3;
						else
							projectile.velocity.X += num3;
						if ((double) projectile.position.Y < (double) Main.projectile[index].position.Y)
							projectile.velocity.Y -= num3;
						else
							projectile.velocity.Y += num3;
					}
			  }
			Vector2 vector2_1 = projectile.position;
			float num4 = 300f;
			bool flag = false;
			int num5 = -1;
			projectile.tileCollide = true;
			  
			Vector2 center = Main.player[projectile.owner].Center;
			Vector2 vector2_2 = new Vector2(0.5f);
			NPC minionAttackTargetNpc = projectile.OwnerMinionAttackTargetNPC;
			if (minionAttackTargetNpc != null && minionAttackTargetNpc.CanBeChasedBy((object) this, false))
			{
				Vector2 vector2_3 = minionAttackTargetNpc.position + minionAttackTargetNpc.Size * vector2_2;
				float num1 = Vector2.Distance(vector2_3, center);
				if (((double) Vector2.Distance(center, vector2_1) > (double) num1 && (double) num1 < (double) num4 || !flag) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, minionAttackTargetNpc.position, minionAttackTargetNpc.width, minionAttackTargetNpc.height))
				{
					num4 = num1;
					vector2_1 = vector2_3;
					flag = true;
					num5 = minionAttackTargetNpc.whoAmI;
				}
			}
			if (!flag)
			{
				for (int index = 0; index < 200; ++index)
				{
					NPC npc = Main.npc[index];
					if (npc.CanBeChasedBy((object) this, false))
					{
						Vector2 vector2_3 = npc.position + npc.Size * vector2_2;
						float num1 = Vector2.Distance(vector2_3, center);
						if (((double) Vector2.Distance(center, vector2_1) > (double) num1 && (double) num1 < (double) num4 || !flag) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height))
						{
							num4 = num1;
							vector2_1 = vector2_3;
							flag = true;
							num5 = index;
						}
					}
				}
			}
			  
			int num6 = 1350;
			
			if ((double) Vector2.Distance(player.Center, projectile.Center) > (double) num6)
			{
				projectile.ai[0] = 1f;
				projectile.netUpdate = true;
			}
			if ((double) projectile.ai[0] == 1.0)
				projectile.tileCollide = false;
			if (flag && (double) projectile.ai[0] == 0.0)
			{
				vector2_2 = vector2_1 - projectile.Center;
				float num1 = vector2_2.Length();
				vector2_2.Normalize();
				
				Vector2 vector2_3 = vector2_1;
				Vector2 vector2_4 = projectile.Center - vector2_3;
				if (vector2_4 == Vector2.Zero)
					vector2_4 = -Vector2.UnitY;
				vector2_4.Normalize();
				Vector2 vector2_5 = vector2_3 + vector2_4 * 60f;
					int index = (int) vector2_5.Y / 16;
				if (index < 0)
					index = 0;
				Tile tile1 = Main.tile[(int) vector2_5.X / 16, index];
				if (tile1 != null && tile1.active() && (Main.tileSolid[(int) tile1.type] && !Main.tileSolidTop[(int) tile1.type]))
				{
					vector2_5 += Vector2.UnitY * 16f;
					Tile tile2 = Main.tile[(int) vector2_5.X / 16, (int) vector2_5.Y / 16];
					if (tile2 != null && tile2.active() && (Main.tileSolid[(int) tile2.type] && !Main.tileSolidTop[(int) tile2.type]))
						vector2_5 += Vector2.UnitY * 16f;
				}
				vector2_2 = vector2_5 - projectile.Center;
				num1 = vector2_2.Length();
				vector2_2.Normalize();
				if ((double) num1 > 400.0 && (double) num1 <= 800.0 && (double) projectile.localAI[0] == 0.0)
				{
					projectile.ai[0] = 2f;
					projectile.ai[1] = (float) (int) ((double) num1 / 10.0);
					projectile.extraUpdates = (int) projectile.ai[1];
					projectile.velocity = vector2_2 * 10f;
					projectile.localAI[0] = 60f;
					return;
				}
				
				
				if ((double) num1 > 200.0)
				{
				  float num2 = 6f;
				  vector2_3 = vector2_2 * num2;
				  projectile.velocity.X = (float) (((double) projectile.velocity.X * 40.0 + (double) vector2_3.X) / 41.0);
				  projectile.velocity.Y = (float) (((double) projectile.velocity.Y * 40.0 + (double) vector2_3.Y) / 41.0);
				}
				
				else
				{
					if ((double) num1 > 70.0 && (double) num1 < 130.0)
					{
						float num2 = 7f;
						if ((double) num1 < 100.0)
							num2 = -3f;
						vector2_3 = vector2_2 * num2;
						projectile.velocity = (projectile.velocity * 20f + vector2_3) / 21f;
						if ((double) Math.Abs(vector2_3.X) > (double) Math.Abs(vector2_3.Y))
							projectile.velocity.X = (float) (((double) projectile.velocity.X * 10.0 + (double) vector2_3.X) / 11.0);
					}
					else
					{
						vector2_3 = projectile.velocity * 0.97f;
						projectile.velocity = vector2_3;
					}
				}
			}
			
			else
			{
				if (!Collision.CanHitLine(projectile.Center, 1, 1, Main.player[projectile.owner].Center, 1, 1))
					projectile.ai[0] = 1f;
				float num1 = 6f;
				if ((double) projectile.ai[0] == 1.0)
					num1 = 15f;
				vector2_2 = player.Center - projectile.Center + new Vector2(0.0f, -60f);
				float num7 = vector2_2.Length();
				if ((double) num7 > 200.0 && (double) num1 < 9.0)
				  num1 = 9f;
				if ((double) num7 < 100.0 && (double) projectile.ai[0] == 1.0 && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
				{
				  projectile.ai[0] = 0.0f;
				  projectile.netUpdate = true;
				}
				if ((double) num7 > 2000.0)
				{
				  projectile.position.X = Main.player[projectile.owner].Center.X - (float) (projectile.width / 2);
				  projectile.position.Y = Main.player[projectile.owner].Center.Y - (float) (projectile.width / 2);
				}
				
				if ((double) num7 > 70.0)
				{
				  vector2_2.Normalize();
				  vector2_2 *= num1;
				  projectile.velocity = (projectile.velocity * 20f + vector2_2) / 21f;
				}
				
				else
				{
					if ((double) projectile.velocity.X == 0.0 && (double) projectile.velocity.Y == 0.0)
					{
						projectile.velocity.X = -0.15f;
						projectile.velocity.Y = -0.05f;
					}
					Vector2 vector2_3 = projectile.velocity * 1.01f;
					projectile.velocity = vector2_3;
				}
			}
			
			//num1 = 3;
			  
			if ((double) projectile.velocity.X > 0.0)
				projectile.spriteDirection = projectile.direction = -1;
			else if ((double) projectile.velocity.X < 0.0)
				projectile.spriteDirection = projectile.direction = 1;
			
			if ((double) projectile.ai[1] > 0.0)
			{
				++projectile.ai[1];
				if (Main.rand.Next(3) != 0)
					++projectile.ai[1];
			}
			if ((double) projectile.ai[1] > 60.0)
			{
				projectile.ai[1] = 0.0f;
				projectile.netUpdate = true;
			}
			
			if ((double) projectile.ai[0] != 0.0)
				return;
			float num8 = 14f;
			int Type = mod.ProjectileType("BlightOrbShoot");
			
			if (!flag)
				return;
			
			if ((double) projectile.ai[1] == 0.0)
			{
				if ((double) (vector2_1 - projectile.Center).Length() > 500.0 || (double) projectile.ai[1] != 0.0)
					return;
				++projectile.ai[1];
				if (Main.myPlayer == projectile.owner)
				{
					vector2_2 = vector2_1 - projectile.Center;
					vector2_2.Normalize();
					Vector2 vector2_3 = vector2_2 * num8;
					int index = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector2_3.X, vector2_3.Y, Type, projectile.damage, 0.0f, Main.myPlayer, 0.0f, (float) num5);
					Main.projectile[index].timeLeft = 300;
					Main.projectile[index].netUpdate = true;
					Vector2 vector2_4 = projectile.velocity - vector2_3 / 3f;
					projectile.velocity = vector2_4;
					projectile.netUpdate = true;
				}
				
				for (int index1 = 0; index1 < 5; ++index1)
				{
					int num1 = projectile.width / 4;
					vector2_2 = ((float) Main.rand.NextDouble() * 6.283185f).ToRotationVector2() * (float) Main.rand.Next(24, 41) / 8f;
					int index2 = Dust.NewDust(projectile.Center - Vector2.One * (float) num1, num1 * 2, num1 * 2, 173, 0.0f, 0.0f, 0, new Color(), 1f);
					Dust dust = Main.dust[index2];
					Vector2 vector2_3 = Vector2.Normalize(dust.position - projectile.Center);
					dust.position = projectile.Center + vector2_3 * (float) num1 * projectile.scale - new Vector2(4f);
					dust.velocity = index1 >= 30 ? 2f * vector2_3 * (float) Main.rand.Next(45, 91) / 10f : vector2_3 * dust.velocity.Length() * 2f;
					dust.noGravity = true;
					dust.scale = 0.7f + Main.rand.NextFloat();
				}
			}
		}
		
		public override bool MinionContactDamage()
        {
            return false;
        }
    }
}
