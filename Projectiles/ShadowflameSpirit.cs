using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class ShadowflameSpirit : ModProjectile
    {
    	
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.minionSlots = 1;
            projectile.alpha = 255;
            projectile.aiStyle = 54;
            projectile.timeLeft = 18000;
            projectile.penetrate = -1;
            projectile.timeLeft *= 5;
            projectile.minion = true;
            projectile.tileCollide = false;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadowflame Spirit");
			Main.projFrames[projectile.type] = 1;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			aiType = 317;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(4) == 0)
			{
				target.AddBuff(153, 360, false);
			}
		}

        public override void AI()
		{
			Player player = Main.player[projectile.owner];
			TgemPlayer modPlayer = (TgemPlayer)player.GetModPlayer(mod, "TgemPlayer");
			if (player.dead)
			{
				modPlayer.ShadowflameSpirit = false;
			}
			if (modPlayer.ShadowflameSpirit)
			{
				projectile.timeLeft = 2;
			}
			for (int i = 0; i <= 3; i++)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 0.7f;
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
