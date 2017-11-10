using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class NightArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14; //Projectile's width in pixels
            projectile.height = 14; //Projectile's height in pixels
            projectile.aiStyle = 1; //The ai style. Info on AI styles is in the tmodloader documentation
            projectile.friendly = true; //Determines if it can damage you
            projectile.ranged = true; //Damage type of the projectile.
            projectile.penetrate = 1; //How many enemies it can hit.
            projectile.timeLeft = 600; //How long in ticks the projectile lasts
            projectile.light = 0.5f; //light the projectile gives off
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Night Arrow");
		}
		
		    public override void Kill(int timeLeft)
			{
				int amountOfProjectiles = Main.rand.Next(3) + 1;
			
				for (int i = 0; i < amountOfProjectiles; ++i)
					{
						float sX = (float)Main.rand.Next(-60, 61) * 0.2f;
						float sY = (float)Main.rand.Next(-60, 61) * 0.2f;
						Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, mod.ProjectileType("NightStar"), 15, 5f, projectile.owner);
					}
			}
    }
}