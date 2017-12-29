using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.NPCs.Magnoliac.Projectiles
{
    public class VineSeed : ModProjectile
    {
 
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.aiStyle = 102;
            projectile.hostile = true;
			projectile.scale = 1f;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
			projectile.extraUpdates = 1;
			projectile.tileCollide = true;
        }
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vine Seed");
        } 
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0.3f);
			}
			return true;
		}
		public override void PostAI()
        {
            for (int num46 = projectile.oldPos.Length - 1; num46 > 0; num46--)
            {
                projectile.oldPos[num46] = projectile.oldPos[num46 - 1];
            }
            projectile.oldPos[0] = projectile.position;
        }
		public override void Kill(int timeLeft)
        {
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, -0.33f, mod.ProjectileType("BirdVine"), 20, 3f, projectile.owner);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, -0.66f, mod.ProjectileType("BirdVine"), 20, 3f, projectile.owner);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, -1f, mod.ProjectileType("BirdVine"), 20, 3f, projectile.owner);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, -1.33f, mod.ProjectileType("BirdVine"), 20, 3f, projectile.owner);
        }
    }
}