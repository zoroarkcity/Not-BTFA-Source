using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.Utilities;

namespace ForgottenMemories.Projectiles
{
	public class BlightedEmber2 : ModProjectile
	{
		Vector2 Gayer;
		bool canMeme = false;
		//float memers = 0;
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.friendly = true;
			projectile.magic  = true;
			projectile.penetrate = 5;
			projectile.timeLeft = 100;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Ember");
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				if (projectile.velocity.X != oldVelocity.X)
					projectile.velocity.X = -oldVelocity.X;
				if (projectile.velocity.Y != oldVelocity.Y)
					projectile.velocity.Y = -oldVelocity.Y;

				float angle = projectile.velocity.ToRotation();

				int possibleTarget = -1;
				float possibleAngle = 0;
				float closestDistance = 500f;
					
				for (int i = 0; i < 200; i++) //find target
				{
					NPC npc = Main.npc[i];

					if (npc.active && npc.chaseable && npc.lifeMax > 5 && !npc.dontTakeDamage && !npc.friendly && !npc.immortal)
					{
						Vector2 difference = npc.Center - projectile.Center;
						float distance = difference.Length();
						
						if (distance < closestDistance)
						{
							float angleVariation = difference.ToRotation() - projectile.velocity.ToRotation(); //must be within 90 degrees
							if (Math.Abs(angleVariation) <= 1.57079633 && Collision.CanHit(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height))
							{
								closestDistance = distance;
								possibleTarget = i;
								possibleAngle = angleVariation;
							}
						}
					}
				}

				if (possibleTarget != -1)
				{
					NPC npc = Main.npc[possibleTarget];
					projectile.velocity = projectile.velocity.RotatedBy(possibleAngle);
				}

				Main.PlaySound(SoundID.Item10, projectile.position);
			}
			return false;
		}
		public override void AI()
		{
			float num7 = projectile.velocity.ToRotation();
			Gayer = projectile.velocity.RotatedBy(MathHelper.ToRadians(Main.rand.Next(-50, 50)));
			float num8 = num7.AngleLerp(Gayer.ToRotation(), 0.1f);
			projectile.velocity = new Vector2(projectile.velocity.Length(), 0f).RotatedBy((double)num8, default(Vector2));
			
			for (int index1 = 0; index1 < 5; ++index1)
			{
				float num1 = projectile.velocity.X / 3f * (float) index1;
				float num2 = projectile.velocity.Y / 3f * (float) index1;
				int num3 = 4;
				int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, 173, 0.0f, 0.0f, 100, new Color(), 1.4f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 0.1f;
				Main.dust[index2].velocity += projectile.velocity * 0.1f;
				Main.dust[index2].position.X -= num1;
				Main.dust[index2].position.Y -= num2;
			}
			
			if (Main.rand.Next(30) == 0 && projectile.ai[0] != 1)
			{
				//float num872 = (float)Main.rand.Next(-3, 4) * 1.04719758f / 3f;
				Vector2 vector101 = projectile.velocity.RotatedBy(MathHelper.ToRadians(Main.rand.Next(-90, 90)));
				int p = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector101.X, vector101.Y, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, 1f, 0f);
				Main.projectile[p].timeLeft = projectile.timeLeft;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("BlightFlame"), 180, false);
		}
	}
}