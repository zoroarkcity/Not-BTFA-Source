using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace ForgottenMemories.Projectiles.Arterius
{
    public class BrimstoneBig : ModProjectile
    {
        public int trackTimer = -1;
		public int ringTimer = 0;
        public bool almostHitPlayer = false;
        public bool almostHitPlayerTwice = false;
        
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood Laser");
		}
        public override void SetDefaults()
        {
            projectile.width = 5;
			projectile.height = 5;
			projectile.aiStyle = -1;
			projectile.hostile = true;
			projectile.alpha = 255;
			projectile.scale = 1f;
			projectile.extraUpdates = 1;
			projectile.penetrate = 3;
			projectile.ignoreWater = true;
			projectile.scale = 1.5f;
            projectile.tileCollide = false;
            projectile.timeLeft = 1200;
        }

        public override void AI()
        {
            Vector2 distance = Main.player[projectile.owner].Center - projectile.Center;

            if (almostHitPlayer)
                trackTimer++;
            else if (distance.Length() <= 150)
            {
                projectile.velocity.Normalize();
                almostHitPlayer = true;
            }

            if (trackTimer == 91)
            {
                distance.Normalize();
                distance *= 15;
                
                if (!almostHitPlayerTwice)
                {
                    almostHitPlayer = false;
                    almostHitPlayerTwice = true;
                    trackTimer = 0;
                    distance += Main.player[projectile.owner].velocity / 2; //will not track on last bolt
                }

                projectile.velocity = distance;
            }
            
            if (projectile.alpha > 0)
			{
				projectile.alpha -= 25;
			}
			if (projectile.alpha < 0)
			{
				projectile.alpha = 0;
			}
			
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			Lighting.AddLight((int) projectile.Center.X / 16, (int) projectile.Center.Y / 16, 0.8f, 0f, 0f);
			float num1 = 150f;
			float num2 = 3f;
			if ((double) projectile.ai[1] == 0.0)
			{
				projectile.localAI[0] += num2;
				if ((double) projectile.localAI[0] > (double) num1)
					projectile.localAI[0] = num1;
			}
			else
			{
				projectile.localAI[0] -= num2;
				if ((double) projectile.localAI[0] <= 0.0)
				{
					projectile.Kill();
					return;
				}
			}
        }
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item89, projectile.position);
			projectile.position.X += (float) (projectile.width / 2);
			projectile.position.Y += (float) (projectile.height / 2);
			projectile.width = (int) (48.0 * (double) projectile.scale);
			projectile.height = (int) (48.0 * (double) projectile.scale);
			projectile.position.X -= (float) (projectile.width / 2);
			projectile.position.Y -= (float) (projectile.height / 2);
			for (int index = 0; index < 8; ++index)
			  Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
			for (int index1 = 0; index1 < 32; ++index1)
			{
			  int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 130, 0.0f, 0.0f, 100, new Color(255, 0, 0, 0), 2.5f);
			  Main.dust[index2].noGravity = true;
			  Main.dust[index2].velocity *= 3f;
			  int index3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 130, 0.0f, 0.0f, 100, new Color(255, 0, 0, 0), 1.5f);
			  Main.dust[index3].velocity *= 2f;
			  Main.dust[index3].noGravity = true;
			}
			for (int index1 = 0; index1 < 2; ++index1)
			{
			  int index2 = Gore.NewGore(projectile.position + new Vector2((float) (projectile.width * Main.rand.Next(100)) / 100f, (float) (projectile.height * Main.rand.Next(100)) / 100f) - Vector2.One * 10f, new Vector2(), Main.rand.Next(61, 64), 1f);
			  Main.gore[index2].velocity *= 0.3f;
			  Main.gore[index2].velocity.X += (float) Main.rand.Next(-10, 11) * 0.05f;
			  Main.gore[index2].velocity.Y += (float) Main.rand.Next(-10, 11) * 0.05f;
			}
			if (projectile.owner == Main.myPlayer)
			{
			  projectile.localAI[1] = -1f;
			  projectile.maxPenetrate = 0;
			  projectile.Damage();
			}
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			if (projectile.velocity.Length() <= 1f)
			{
				if (ringTimer == 0 || ringTimer == 15 || ringTimer == 30 || ringTimer == 45)
				{
					Projectile.NewProjectile(projectile.Center, Vector2.Zero, mod.ProjectileType("BrimstoneRing"), projectile.damage, 0, Main.myPlayer, 0, 0);
				}
				
				ringTimer++;
				return false;
			}
			else
				ringTimer = 0;
			
			Microsoft.Xna.Framework.Color color25 = Lighting.GetColor((int)((double)projectile.position.X + (double)projectile.width * 0.5) / 16, (int)(((double)projectile.position.Y + (double)projectile.height * 0.5) / 16.0));
			float num150 = (float)(Main.projectileTexture[projectile.type].Width - projectile.width) * 0.5f + (float)projectile.width * 0.5f;
			Microsoft.Xna.Framework.Rectangle value7 = new Microsoft.Xna.Framework.Rectangle((int)Main.screenPosition.X - 500, (int)Main.screenPosition.Y - 500, Main.screenWidth + 1000, Main.screenHeight + 1000);
			if (projectile.getRect().Intersects(value7))
			{
				Vector2 value8 = new Vector2(projectile.position.X - Main.screenPosition.X + num150, projectile.position.Y - Main.screenPosition.Y + (float)(projectile.height / 2) + projectile.gfxOffY);
				float num176 = 150f * ((projectile.ai[0] == 1) ? 1.5f : 1f);
				float scaleFactor = 3f;
				if (projectile.ai[1] == 1f)
				{
					num176 = (float)((int)projectile.localAI[0]);
				}
				int num43;
				for (int num177 = 1; num177 <= (int)projectile.localAI[0]; num177 = num43 + 1)
				{
					Vector2 value9 = Vector2.Normalize(projectile.velocity) * (float)num177 * scaleFactor;
					Microsoft.Xna.Framework.Color color32 = projectile.GetAlpha(color25);
					color32 *= (num176 - (float)num177) / num176;
					color32.A = 0;
					SpriteBatch arg_7727_0 = Main.spriteBatch;
					Texture2D arg_7727_1 = Main.projectileTexture[projectile.type];
					Vector2 arg_7727_2 = value8 - value9;
					Microsoft.Xna.Framework.Rectangle? sourceRectangle2 = null;
					arg_7727_0.Draw(arg_7727_1, arg_7727_2, sourceRectangle2, color32, projectile.rotation, new Vector2(num150, (float)(projectile.height / 2)), projectile.scale * ((projectile.ai[0] == 1) ? 2f : 1f), SpriteEffects.None, 0f);
					num43 = num177;
				}
			}
			return false;
		}
    }
}
