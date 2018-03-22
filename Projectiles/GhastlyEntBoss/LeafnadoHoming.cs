using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.GhastlyEntBoss 
{
	public class LeafnadoHoming : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 0;
			projectile.penetrate = 5;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.scale = 1f;
			projectile.tileCollide = false;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leafnado");
			Main.projFrames[projectile.type] = 6;
		}
		
		
		public override void AI()
		{
			int closest = (int) Player.FindClosest(projectile.Center, 0, 0);
			Player player = Main.player[closest];
			projectile.frameCounter++;
			if (projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			}
			projectile.alpha += 2;
			
			if(projectile.alpha > 250)
			{
				projectile.Kill();
			}
			
			if(projectile.ai[0] == 1)
			{
				projectile.ai[1]++;
				
				projectile.velocity = Vector2.Lerp(projectile.velocity, Vector2.Zero, 0.03f);
				if (projectile.ai[1] > 30)
				{
					Vector2 direction = Vector2.Subtract(player.Center, projectile.Center);
					float velocity = 15 / direction.Length();
					projectile.velocity = direction * velocity;
					projectile.ai[1] = 0;
				}
			}
			
			if(projectile.ai[0] == 2)
			{
				Vector2 vel = player.Center - projectile.Center;
				vel.Normalize();
				vel *= 3;
				projectile.velocity = vel;
			}
			
			else
			{
				float num7 = projectile.velocity.ToRotation();
				Vector2 vector2 = player.Center - projectile.Center;
				float targetAngle = vector2.ToRotation();
				if (vector2 == Vector2.Zero)
				{
					targetAngle = num7;
				}
				float num8 = num7.AngleLerp(targetAngle, 0.01f);
				projectile.velocity = new Vector2(projectile.velocity.Length(), 0f).RotatedBy((double)num8, default(Vector2));
			}
		}
	}
}	