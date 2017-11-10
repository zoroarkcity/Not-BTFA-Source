using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class wooballcherry : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 36;
			projectile.height = 36;
			projectile.aiStyle = 2;
			projectile.hostile = true;
			projectile.penetrate = 1;
			Main.projFrames[projectile.type] = 2;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cherry Bomb");
		}
		
		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 2;
			} 
			
			if (projectile.velocity.X > 0f)
			{
				projectile.spriteDirection = (projectile.direction = -1);
			}
			else if (projectile.velocity.X < 0f)
			{
				projectile.spriteDirection = (projectile.direction = 1);
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.position.X + 20f, projectile.position.Y + 20f, 0f, 0f, mod.ProjectileType("wooboom"), projectile.damage, 0f, projectile.owner, 0f, 0f);
			Main.PlaySound(SoundID.Item89, projectile.position);
		}
	}
}