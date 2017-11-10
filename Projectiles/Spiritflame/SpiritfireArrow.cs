using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Spiritflame
{
	public class SpiritfireArrow : ModProjectile
	{
		Vector2 gayvector = new Vector2(0f, -5f);
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 1;
			projectile.ranged = true;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 1;
			projectile.tileCollide = true;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
			projectile.scale = 0.95f;
			projectile.timeLeft = 360;
			projectile.light = 0.5f;
			//projectile.scale = 0.5f;
			//projectile.extraUpdates = 1;
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Microsoft.Xna.Framework.Color color25 = Lighting.GetColor((int)((double)projectile.position.X + (double)projectile.width * 0.5) / 16, (int)(((double)projectile.position.Y + (double)projectile.height * 0.5) / 16.0));
			color25 *= 0.35f;
			Texture2D texture2D3 = Main.projectileTexture[projectile.type];
			int num156 = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
			int y3 = num156 * projectile.frame;
			Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(0, y3, texture2D3.Width, num156);
			Vector2 origin2 = rectangle.Size() / 2f;
			Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.position + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), lightColor, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(mod.GetTexture("GlowMasks/SpiritfireArrow"), projectile.position + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Color.White, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(mod.GetTexture("GlowMasks/SpiritfireArrow"), projectile.position + (gayvector * 1.5f) + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color25, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(mod.GetTexture("GlowMasks/SpiritfireArrow"), projectile.position + (-gayvector * 1.5f) + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color25, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			gayvector = gayvector.RotatedBy(System.Math.PI / 35);
			return false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spiritfire Arrow");
		}
		
		public override void AI()
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 160, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 160);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			
			
			for (int i = 0; i < Main.rand.Next(2) + 1; i++)
			{
				Vector2 vector2 = (projectile.velocity/2).RotatedBy(MathHelper.ToRadians(Main.rand.Next(360)));
				Projectile.NewProjectile(projectile.Center, vector2, mod.ProjectileType("SpiritfireEmber"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
			}
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 34);
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			target.AddBuff(mod.BuffType("Spiritflame"), 180, false);
			Main.PlaySound(SoundID.Item34, (int)projectile.position.X, (int)projectile.position.Y);
		}
	}
}