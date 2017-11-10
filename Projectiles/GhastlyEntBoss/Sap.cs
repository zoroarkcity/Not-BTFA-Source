using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ForgottenMemories.Projectiles.GhastlyEntBoss
{
    public class Sap : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.hostile = true;
			projectile.aiStyle = -1;
            projectile.penetrate = -1;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sap");
		}
		
		public override void AI()
		{
			projectile.ai[0]++;
			projectile.velocity.Y = 10;
			if (projectile.ai[0] > 600)
				projectile.alpha += 5;
			
			if (projectile.alpha >= 255)
				projectile.Kill();
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.velocity.Y = 0;
			return false;
		}
    }
}