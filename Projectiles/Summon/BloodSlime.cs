using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Summon
{
    public class BloodSlime : ModProjectile
	{
		float inertia = 40f;
    	public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 42;
			projectile.height = 44;
			Main.projFrames[projectile.type] = 1;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Accursed Bloodling");
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}
		
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			BTFAPlayer modPlayer = player.GetModPlayer<BTFAPlayer>(mod);
			if (player.dead)
			{
				modPlayer.BloodSlime = false;
			}
			if (modPlayer.BloodSlime)
			{
				projectile.timeLeft = 2;
			}
			
			Lighting.AddLight(projectile.Center, 0.5f, 0.2f, 0f);
			
			float spacing = (float)projectile.width;
			for (int k = 0; k < 1000; k++)
			{
				Projectile otherProj = Main.projectile[k];
				if (k != projectile.whoAmI && otherProj.active && otherProj.owner == projectile.owner && otherProj.type == projectile.type && System.Math.Abs(projectile.position.X - otherProj.position.X) + System.Math.Abs(projectile.position.Y - otherProj.position.Y) < spacing)
				{
					if (projectile.position.X < Main.projectile[k].position.X)
					{
						projectile.velocity.X -= 0.05f;
					}
					else
					{
						projectile.velocity.X += 0.05f;
					}
					if (projectile.position.Y < Main.projectile[k].position.Y)
					{
						projectile.velocity.Y -= 0.05f;
					}
					else
					{
						projectile.velocity.Y += 0.05f;
					}
				}
			}
			Vector2 targetPos = projectile.position;
			float targetDist = 400f;
			bool target = false;
			projectile.tileCollide = true;
			NPC minionAttackTargetNpc = projectile.OwnerMinionAttackTargetNPC;
			if (minionAttackTargetNpc != null && minionAttackTargetNpc.CanBeChasedBy((object) this, false) && Vector2.Distance(minionAttackTargetNpc.Center, projectile.Center) < 400f && Collision.CanHit(projectile.position, projectile.width, projectile.height, minionAttackTargetNpc.position, minionAttackTargetNpc.width, minionAttackTargetNpc.height))
			{
				targetPos = minionAttackTargetNpc.Center;
				target = true;
			}
			else
			{
				for (int k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (npc.CanBeChasedBy(this, false))
					{
						float distance = Vector2.Distance(npc.Center, projectile.Center);
						if ((distance < targetDist || !target) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height))
						{
							targetDist = distance;
							targetPos = npc.Center;
							target = true;
						}
					}
				}
			}
			if (Vector2.Distance(player.Center, projectile.Center) > (target ? 1000f : 500f))
			{
				projectile.ai[0] = 1f;
				projectile.netUpdate = true;
			}
			if (projectile.ai[0] == 1f)
			{
				projectile.tileCollide = false;
			}
			if (target && projectile.ai[0] == 0f)
			{
				Vector2 direction = targetPos - projectile.Center;
				direction.Normalize();
				direction *= Main.rand.Next(16, 19);
				if (Vector2.Distance(targetPos, projectile.Center) > 100f)
				{
					direction *= 1.1f;
				}
				if (Vector2.Distance(targetPos, projectile.Center) > 200f)
				{
					direction *= 1.1f;
				}
				if (Vector2.Distance(targetPos, projectile.Center) > 400f)
				{
					direction *= 1.2f;
				}
				projectile.ai[1]++;
				if (projectile.ai[1] >= Main.rand.Next(30, 41))
				{
					projectile.ai[1] = 0f;
					projectile.velocity = direction;
					projectile.netUpdate = true;
				}
				else
				{
					projectile.velocity = Vector2.Lerp(projectile.velocity, Vector2.Zero, 0.08f);
				}
			}
			else
			{
				projectile.ai[1] = 0;
				if (!Collision.CanHitLine(projectile.Center, 1, 1, player.Center, 1, 1))
				{
					projectile.ai[0] = 1f;
				}
				float speed = 6f;
				if (projectile.ai[0] == 1f)
				{
					speed = 15f;
				}
				Vector2 center = projectile.Center;
				Vector2 direction = player.Center - center;
				projectile.ai[1] = 3600f;
				projectile.netUpdate = true;
				int num = 1;
				for (int k = 0; k < projectile.whoAmI; k++)
				{
					if (Main.projectile[k].active && Main.projectile[k].owner == projectile.owner && Main.projectile[k].type == projectile.type)
					{
						num++;
					}
				}
				direction.X -= (float)((10 + num * 40) * player.direction);
				direction.Y -= 70f;
				float distanceTo = direction.Length();
				if (distanceTo > 200f && speed < 9f)
				{
					speed = 9f;
				}
				if (distanceTo < 100f && projectile.ai[0] == 1f && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
				{
					projectile.ai[0] = 0f;
					projectile.netUpdate = true;
				}
				if (distanceTo > 2000f)
				{
					projectile.Center = player.Center;
				}
				if (distanceTo > 48f)
				{
					direction.Normalize();
					direction *= speed;
					float temp = inertia / 2f;
					projectile.velocity = (projectile.velocity * temp + direction) / (temp + 1);
				}
				else
				{
					projectile.direction = Main.player[projectile.owner].direction;
					projectile.velocity *= (float)Math.Pow(0.9, 40.0 / inertia);
				}
			}
			projectile.rotation = projectile.velocity.X * 0.05f;
			if (projectile.velocity.X > 0f)
			{
				projectile.spriteDirection = (projectile.direction = -1);
			}
			else if (projectile.velocity.X < 0f)
			{
				projectile.spriteDirection = (projectile.direction = 1);
			}
			
		}
		
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			fallThrough = true;
			return true;
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
    }
}
