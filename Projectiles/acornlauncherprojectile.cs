using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class acornlauncherprojectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 8; 
            projectile.height = 8;  
            projectile.aiStyle = 1; 
            projectile.friendly = true; 
            projectile.hostile = false; 
            projectile.ranged = true; 
            projectile.timeLeft = 150;
			projectile.scale = 1f;
			projectile.extraUpdates = 0;
            aiType = ProjectileID.Bullet;		
        }
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acorn");
        } 
        public override void AI()
        {
            int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 7); // replace this with wood dust
            Main.dust[dust2].velocity /= 1f;
            Main.dust[dust2].scale = 0.7f;
			Main.dust[dust2].noGravity = true;
			Vector2 vector2 = projectile.velocity * 1.05f;
            projectile.velocity = vector2;
	    }
		public override void Kill(int timeLeft)
        {
			Main.PlaySound(0, projectile.position);
            for (int index1 = 0; index1 < 16; ++index1)
            {
                int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 4, 0.0f, 0.0f, 100, new Color(), 1.2f);
                Main.dust[index2].noGravity = true;
                Main.dust[index2].velocity *= 0.5f;
                Main.dust[index2].velocity += projectile.velocity * 0.2f;
          }
        }
    }
}