using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles.GhastlyEnt 
{
	public class Leaf : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.penetrate = 1;
			projectile.tileCollide = true;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.hostile = false;
			projectile.scale = 1f;
			Main.projFrames[projectile.type] = 5;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leaf");
		}
		
		
		public override void AI()
		{
			projectile.rotation = projectile.velocity.ToRotation();
			projectile.frameCounter++;
			if (projectile.frameCounter >= 3)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 5;
			} 
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 3);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(186, 500, false);
		}
	}
}	