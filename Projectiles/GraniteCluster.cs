using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class GraniteCluster : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 1;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
            projectile.timeLeft = 600;
            projectile.alpha = 0;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Cluster");
		}
		
		public override bool OnTileCollide (Vector2 velocity1)
		{
			
			if ((double) projectile.velocity.Y != (double) velocity1.Y || (double) projectile.velocity.X != (double) velocity1.X)
                {
                  if ((double) projectile.velocity.X != (double) velocity1.X)
                    projectile.velocity.X = -velocity1.X;
                  if ((double) projectile.velocity.Y != (double) velocity1.Y)
                    projectile.velocity.Y = -velocity1.Y;
                }
			return false;
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < Main.rand.Next(3) + 1; i++)
			{
				Vector2 vector2 = new Vector2(-projectile.velocity.X/2, -projectile.velocity.Y/2).RotatedBy(MathHelper.ToRadians(Main.rand.Next(45)));
				int kek = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, vector2.X, vector2.Y, mod.ProjectileType("GraniteEnergy"), (int)(projectile.damage * 0.75), 5f, projectile.owner);
			}
			
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 59);
				Main.dust[dust].scale = 2f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
		}


        public override void AI()
        {
			projectile.rotation += 0.3f;
        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			target.immune[projectile.owner] = 10;
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
			SpriteEffects spriteEffects = SpriteEffects.None;
			Microsoft.Xna.Framework.Color color25 = Lighting.GetColor((int)((double)projectile.position.X + (double)projectile.width * 0.5) / 16, (int)(((double)projectile.position.Y + (double)projectile.height * 0.5) / 16.0));
			Texture2D texture2D3 = Main.projectileTexture[projectile.type];
			int num156 = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
			int y3 = num156 * projectile.frame;
			Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(0, y3, texture2D3.Width, num156);
			Vector2 origin2 = rectangle.Size() / 2f;
			int arg_5ADA_0 = projectile.type;
			int arg_5AE7_0 = projectile.type;
			int arg_5AF4_0 = projectile.type;
			int num157 = 10;
			int num158 = 2;
			int num159 = 1;
			float value3 = 1f;
			float num160 = 0f;
			
			
			int num161 = num159;
			while ((num158 > 0 && num161 < num157) || (num158 < 0 && num161 > num157))
			{
				Microsoft.Xna.Framework.Color color26 = color25;
				color26 = projectile.GetAlpha(color26);		
				{
					goto IL_6899;
				}
				color26 = Microsoft.Xna.Framework.Color.Lerp(color26, Microsoft.Xna.Framework.Color.Blue, 0.5f);
				
				IL_6881:
				num161 += num158;
				continue;
				IL_6899:
				float num164 = (float)(num157 - num161);
				if (num158 < 0)
				{
					num164 = (float)(num159 - num161);
				}
				color26 *= num164 / ((float)ProjectileID.Sets.TrailCacheLength[projectile.type] * 1.5f);
				Vector2 value4 = projectile.oldPos[num161];
				float num165 = projectile.rotation;
				SpriteEffects effects = spriteEffects;
				if (ProjectileID.Sets.TrailingMode[projectile.type] == 2)
				{
					num165 = projectile.oldRot[num161];
					effects = ((projectile.oldSpriteDirection[num161] == -1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None);
				}
				Main.spriteBatch.Draw(texture2D3, value4 + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color26, num165 + projectile.rotation * num160 * (float)(num161 - 1) * -(float)spriteEffects.HasFlag(SpriteEffects.FlipHorizontally).ToDirectionInt(), origin2, projectile.scale, effects, 0f);
				goto IL_6881;
			}
					
			Microsoft.Xna.Framework.Color color29 = projectile.GetAlpha(color25);
			Main.spriteBatch.Draw(texture2D3, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color29, projectile.rotation, origin2, projectile.scale, spriteEffects, 0f);
			return true;
		}
    }
}