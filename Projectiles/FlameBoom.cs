using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class FlameBoom : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 10;
			Main.projFrames[projectile.type] = 5;
			projectile.tileCollide = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flambullet");
		}
		
		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 2)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 5;
			} 
			if (Main.rand.Next(4) == 0)
			{
				int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 127, 0.0f, 0.0f, 0, new Color(), 1f);
				Main.dust[index2].velocity *= 0.5f;
				Main.dust[index2].scale *= 1.3f;
				Main.dust[index2].fadeIn = 1f;
				Main.dust[index2].noGravity = true;
			}
		}
	}
}