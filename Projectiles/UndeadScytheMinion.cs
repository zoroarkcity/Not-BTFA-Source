using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class UndeadScytheMinion : ModProjectile
    {
    	
        public override void SetDefaults()
        {
			projectile.penetrate = -1;
			projectile.tileCollide = false;
            projectile.aiStyle = 67;
            Main.projFrames[projectile.type] = 15;
			projectile.minionSlots = 0;
			projectile.friendly = true;
			projectile.timeLeft = 900; //lasts 15 seconds 
			projectile.width = 44;
			projectile.height = 26;
            projectile.damage = 8;
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Underling");
            Main.projPet[projectile.type] = true;
		}
        
		public override bool MinionContactDamage()
        {
            return true;
        }
		
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.penetrate == 0)
            {
                projectile.Kill();
            }
            return false;
        }
    }
}

