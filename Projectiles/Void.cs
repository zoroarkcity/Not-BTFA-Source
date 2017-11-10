using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class Void : ModProjectile
    {
		int counter = 0;
        public override void SetDefaults()
        {
            projectile.width = 80;
			projectile.height = 80;
			//projectile.aiStyle = 108;
			projectile.friendly = true;
			projectile.alpha = (int) byte.MaxValue;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.hostile = false;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.scale = 0f;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Void Energy");
		}

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 43);
        }

        public override void AI()
        {
			projectile.Center = new Vector2(projectile.ai[0], projectile.ai[1]);
			counter++;
			if (counter <= 50)
			{
				if (Main.rand.Next(4) == 0)
				{
					Vector2 spinningpoint = Vector2.UnitY.RotatedByRandom(6.28318548202515);
					Dust dust = Main.dust[Dust.NewDust((projectile.Center - (spinningpoint * 30f)), 0, 0, 229, 0.0f, 0.0f, 0, new Color(), 1f)];
					dust.noGravity = true;
					dust.position = (projectile.Center - (spinningpoint * (float) Main.rand.Next(10, 21)));
					dust.velocity = (spinningpoint.RotatedBy(1.57079637050629) * 4f);
					dust.scale = 0.5f + Main.rand.NextFloat();
					dust.fadeIn = 0.5f;
				}
				if (Main.rand.Next(4) == 0)
				{
					Vector2 spinningpoint = Vector2.UnitY.RotatedByRandom(6.28318548202515);
					Dust dust = Main.dust[Dust.NewDust((projectile.Center - (spinningpoint * 30f)), 0, 0, 240, 0.0f, 0.0f, 0, new Color(), 1f)];
					dust.noGravity = true;
					dust.position = (projectile.Center - (spinningpoint * 30f));
					dust.velocity = (spinningpoint.RotatedBy(-1.57079637050629) * 2f);
					dust.scale = 0.5f + Main.rand.NextFloat();
					dust.fadeIn = 0.5f;
				}	
			}
			if ((double) counter <= 90.0)
			{
				projectile.scale = (float) (((double) counter) / 90.0);
				projectile.alpha = (int) byte.MaxValue - (int) ((double) byte.MaxValue * (double) projectile.scale);
				projectile.rotation = projectile.rotation - 0.1570796f;
			
				if (Main.rand.Next(5) == 0)
				{
					int num5 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, 0f, 0f, 240, default(Color), 0.5f);
					Main.dust[num5].noGravity = true;
					Main.dust[num5].velocity *= 0.75f;
					Main.dust[num5].fadeIn = 1.3f;
					Vector2 vector = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
					vector.Normalize();
					vector *= (float)Main.rand.Next(50, 100) * 0.04f;
					Main.dust[num5].velocity = vector;
					vector.Normalize();
					vector *= 34f;
					Main.dust[num5].position = projectile.Center - vector;
				}
			}
			
			else if ((double) counter <= 180.0)
			{
				projectile.scale = 1f;
				projectile.alpha = 0;
				projectile.rotation = projectile.rotation - (float) Math.PI / 60f;
				if (Main.rand.Next(5) == 0)
				{
					int num5 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, 0f, 0f, 240, default(Color), 0.5f);
					Main.dust[num5].noGravity = true;
					Main.dust[num5].velocity *= 0.75f;
					Main.dust[num5].fadeIn = 1.3f;
					Vector2 vector = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
					vector.Normalize();
					vector *= (float)Main.rand.Next(50, 100) * 0.04f;
					Main.dust[num5].velocity = vector;
					vector.Normalize();
					vector *= 34f;
					Main.dust[num5].position = projectile.Center - vector;
				}
			}
			
			else
			{
				projectile.scale = (float) (1.0 - ((double) counter - 180.0) / 60.0);
				projectile.alpha = (int) byte.MaxValue - (int) ((double) byte.MaxValue * (double) projectile.scale);
				projectile.rotation = projectile.rotation - (float) Math.PI / 30f;
				if (projectile.alpha >= (int) byte.MaxValue)
					projectile.Kill();
				if (Main.rand.Next(5) == 0)
				{
					int num5 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, 0f, 0f, 240, default(Color), 0.5f);
					Main.dust[num5].noGravity = true;
					Main.dust[num5].velocity *= 0.75f;
					Main.dust[num5].fadeIn = 1.3f;
					Vector2 vector = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
					vector.Normalize();
					vector *= (float)Main.rand.Next(50, 100) * 0.04f;
					Main.dust[num5].velocity = vector;
					vector.Normalize();
					vector *= 34f;
					Main.dust[num5].position = projectile.Center - vector;
				}
			}
        }
		
		public override bool PreDraw (SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 vector60 = projectile.Center + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition;
			Texture2D texture2D31 = Main.projectileTexture[projectile.type];
			Microsoft.Xna.Framework.Color color25 = Lighting.GetColor((int)((double)projectile.position.X + (double)projectile.width * 0.5) / 16, (int)(((double)projectile.position.Y + (double)projectile.height * 0.5) / 16.0));
			Microsoft.Xna.Framework.Color alpha4 = new Color(198, 76, 255, projectile.GetAlpha(color25).A);
			Microsoft.Xna.Framework.Color kys2 = new Color(79, 208, 255, alpha4.A);
			alpha4 = Microsoft.Xna.Framework.Color.Lerp(alpha4, kys2, (float)(1/240));
			Vector2 origin8 = new Vector2((float)texture2D31.Width, (float)texture2D31.Height) / 2f;
			SpriteEffects spriteEffects = SpriteEffects.None;
			//if (projectile.type == 578 || projectile.type == 579 || projectile.type == 641)
			{
				Microsoft.Xna.Framework.Color color55 = alpha4 * 0.8f;
				color55.A /= 2;
				Microsoft.Xna.Framework.Color color56 = Microsoft.Xna.Framework.Color.Lerp(projectile.GetAlpha(color25), Microsoft.Xna.Framework.Color.Black, 0.5f);
				color56.A = alpha4.A;
				float num278 = 0.95f + (projectile.rotation * 0.75f).ToRotationVector2().Y * 0.1f;
				color56 *= num278;
				float scale12 = 0.6f + projectile.scale * 0.6f * num278;
				projectile.height = (int)(60 * scale12);
				projectile.width = (int)(60 * scale12);
				SpriteBatch arg_DCA2_0 = Main.spriteBatch;
				Texture2D arg_DCA2_1 = Main.extraTexture[50];
				Vector2 arg_DCA2_2 = vector60;
				Microsoft.Xna.Framework.Rectangle? sourceRectangle2 = null;
				arg_DCA2_0.Draw(arg_DCA2_1, arg_DCA2_2, sourceRectangle2, color56, -projectile.rotation + 0.35f, origin8, scale12, spriteEffects ^ SpriteEffects.FlipHorizontally, 0f);
				SpriteBatch arg_DCEE_0 = Main.spriteBatch;
				Texture2D arg_DCEE_1 = Main.extraTexture[50];
				Vector2 arg_DCEE_2 = vector60;
				sourceRectangle2 = null;
				arg_DCEE_0.Draw(arg_DCEE_1, arg_DCEE_2, sourceRectangle2, alpha4, -projectile.rotation, origin8, projectile.scale, spriteEffects ^ SpriteEffects.FlipHorizontally, 0f);
				SpriteBatch arg_DD3E_0 = Main.spriteBatch;
				Texture2D arg_DD3E_1 = texture2D31;
				Vector2 arg_DD3E_2 = vector60;
				sourceRectangle2 = null;
				arg_DD3E_0.Draw(arg_DD3E_1, arg_DD3E_2, sourceRectangle2, color55, -projectile.rotation * 0.7f, origin8, projectile.scale, spriteEffects ^ SpriteEffects.FlipHorizontally, 0f);
				SpriteBatch arg_DD9D_0 = Main.spriteBatch;
				Texture2D arg_DD9D_1 = Main.extraTexture[50];
				Vector2 arg_DD9D_2 = vector60;
				sourceRectangle2 = null;
				arg_DD9D_0.Draw(arg_DD9D_1, arg_DD9D_2, sourceRectangle2, alpha4 * 0.8f, projectile.rotation * 0.5f, origin8, projectile.scale * 0.9f, spriteEffects, 0f);
				alpha4.A = 0;
			}
			bool flag27 = false;
			if (!(flag27 | (projectile.type == 464 && projectile.ai[1] != 1f)))
			{
				SpriteBatch arg_E055_0 = Main.spriteBatch;
				Texture2D arg_E055_1 = texture2D31;
				Vector2 arg_E055_2 = vector60;
				Microsoft.Xna.Framework.Rectangle? sourceRectangle2 = null;
				arg_E055_0.Draw(arg_E055_1, arg_E055_2, sourceRectangle2, alpha4, projectile.rotation, origin8, projectile.scale, spriteEffects, 0f);
			}
			return false;
		}
    }       
}
