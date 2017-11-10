using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ForgottenMemories.Projectiles
{
    public class IceCube : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 6;
            projectile.height = 6;
            projectile.friendly = true;
            projectile.melee = true;
			projectile.aiStyle = 2;
			projectile.timeLeft = 380;
            projectile.penetrate = 3;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Cube");
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.velocity.Y = 0;
			return false;
		}
		
	    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			if (Main.rand.Next(6) == 0)
			{
				target.AddBuff(BuffID.Frostburn, 180, false);
			}
		}
    }
}