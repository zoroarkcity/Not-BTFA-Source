using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Dune 
{
	public class DuneTornado : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 44;
			projectile.aiStyle = 0;
			projectile.penetrate = 5;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.scale = 1f;
			projectile.tileCollide = false;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tornado");
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
			projectile.alpha += 1;
			
			if(projectile.alpha > 250)
			{
				projectile.Kill();
			}
			
			
			float num7 = projectile.velocity.ToRotation();
			Vector2 vector2 = player.Center - projectile.Center;
			float targetAngle = vector2.ToRotation();
			if (vector2 == Vector2.Zero)
			{
				targetAngle = num7;
			}
			float num8 = num7.AngleLerp(targetAngle, 0.025f);
			projectile.velocity = new Vector2(projectile.velocity.Length(), 0f).RotatedBy((double)num8, default(Vector2));
			
		}
	}
}	