using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.GhastlyEntBoss {
public class Air : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.width = 16;
		projectile.height = 16;
		projectile.aiStyle = 0;
		projectile.penetrate = 5;
		projectile.hostile = true;
        projectile.friendly = false;
		projectile.scale = 1.1f;
		projectile.tileCollide = false;
	}
	
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Spit Air");
		Main.projFrames[projectile.type] = 4;
	}
	
			public override void AI()
        {
			projectile.frameCounter++;
            if (projectile.frameCounter >= 8)
            {
                projectile.frameCounter = 0;
                projectile.frame = (projectile.frame + 1) % 4;
            } 
			
			if (Main.rand.Next(10) == 0)
		{
			Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 64, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
		}
		}
}
}	