using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class CherryBomb : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 36;
			projectile.height = 36;
			projectile.aiStyle = 2;
			projectile.friendly = true;
			projectile.penetrate = 1;
			Main.projFrames[projectile.type] = 2;
			projectile.thrown = true;
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
			Projectile.NewProjectile(projectile.position.X + 20, projectile.position.Y + 20, 0f, 0f, mod.ProjectileType("wooboomfriendly"), projectile.damage, 0f, projectile.owner, 0f, 0f);
			Main.PlaySound(SoundID.Item89, projectile.position);
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 13;
		}
	}
}