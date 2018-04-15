using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.Projectiles
{
    public class BlightedChakram : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = 3;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = -1;
			projectile.extraUpdates = 2;
            projectile.timeLeft = 600;   
        } 
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Chakram");
		}
		
		public override void AI()
		{
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("BChakramContact"), projectile.damage, 5f, projectile.owner);
			//Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("BChakramContact"), (int)(51 * Main.player[projectile.owner].thrownDamage), 5f, projectile.owner);
		}
    }
}