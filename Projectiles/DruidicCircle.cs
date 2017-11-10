using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace ForgottenMemories.Projectiles
{
	public class DruidicCircle : ModProjectile
	{
		int ai;
		int alph;
		public override void SetDefaults()
		{
			projectile.width = 26;
			projectile.height = 26;
			projectile.alpha = (int) byte.MaxValue;
			projectile.hostile = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.light = 1f;
			Main.projFrames[projectile.type] = 4;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Druidic Circle");
		}
		
		public override void AI()
		{
			if (!Main.npc[(int) projectile.ai[1]].active)
			{
			  projectile.Kill();
			}
			else
			{
				ai++;
				alph = ai - 500;
				if (alph < 0)
					alph = 0;
				projectile.rotation += (float) Math.PI / 300f;
				projectile.scale = ai / 100f;
				if ((double) projectile.scale > 1.0)
					projectile.scale = 1f;
				projectile.alpha = (int) ((double) byte.MaxValue * (1.0 - (double) projectile.scale));
				float num1 = 300f;
				if ((double) ai >= 100.0)
					num1 = MathHelper.Lerp(300f, 400f, (float) (((double) ai - 100.0) / 200.0));
				if ((double) num1 > 400.0)
					num1 = 400f;
				if ((double) projectile.ai[0] >= 500.0)
				{
					projectile.alpha = (int) MathHelper.Lerp(0.0f, (float) byte.MaxValue, (float) (((double) ai - 500.0) / 100.0));
					num1 = MathHelper.Lerp(400f, 600f, (float) (((double) ai - 500.0) / 100.0));
					projectile.rotation = projectile.rotation + (float) Math.PI / 300f;
				}
				if (Main.rand.Next(4) == 0)
				{
					float num2 = num1;
					Vector2 vector2 = new Vector2((float) Main.rand.Next(-10, 11), (float) Main.rand.Next(-10, 11));
					float num3 = (float) Main.rand.Next(3, 9);
					vector2.Normalize();
					int index = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 163, 0.0f, 0.0f, 100, new Color(), 1f);
					Main.dust[index].noGravity = true;
					Main.dust[index].position = (projectile.Center + (vector2 * num2));
					if (Main.rand.Next(8) == 0)
					{
						Main.dust[index].velocity = ((vector2 * -num3) * 3f);
						Dust dust = Main.dust[index];
						dust.scale = dust.scale + 0.5f;
					}
					else
						Main.dust[index].velocity = (vector2 * -num3);
				}
				if (Main.rand.Next(2) == 0)
				{	
					Vector2 vector2 = new Vector2((float) Main.rand.Next(-10, 11), (float) Main.rand.Next(-10, 11));
					vector2.Normalize();
					float num2 = (float) Main.rand.Next(3, 9);
					int index = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 163, 0.0f, 0.0f, 100, new Color(), 1.5f);
					Main.dust[index].noGravity = true;
					Main.dust[index].position = (projectile.Center + (vector2 * 30f));
					if (Main.rand.Next(8) == 0)
					{
					  Main.dust[index].velocity = ((vector2 * -num2) * 3f);
					  Dust dust = Main.dust[index];
					  dust.scale = dust.scale + 0.5f;
					}
					else
					  Main.dust[index].velocity = (vector2 * -num2);
				}
				
				if ((double) ai >= 30.0 && Main.netMode != 2)
				{
					Player player = Main.player[Main.myPlayer];
					if (player.active && !player.dead && ((double) projectile.Distance(player.Center) <= (double) num1 && player.FindBuffIndex(mod.BuffType("DruidBane")) == -1))
						player.AddBuff(mod.BuffType("DruidBane"), 2, true);
				}
				if ((double) ai < 600.0)
					return;
				projectile.Kill();
			}
			
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
			SpriteEffects spriteEffects = SpriteEffects.None;
			Microsoft.Xna.Framework.Color color1 = Lighting.GetColor((int)((double)projectile.position.X + (double)projectile.width * 0.5) / 16, (int)(((double)projectile.position.Y + (double)projectile.height * 0.5) / 16.0));
			Texture2D texture2D3 = Main.projectileTexture[projectile.type];
			int num156 = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
			int y3 = num156 * projectile.frame;
			Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(0, y3, texture2D3.Width, num156);
			Vector2 origin2 = rectangle.Size() / 2f;
			
			float num3 = 300f;
			if ((double) ai >= 100.0)
				num3 = MathHelper.Lerp(300f, 400f, (float) (((double) ai - 100.0) / 200.0));
			if ((double) num3 > 400.0)
				num3 = 400f;
			if ((double) ai >= 500.0)
				num3 = MathHelper.Lerp(400f, 600f, (float) (((double) ai - 500.0) / 100.0));
			float rotation = projectile.rotation;
			Texture2D tex = Main.projectileTexture[projectile.type];
			Microsoft.Xna.Framework.Color alpha = projectile.GetAlpha(color1);
			alpha.A = (byte)(((int)alpha.A / 2) + alph);
			int num5 = (int) ((double) ai / 6.0);
			Vector2 spinningpoint = new Vector2(0f, -num3);
			for (int index = 0; (double) index < 10.0; ++index)
			{
				Microsoft.Xna.Framework.Rectangle r = tex.Frame(1, 5, 0, (num5 + index) % 5);
				float num6 = rotation + 0.6283185f * (float) index;
				Vector2 vector2 = (((spinningpoint.RotatedBy((double) num6)/ 3f)+ projectile.Center)- Main.screenPosition);
				Main.spriteBatch.Draw(tex, vector2, new Microsoft.Xna.Framework.Rectangle?(r), alpha, num6, (r.Size()/ 2f), projectile.scale, SpriteEffects.None, 0.0f);
			}
			for (int index = 0; (double) index < 20.0; ++index)
			{
				Microsoft.Xna.Framework.Rectangle r = tex.Frame(1, 5, 0, (num5 + index) % 5);
				float num6 = (float) (-(double) rotation + 0.314159274101257 * (double) index) * 2f;
				Vector2 vector2 = ((spinningpoint.RotatedBy((double) num6)+ projectile.Center)- Main.screenPosition);
				Main.spriteBatch.Draw(tex, vector2, new Microsoft.Xna.Framework.Rectangle?(r), alpha, num6, (r.Size()/ 2f), projectile.scale, SpriteEffects.None, 0.0f);
			}			
			return false;
		}
	}
}