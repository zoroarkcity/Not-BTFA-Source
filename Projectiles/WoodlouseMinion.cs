using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class WoodlouseMinion : ModProjectile
    {
    	
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 18;
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.minionSlots = 1;
            projectile.alpha = 0;
            projectile.aiStyle = 67;
            projectile.timeLeft = 18000;
            Main.projFrames[projectile.type] = 15;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            projectile.penetrate = -1;
            projectile.timeLeft *= 5;
            projectile.minion = true;
            aiType = 393;
            projectile.tileCollide = false;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Woodlouse");
		}

        public override void AI()
		{
			Player player = Main.player[projectile.owner];
			BTFAPlayer modPlayer = (BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer");
			if (player.dead)
			{
				modPlayer.WoodlouseMinion = false;
			}
			if (modPlayer.WoodlouseMinion)
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
