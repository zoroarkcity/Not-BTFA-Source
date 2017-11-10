using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles {
public class MightBoom : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.width = 100;
		projectile.height = 100;
		projectile.aiStyle = 2;
		projectile.penetrate = -1;
		projectile.ranged = true;
        projectile.timeLeft = 10;
		projectile.friendly = true;
        projectile.alpha = 255;
        projectile.tileCollide = false;
	}
	
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("MightBoom");
		}
    public override bool PreAI()
{
    int amountOfDust = 5;
    for (int i = 0; i < amountOfDust; ++i)
    {
        projectile.tileCollide = false;
        int dust;
        dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 29, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        Main.dust[dust].scale = 1.5f;
		Main.dust[dust].noGravity = true;
    }
    return false;
}
    public virtual bool OnTileCollide(Vector2 oldVelocity)
    {
        return false;
    }

}
}	