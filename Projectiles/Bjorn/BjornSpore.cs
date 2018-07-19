using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles.Bjorn
{
	public class BjornSpore : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.aiStyle = -1;
			projectile.penetrate = -1;
			projectile.timeLeft = 120;
            projectile.hostile = true;
            projectile.tileCollide = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spore");
		}
		
		public override void AI()
		{
            projectile.rotation += projectile.velocity.X / 2f;
            projectile.velocity *= 0.98f;

            if (projectile.timeLeft < 51)
                projectile.alpha += 5;
		}
	}
}	