using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Dune
{
	public class CactusThorn : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 6;
			projectile.height = 12;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 200;
			projectile.extraUpdates = 2;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cactus Thorn");
		}
		
		

		public override void AI()
		{	
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			if (projectile.timeLeft <= 25)
			{
				projectile.alpha += 10;
			}
		}
	}
}