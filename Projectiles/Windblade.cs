using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class Windblade : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 22;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 255;
			projectile.extraUpdates = 1;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
			projectile.tileCollide = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Windblade");
		}
		

		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			if (Main.rand.Next(6) == 0 && projectile.alpha <= 200)
			{
				for (int index1 = 0; index1 < 1; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 20, 0.0f, 0.0f, 0, new Color(0, 255, 0), 1f);
					Main.dust[index2].velocity *= 0.5f;
					Main.dust[index2].scale *= 1.3f;
					Main.dust[index2].fadeIn = 1f;
					Main.dust[index2].noGravity = true;
				}
			}
			projectile.alpha += 1;
			
			
			Vector2 acceleration = projectile.velocity.RotatedBy(System.Math.PI / 2);
			acceleration *= projectile.ai[1];
			
			projectile.velocity += acceleration;
			
			if (projectile.alpha >= 250)
			{
				projectile.Kill();
			}
		}
	}
}