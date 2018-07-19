using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles.Bjorn
{
	public class BjornPygmySpear : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = 0;
			projectile.hostile = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 600;
            //projectile.noGravity = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pygmy Spear");
		}
		
		public override void AI()
		{
            projectile.velocity.Y += 0.1f;
            projectile.rotation = projectile.velocity.ToRotation();
        }
	}
}