using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace ForgottenMemories.Projectiles
{
	public class PurgeComet : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 34;
			projectile.height = 90;
			projectile.aiStyle = -1;
			projectile.ranged = true;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 1;
			projectile.tileCollide = true;
			projectile.timeLeft = 360;
			projectile.alpha = 255;
			projectile.light = 0.7f;
			projectile.extraUpdates = 1;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Comet");
		}
		
		public override void AI()
		{
			projectile.alpha -= 5;
			if (projectile.alpha <= 0)
			{
				projectile.alpha = 0;
			}
			
			projectile.localAI[0] += projectile.velocity.X / 2f;
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - MathHelper.PiOver2;
			for (int index1 = 0; index1 < 1; ++index1)
			{
				int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 173, 0.0f, 0.0f, 0, new Color(), 1f);
				Main.dust[index2].velocity *= 0.5f;
				Main.dust[index2].scale *= 1.3f;
				Main.dust[index2].fadeIn = 1f;
				Main.dust[index2].noGravity = true;
			}
			
			if (Main.rand.Next(48) == 0)
			{
				int index = Gore.NewGore(projectile.Center, new Vector2((float) (projectile.velocity.X * 0.200000002980232), (float) (projectile.velocity.Y * 0.200000002980232)), 16, 1f);
				Gore gore1 = Main.gore[index];
				gore1.velocity = (gore1.velocity * 0.66f);
				Gore gore2 = Main.gore[index];
				gore2.velocity = (gore2.velocity + (projectile.velocity * 0.3f));
			}
			
			
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item89, projectile.position);
			for (int i = 0; i < 7; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, -projectile.velocity.X, -projectile.velocity.Y, 0, new Color(), 1f);
				Main.dust[dust].scale = 1.95f;
				Main.dust[dust].noGravity = true;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			target.AddBuff(mod.BuffType("CosmicCurse"), 180, false);
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
			Texture2D texture2D = Main.projectileTexture[projectile.type];
			Microsoft.Xna.Framework.Color color25 = Lighting.GetColor((int)((double)projectile.position.X + (double)projectile.width * 0.5) / 16, (int)(((double)projectile.position.Y + (double)projectile.height * 0.5) / 16.0));
			int num3 = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
			int num4 = num3 * projectile.frame;
			Microsoft.Xna.Framework.Rectangle r = new Microsoft.Xna.Framework.Rectangle(0, num4, texture2D.Width, num3);
			Vector2 origin2 = r.Size() / 2f;
			Vector2 vector2 = (r.Size()/ 2f);
			  vector2.Y = 70;
			int num5;
			int num6 = 8;
			int num7 = 2;
			int num8 = 1;
			float num9 = 1f;
			float num10 = 0.0f;
			{
			  num6 = 9;
			  num7 = 3;
			  num9 = 0.5f;
			}
			int index1 = num8;
			while (num7 > 0 && index1 < num6 || num7 < 0 && index1 > num6)
			{
				//Microsoft.Xna.Framework.Color newColor = color1;
				index1++;
				Main.spriteBatch.Draw(Main.extraTexture[36], ((projectile.Center - Main.screenPosition) + projectile.Size.RotatedBy(projectile.rotation)), new Microsoft.Xna.Framework.Rectangle?(r), new Color(255, 255, 255, projectile.alpha), projectile.localAI[0], vector2, projectile.scale, SpriteEffects.None, 0.0f);
			}
			
			Microsoft.Xna.Framework.Color color29 = projectile.GetAlpha(color25);
			Main.spriteBatch.Draw(texture2D, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(r), color29, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
	}
}