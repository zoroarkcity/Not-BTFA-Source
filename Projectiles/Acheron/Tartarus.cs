using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Acheron
{
    public class Tartarus : ModProjectile
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tartarus's curse");
        }
        public override void SetDefaults()
        {
            projectile.width = 4;
            projectile.height = 4;
			projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true; 
            projectile.timeLeft = 2;
			projectile.extraUpdates = 1;
			projectile.scale = 1f;	
        }
        public override void AI()
        {
			Lighting.AddLight(projectile.position, 0f, 0f, 1f);
            for (int i = 0; i < 8; i++)
			{
				Vector2 velocity = new Vector2(Main.rand.Next(4, 8), 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(45) + i * 45));
				Dust newDust = Dust.NewDustDirect(projectile.Center, 0, 0, 20, velocity.X, velocity.Y);
				newDust.noGravity = true;
				newDust.fadeIn = 0.2f;
				newDust.scale = 2;
			}
		}
    }
}