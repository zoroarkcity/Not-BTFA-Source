using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class SlimeBall : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.aiStyle = 14;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 2;
			projectile.timeLeft = 100;
			Main.projFrames[projectile.type] = 3;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slime Ball");
		}
		
		
		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 6)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 3;
			}
			
		}
		
		public override void Kill(int timeLeft)
		{
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 4, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
		}
	}
}