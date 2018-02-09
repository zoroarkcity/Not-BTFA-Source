using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class SlimeGuard : ModProjectile
    {
    	
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.BabySlime);
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.minionSlots = 0;
			projectile.friendly = true;
			projectile.width = 44;
			projectile.height = 26;
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slime Guard");
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            aiType = ProjectileID.BabySlime;
			Main.projFrames[projectile.type] = 6;
			
		}
		
        public override void AI()
        {
			Player player = Main.player[projectile.owner];
			BTFAPlayer modPlayer = player.GetModPlayer<BTFAPlayer>(mod);
			
			if (modPlayer.slimeGuard)
			{
				projectile.timeLeft = 2;
			}
			else
			{
				projectile.Kill();
			}
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
