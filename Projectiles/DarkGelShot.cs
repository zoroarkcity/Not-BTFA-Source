using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles {
public class DarkGelShot : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.width = 5;
		projectile.height = 5;
		projectile.penetrate = -1;
		projectile.ranged = true;
		projectile.friendly = true;
		projectile.alpha = 0;
		projectile.aiStyle = 1;
        projectile.timeLeft = 56;
        projectile.alpha = 255;
	}
	
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Gel");
		}


    public override void AI()
    {
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("BouncyDust"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
    }
}	
}