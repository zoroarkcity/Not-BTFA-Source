using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;


namespace ForgottenMemories.Projectiles
{
    public class LightningSphere : ModProjectile
    {
		int timer = 0;
        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.aiStyle = -1;
			projectile.alpha = 100;
            projectile.friendly = true;
            projectile.magic = true;
			projectile.timeLeft = 300;
            projectile.penetrate = -1;
			projectile.tileCollide = true;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lightning Sphere");
		}
		
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D3 = Main.projectileTexture[projectile.type];
			int num156 = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
			int y3 = num156 * projectile.frame;
			Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(0, y3, texture2D3.Width, num156);
			Vector2 origin2 = rectangle.Size() / 2f;
			Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.position + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Color.White, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
		
		   public override void AI()
		{
			projectile.rotation += 0.5f;
			Vector2 move = Vector2.Zero;
			float distance = 700f;
			bool target = false;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].immortal && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
				{
					Vector2 newMove = Main.npc[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						newMove.Normalize();
						move = newMove;
						distance = distanceTo;
						target = true;
					}
				}
			}
			timer++;
			if (target && timer >= 24)
			{
				int proj = Projectile.NewProjectile(projectile.Center.X + 25, projectile.Center.Y + 5, move.X * 15f, move.Y * 15f, mod.ProjectileType("ChainLightning2"), projectile.damage * 3, 5f, projectile.owner);
				timer = 0;
			}
		}
    }
}