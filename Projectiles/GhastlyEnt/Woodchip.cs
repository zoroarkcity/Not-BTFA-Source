using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles.GhastlyEnt {
public class Woodchip : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.width = 5;
		projectile.height = 5;
		projectile.penetrate = 1;
		projectile.ranged = true;
		projectile.friendly = true;
		projectile.aiStyle = 1;
        projectile.timeLeft = 90;
	}
	
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Woodchip");
		}
	
	public override bool OnTileCollide(Vector2 oldVelocity)
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 7);
			Main.dust[dust].scale = 1.5f;
			Main.dust[dust].noGravity = true;
			return true;
		}


}	
}