using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class TrueNightArrow : ModProjectile
    {
		bool fireDust = false;
        public override void SetDefaults()
        {
            projectile.width = 14; //Projectile's width in pixels
            projectile.height = 14; //Projectile's height in pixels
            projectile.aiStyle = -1; //The ai style. Info on AI styles is in the tmodloader documentation
            projectile.friendly = true; //Determines if it can damage you
            projectile.ranged = true; //Damage type of the projectile.
            projectile.penetrate = 1; //How many enemies it can hit.
            projectile.timeLeft = 600; //How long in ticks the projectile lasts
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Arrow");
		}
		
		public override void Kill(int timeLeft)
		{
			int amountOfProjectiles = Main.rand.Next(4) + 1;
			
			for (int i = 0; i < amountOfProjectiles; ++i)
				{
					Vector2 newVect1 = new Vector2 (8, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(360)));
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect1.X, newVect1.Y, mod.ProjectileType("CursedLightning"), 15, 5f, projectile.owner);
				}
		}
			
		public override void AI()
		{
			if (fireDust == false)
			{
				for (int i = 0; i < 10; ++i)
				{
					Vector2 newVect1 = projectile.velocity.RotatedBy(MathHelper.ToRadians(Main.rand.Next(-30, 30)));
					int dust1;
					dust1 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 74, newVect1.X * 0.5f, newVect1.Y * 0.5f);
					Main.dust[dust1].scale = 1f;
					Main.dust[dust1].noGravity = true;
				}
				fireDust = true;
			}
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			int dust;
			dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 75, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].scale = 0.7f;
			Main.dust[dust].noGravity = true;
			
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
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(1) == 0)
            {
                target.AddBuff(39, 180, false);
            }
        }
    }
}