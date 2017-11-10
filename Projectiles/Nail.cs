using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class Nail : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            ProjectileID.Sets.MinionShot[projectile.type] = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
            projectile.extraUpdates = 1;
            projectile.alpha = 0;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nail");
		}
	
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
        }
    }
}