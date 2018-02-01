using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class BlightOrb2 : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 74;
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.minionSlots = 0;
            projectile.alpha = 0;
            projectile.timeLeft = 18000;
            Main.projFrames[projectile.type] = 1;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            projectile.penetrate = -1;
            projectile.timeLeft *= 5;
            projectile.minion = true;
            projectile.tileCollide = false;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blight Orb");
		}

        public override void AI()
		{
			Player player = Main.player[projectile.owner];
			BTFAPlayer modPlayer = (BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer");
			
			for (int k = 0; k < 200; k++)
			{
				if (Main.projectile[k].active && Main.projectile[k].type == mod.ProjectileType("BlightOrb") && Main.projectile[k].owner == projectile.owner)
				{
					projectile.Center = Main.projectile[k].Center;
				}
			}
			
			projectile.rotation += 0.1f;
			
			if (modPlayer.BlightOrb)
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
