using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.NPCs.Magnoliac.Projectiles
{
    public class BirdVine : ModProjectile
    {
 
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 102;
            projectile.hostile = true;
			projectile.scale = 1f;
            projectile.penetrate = -1;
            projectile.timeLeft = 180;
			projectile.extraUpdates = 0;
			projectile.tileCollide = true;
        }
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bird Vine");
        } 
		public override void AI()
		{
			projectile.velocity.X = 0f;
		}
    }
}