using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.Projectiles
{
    public class trashcan : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = 2;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 400;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
        } 
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 39, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].scale = 0.8f;
			Main.dust[dust].noGravity = true;		
		}
		
		public override bool OnTileCollide (Vector2 velocity1)
		{
			
			if ((double) projectile.velocity.Y != (double) velocity1.Y || (double) projectile.velocity.X != (double) velocity1.X)
                {
                  if ((double) projectile.velocity.X != (double) velocity1.X)
                    projectile.velocity.X = -velocity1.X / 2;
                  if ((double) projectile.velocity.Y != (double) velocity1.Y)
                    projectile.velocity.Y = -velocity1.Y / 2;
                }
			return false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Trashcan");
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			
			if (Main.rand.Next(2) == 0)
				target.AddBuff(mod.BuffType("Bleeding"), 900, false);
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
			int num157 = 8;
			int num158 = 2;
			int num159 = 1;
			float value3 = 1f;
			float num160 = 0f;
			
			{
				//num157 = 3;
				num158 = 1;
				value3 = 8f;
				//rectangle = new Microsoft.Xna.Framework.Rectangle(25 * projectile.frame, 0, 36, 14);
				origin2 = rectangle.Size() / 2f;
			}
			
			
			int num161 = num159;
			while ((num158 > 0 && num161 < num157) || (num158 < 0 && num161 > num157))
			{
				Microsoft.Xna.Framework.Color color26 = color25;
				color26 = projectile.GetAlpha(color26);		
				{
					goto IL_6899;
				}
				
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
				color26.A /= (byte)2;
				Main.spriteBatch.Draw(texture2D3, value4 + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color26, num165 + projectile.rotation * num160 * (float)(num161 - 1) * -(float)spriteEffects.HasFlag(SpriteEffects.FlipHorizontally).ToDirectionInt(), origin2, projectile.scale, effects, 0f);
				goto IL_6881;
			}
					
			Microsoft.Xna.Framework.Color color29 = projectile.GetAlpha(color25);
			Main.spriteBatch.Draw(texture2D3, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color29, projectile.rotation, origin2, projectile.scale, spriteEffects, 0f);
			return true;
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item89, projectile.position);
			for (int i = 0; i < 10; i++)
			{
				int num5 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 8, 0f, 0f, 0, new Color(), 1.5f);
				Main.dust[num5].noGravity = true;
				Main.dust[num5].velocity *= 0.75f;
			}
			
			for (int i = 0; i < 5; i++)
			{
				int num5 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 39, 0f, 0f, 0, new Color(), 1.5f);
				Main.dust[num5].noGravity = true;
				Main.dust[num5].velocity *= 0.75f;
			}
		}
    }
}