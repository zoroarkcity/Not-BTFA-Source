using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class CreeperMinion : ModProjectile
    {
    	
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.minionSlots = 1;
            projectile.alpha = 0;
            projectile.aiStyle = 54;
            projectile.timeLeft = 18000;
            Main.projFrames[projectile.type] = 1;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            projectile.penetrate = -1;
            projectile.timeLeft *= 5;
            projectile.minion = true;
            aiType = 317;
            projectile.tileCollide = false;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Creeper");
		}

        public override void AI()
		{
			Player player = Main.player[projectile.owner];
			TgemPlayer modPlayer = (TgemPlayer)player.GetModPlayer(mod, "TgemPlayer");
			if (player.dead)
			{
				modPlayer.CreeperMinion = false;
			}
			if (modPlayer.CreeperMinion)
			{
				projectile.timeLeft = 2;
			}
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
