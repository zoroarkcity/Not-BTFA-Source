using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.GhastlyEntBoss {
public class ForestEnergy : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.width = 20;
		projectile.height = 20;
		projectile.aiStyle = 0;
		projectile.penetrate = 5;
		projectile.hostile = true;
        projectile.friendly = false;
		projectile.alpha = 100;
		projectile.scale = 1.5f;
	}
	
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Forest Blast");
		}
	public override bool PreAI()
{
    projectile.rotation += 0.05f;
	 Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 34, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
    return true;
}
}
}	