using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;


namespace ForgottenMemories.Projectiles
{
    public class LightningVortex : ModProjectile
    {
		int timer = 0;
        public override void SetDefaults()
        {
            projectile.width = 38;
            projectile.height = 38;
            projectile.aiStyle = -1;
			projectile.alpha = 255;
            projectile.friendly = true;
            projectile.ranged = true;
			projectile.timeLeft = 170;
            projectile.penetrate = -1;
			projectile.tileCollide = false;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vortex");
		}
		
		   public override void AI()
		{
			if (Main.rand.Next(5) == 0)
			{
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 226, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].noGravity = true;
			}
			
			if (projectile.alpha >= 50)
			{
				projectile.alpha -= 5;
			}
			
			if (Main.rand.Next(5) == 0)
			{
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 211, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].noGravity = true;
			}
			projectile.rotation += 0.5f;
			projectile.velocity.X *= 0.95f;
			projectile.velocity.Y *= 0.95f;
			Vector2 move = Vector2.Zero;
			float distance = 220f;
			bool target = false;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && Main.npc[k].type != 488)
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
			if (target && timer >= 17)
			{
				int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, move.X * 15f, move.Y * 15f, 255, (int)(projectile.damage * 0.4), 5f, projectile.owner);
				Main.projectile[proj].ranged = true;
				Main.projectile[proj].magic = false;
				Main.projectile[proj].friendly = true;
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].tileCollide = false;
				Main.projectile[proj].timeLeft = 120;
				timer = 0;
			}
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
		
		public override void Kill(int timeLeft)
		{
			Vector2 vector2 = new Vector2(projectile.width/2, projectile.height/2);
			int dust;
			Vector2 newVect = new Vector2 (6, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(45)));
			Vector2 newVect2 = newVect.RotatedBy(MathHelper.ToRadians(45));
			Vector2 newVect3 = newVect.RotatedBy(MathHelper.ToRadians(90));
			Vector2 newVect4 = newVect.RotatedBy(MathHelper.ToRadians(135));
			Vector2 newVect5 = newVect.RotatedBy(MathHelper.ToRadians(180));
			Vector2 newVect6 = newVect.RotatedBy(MathHelper.ToRadians(225));
			Vector2 newVect7 = newVect.RotatedBy(MathHelper.ToRadians(270));
			Vector2 newVect8 = newVect.RotatedBy(MathHelper.ToRadians(315));
			dust = Dust.NewDust(projectile.position + vector2, 0, 0, 226, newVect.X, newVect.Y);
			int dust2 = Dust.NewDust(projectile.position + vector2, 0, 0, 226, newVect2.X, newVect2.Y);
			int dust3 = Dust.NewDust(projectile.position + vector2, 0, 0, 226, newVect3.X, newVect3.Y);
			int dust4 = Dust.NewDust(projectile.position + vector2, 0, 0, 226, newVect4.X, newVect4.Y);
			int dust5 = Dust.NewDust(projectile.position + vector2, 0, 0, 226, newVect5.X, newVect5.Y);
			int dust6 = Dust.NewDust(projectile.position + vector2, 0, 0, 226, newVect6.X, newVect6.Y);
			int dust7 = Dust.NewDust(projectile.position + vector2, 0, 0, 226, newVect7.X, newVect7.Y);
			int dust8 = Dust.NewDust(projectile.position + vector2, 0, 0, 226, newVect8.X, newVect8.Y);
			Main.dust[dust].noGravity = true;
			Main.dust[dust2].noGravity = true;
			Main.dust[dust3].noGravity = true;
			Main.dust[dust4].noGravity = true;
			Main.dust[dust5].noGravity = true;
			Main.dust[dust6].noGravity = true;
			Main.dust[dust7].noGravity = true;
			Main.dust[dust8].noGravity = true;
			Main.dust[dust2].scale = 1.5f;
			Main.dust[dust3].scale = 1.5f;
			Main.dust[dust4].scale = 1.5f;
			Main.dust[dust5].scale = 1.5f;
			Main.dust[dust6].scale = 1.5f;
			Main.dust[dust7].scale = 1.5f;
			Main.dust[dust8].scale = 1.5f;
		}
    }
}