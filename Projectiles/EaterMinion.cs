using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class EaterMinion : ModProjectile
    {
    	
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 32;
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.minionSlots = 1;
            projectile.alpha = 0;
            projectile.aiStyle = 54;
            projectile.timeLeft = 18000;
            Main.projFrames[projectile.type] = 8;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            projectile.penetrate = -1;
            projectile.timeLeft *= 5;
            projectile.minion = true;
            aiType = 317;
            projectile.tileCollide = false;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eater of Souls");
		}

        public override void AI()
		{
			Player player = Main.player[projectile.owner];
			BTFAPlayer modPlayer = (BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer");
			if (player.dead)
			{
				modPlayer.EaterMinion = false;
			}
			if (modPlayer.EaterMinion)
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
