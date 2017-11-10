using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class GourdProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.JungleYoyo);
            aiType = ProjectileID.JungleYoyo;
            projectile.aiStyle = 99;
			projectile.width = 24;
            projectile.height = 24;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gourd");
		}

        public override void AI()
        {
            if (Main.rand.Next(15) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 64, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
        }
    }
}