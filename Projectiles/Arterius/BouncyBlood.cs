using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Arterius
{
	public class BouncyBlood : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 44;
			projectile.height = 44;
			projectile.aiStyle = 1;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.penetrate = 3;
			projectile.tileCollide = true;
			projectile.timeLeft = 300;
			projectile.light = 0.5f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bouncy Blood");
			Main.projFrames[projectile.type] = 4;
		}
		
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			
			if (Main.rand.Next(3) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, mod.DustType("BloodDust"), 0f, 0f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			
			projectile.frameCounter++;
            if (projectile.frameCounter >= 4)
            {
                projectile.frameCounter = 0;
                projectile.frame = (projectile.frame + 1) % 4;
            } 
		}
		
		public override bool OnTileCollide (Vector2 velocity1)
		{
			projectile.penetrate--;
			if (projectile.penetrate == 0)
			{
				projectile.Kill();
			}
			if ((double) projectile.velocity.Y != (double) velocity1.Y || (double) projectile.velocity.X != (double) velocity1.X)
                {
                  if ((double) projectile.velocity.X != (double) velocity1.X)
                    projectile.velocity.X = -velocity1.X * 0.5f;
                  if ((double) projectile.velocity.Y != (double) velocity1.Y)
                    projectile.velocity.Y = -velocity1.Y * 0.5f;
                }
			return false;
		}
	}
}