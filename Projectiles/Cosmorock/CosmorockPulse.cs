using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Cosmorock
{
	public class CosmorockPulse : ModProjectile
	{
		protected int dustTimer = 0;
		public override void SetDefaults()
		{
            projectile.width = 36;
            projectile.height = 36;
            projectile.aiStyle = -1;
			projectile.alpha = 255;
			projectile.friendly = true;
			projectile.tileCollide = true;
            projectile.penetrate = -1;
			projectile.scale = 0.1f;
			projectile.ranged = true;
			projectile.timeLeft = 300;
			projectile.extraUpdates = 1;
		}
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Energy Pulse");
        }
		
        public override void AI()
        {
			projectile.alpha = 255;
			dustTimer++;
			if (projectile.ai[1] != (2 | 3 | 4))
			{
				if (projectile.scale < 4f)
				{
					projectile.scale += 0.05f;
				}
				projectile.damage = (int)(projectile.ai[0] * projectile.scale/2);
			}
			else
			{
				projectile.scale = 0.2f;
			}
			
			if (projectile.ai[1] == 1)
			{
				projectile.extraUpdates = 20;
			}
			if(projectile.ai[1] == 3 && projectile.timeLeft == 300)
			{
				projectile.penetrate = 5;
			}
			
			if (projectile.ai[1] == 4)
			{
				if(projectile.timeLeft == 300)
				{
					projectile.penetrate = 3;
				}
				Vector2 targetPos = projectile.Center;
				float targetDist = 200f;
				bool targetAcquired = false;
				
				for (int i = 0; i < 200; i++)
				{
					if (Main.npc[i].CanBeChasedBy(projectile) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[i].Center, 1, 1) && Main.npc[i].immune[projectile.owner] == 0)
					{
						float dist = projectile.Distance(Main.npc[i].Center);
						if (dist < targetDist)
						{
							targetDist = dist;
							targetPos = Main.npc[i].Center;
							targetAcquired = true;
						}
					}
				}
				
				if (targetAcquired)
				{
					float homingSpeedFactor = 10f;
					Vector2 homingVect = targetPos - projectile.Center;
					float dist = projectile.Distance(targetPos);
					dist = homingSpeedFactor / dist;
					homingVect *= dist;

					projectile.velocity = (projectile.velocity * 20 + homingVect) / 21f;
				}
			}
			
			Player player = Main.player[projectile.owner];
			if (dustTimer % 4 == 0)
			{
				float num = 16f;
				for (int index1 = 0; (double) index1 < (double) num; ++index1)
				{
					int type = (projectile.ai[1] == 1) ? 269 : 
					(projectile.ai[1] == 2) ? 6 : 
					(projectile.ai[1] == 3) ? 21 : 
					(projectile.ai[1] == 4) ? 75 : 15;
					
					Vector2 v = (Vector2.UnitX * 0.0f + -Vector2.UnitY.RotatedBy((double) index1 * (6.28318548202515 / (double) num), new Vector2()) * new Vector2(1f, 4f)).RotatedBy((double) projectile.velocity.ToRotation(), new Vector2());
					int index2 = Dust.NewDust(projectile.Center, 0, 0, type, 0.0f, 0.0f, 100, new Color(), 1f);
					Main.dust[index2].scale = 1.5f;
					Main.dust[index2].fadeIn = 1.3f;
					Main.dust[index2].noGravity = true;
					Main.dust[index2].position = projectile.Center + (v*projectile.scale);
					Main.dust[index2].velocity = projectile.velocity * 0.0f + v.SafeNormalize(Vector2.UnitY) * 1f;
				}
			}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if(projectile.ai[1] != 1)
			{
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
				Main.PlaySound(new Terraria.Audio.LegacySoundStyle(2, 9));
				return false;
			}
			return true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if(projectile.ai[1] == 2)
			{
				target.AddBuff(BuffID.OnFire, 60 * Main.rand.Next(2, 4), false);
				int p = Projectile.NewProjectile(projectile.Center, Vector2.Zero, mod.ProjectileType("FireGrenadeBoom"), projectile.damage, 1f, projectile.owner, 0, 0);
				Main.projectile[p].thrown = false;
				Main.projectile[p].ranged = true;
			}
			
			if(projectile.ai[1] == 3)
			{
				target.immune[projectile.owner] = 15;
				int amountOfProjectiles = Main.rand.Next(1, 3);
				for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-60, 61) * 0.2f;
					float sY = (float)Main.rand.Next(-60, 61) * 0.2f;
					int p = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, 94, projectile.damage / 3, 0f, projectile.owner);
					Main.projectile[p].ranged = true;
					Main.projectile[p].magic = false;
					Main.projectile[p].timeLeft = 30;
					
				}
			}
		}
	}
}