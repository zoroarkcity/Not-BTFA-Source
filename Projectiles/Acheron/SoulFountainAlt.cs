using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Acheron
{
	public class SoulFountainAlt : ModProjectile //JK MEME TAG ITS NOT HOMING
	{
		public override void SetDefaults()
		{
			projectile.width = 2;
			projectile.height = 2;
			projectile.aiStyle = 1;
			aiType = ProjectileID.Bullet;
			projectile.tileCollide = false;
			projectile.friendly = true;
			projectile.timeLeft = 300;
			projectile.extraUpdates = 2;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lost Soul");
		}
		

		public override void AI()
		{
			if (projectile.timeLeft <= 300)
			{
				for (int index1 = 0; index1 < 10; ++index1)
				{
					float num1 = projectile.velocity.X / 3f * (float) index1;
					float num2 = projectile.velocity.Y / 3f * (float) index1;
					int num3 = 4;
					int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, 20, 0.0f, 0.0f, 100, new Color(), 1.4f);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity *= 0f;
					Main.dust[index2].velocity += projectile.velocity * 0.1f;
					Main.dust[index2].position.X -= num1;
					Main.dust[index2].position.Y -= num2;
					Main.dust[index2].scale = 1.1f;
				}
				for (int index2 = 0; index2 < 1; ++index2)
				{
					float x = projectile.position.X;
					float y = projectile.position.Y;
					int index3 = Dust.NewDust(new Vector2(x, y), 1, 1, 20, 0.0f, 0.0f, 0, new Color(), 1f);
					Main.dust[index3].alpha = projectile.alpha;
					Main.dust[index3].position.X = x;
					Main.dust[index3].position.Y = y;
					Main.dust[index3].scale = 1f;
					Main.dust[index3].velocity *= 2f;
					Main.dust[index3].noGravity = true;
				}
			}
			
			if (Items.ItemSets.Acheron.Styx.switcher == 1)
			{
				projectile.damage = (int)(100 * Main.player[projectile.owner].minionDamage);
			}
			else if (Items.ItemSets.Acheron.Styx.switcher == 2)
			{
				projectile.damage = (int)(75 * Main.player[projectile.owner].minionDamage);
			}
			else if (Items.ItemSets.Acheron.Styx.switcher == 3)
			{
				projectile.damage = (int)(50 * Main.player[projectile.owner].minionDamage);
			}
			else if (Items.ItemSets.Acheron.Styx.switcher == 4)
			{
				projectile.damage = (int)(25 * Main.player[projectile.owner].minionDamage);
			}
			
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
				
			Vector2 move = Vector2.Zero;
			float distance = 400f;
			bool target = false;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
				{
					Vector2 newMove = Main.npc[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						move = newMove;
						distance = distanceTo;
						target = true;
					}
				}
			}
			if (target)
			{
				AdjustMagnitude(ref move);
				projectile.velocity = (2 * projectile.velocity + move) / 3f;
				AdjustMagnitude(ref projectile.velocity);
			}
        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Items.ItemSets.Acheron.Styx.switcher == 1)
			{
				if (Main.rand.Next(10) == 0)
				{  
					Player owner = Main.player[projectile.owner];
                    owner.statLife += projectile.damage/20;
                    owner.HealEffect(projectile.damage/20, true);
				}
			}
			else if (Items.ItemSets.Acheron.Styx.switcher == 2)
			{
				if (Main.rand.Next(9) == 0)
				{  
					Player owner = Main.player[projectile.owner];
                    owner.statLife += projectile.damage/20;
                    owner.HealEffect(projectile.damage/20, true);
				}
			}
			else if (Items.ItemSets.Acheron.Styx.switcher == 3)
			{
				if (Main.rand.Next(8) == 0)
				{  
					Player owner = Main.player[projectile.owner];
                    owner.statLife += projectile.damage/20;
                    owner.HealEffect(projectile.damage/20, true);
				}
			}
			else if (Items.ItemSets.Acheron.Styx.switcher == 4)
			{
				if (Main.rand.Next(7) == 0)
				{  
					Player owner = Main.player[projectile.owner];
                    owner.statLife += projectile.damage/20;
                    owner.HealEffect(projectile.damage/20, true);
				}
			}
		}
		
		private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 6f)
			{
				vector *= 6f / magnitude;
			}
		}
	}
}