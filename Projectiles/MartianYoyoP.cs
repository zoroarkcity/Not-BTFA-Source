using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class MartianYoyoP : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(555);
            aiType = 555;
            projectile.aiStyle = 99;
			projectile.width = 24;
            projectile.height = 24;
			projectile.penetrate = -1;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Extraterrestrial");
		}

        public override void AI()
        {
            if (Main.rand.Next(10) == 0)
				{
					Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 226, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(5) >= 2)
			{
				int amountOfProjectiles = Main.rand.Next(1, 4);
			
				for (int i = 0; i < amountOfProjectiles; ++i)
					{
						float sX = (float)Main.rand.Next(-60, 61) * 0.2f;
						float sY = (float)Main.rand.Next(-60, 61) * 0.2f;
						int noose;
						noose = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, 449, (projectile.damage/2), 5f, projectile.owner);
						Main.projectile[noose].friendly = true;
						Main.projectile[noose].hostile = false;
						Main.projectile[noose].timeLeft = 30;
					}
			}
		}
    }
}