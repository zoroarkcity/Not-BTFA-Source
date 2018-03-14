using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class Ball : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 40;
			projectile.aiStyle = 1;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.penetrate = 3;
			projectile.tileCollide = false;
			projectile.alpha = 255;
			projectile.timeLeft = 180;
			projectile.extraUpdates = 1;
			aiType = ProjectileID.Bullet;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laser");
		}

		public void Phase2Ring()
		{
			int target = Player.FindClosest(projectile.Center, 1, 1);
			Vector2 frickvector = Main.player[target].Center - projectile.Center;
			frickvector.Normalize();
			frickvector *= 2f;
				
			for (int i = 0; i < 10; ++i)
			{
				frickvector = frickvector.RotatedBy(System.Math.PI / 5);
				int p = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, frickvector.X, frickvector.Y, mod.ProjectileType("Ball"), projectile.damage, 1f, Main.myPlayer, 1f, 0);
				Main.projectile[p].netUpdate = true;

				if (projectile.ai[1] != 0)
				{
					Main.projectile[p].ai[0] = 4f;
					Main.projectile[p].ai[1] = projectile.ai[1];
					Main.projectile[p].timeLeft += 120;
				}
			}
				
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 75);
			projectile.Kill();
		}
		
		public override void AI()
		{
			if (projectile.ai[0] == 1f)
			{
				projectile.velocity *= 1.015f;
			}
            else if (projectile.ai[0] == 2f && projectile.timeLeft <= 75)
            {
                projectile.velocity *= 1.03f;
            }
			else if (projectile.ai[0] == 3f)
			{
				projectile.scale = 1.3f;
				
				if (projectile.timeLeft < 120)
					Phase2Ring();
			}
			else if (projectile.ai[0] == 4f)
			{
				projectile.velocity *= 1f + (float) System.Math.Abs(projectile.ai[1]);

				Vector2 acceleration = projectile.velocity.RotatedBy(System.Math.PI / 2);
				acceleration *= projectile.ai[1];
				
				projectile.velocity += acceleration;
			}
			
			if (Main.rand.Next(15) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 60, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 0.5f;
				Main.dust[dust].noGravity = true;
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
			for (int i = 0; i < 3; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 60);
				Main.dust[dust].scale = 2.5f;
				Main.dust[dust].noGravity = true;
			}
		}
		
	}
}