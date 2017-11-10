using System;
using Microsoft.Xna.Framework;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles
{
	public class BloodShurikenProj : ModProjectile
	{
		int cap;
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = 0;
			projectile.penetrate = -1;
			projectile.thrown = true;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
			projectile.friendly = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood Shuriken");
		}
		
		public override void Kill(int timeLeft)
		{
			if (Main.rand.Next(3) == 0)
			{
				Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("BloodShuriken"));
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
			Vector2 vector2 = new Vector2(projectile.width/2, projectile.height/2);
			int dust;
			Vector2 newVect = new Vector2 (8, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(45)));
			Vector2 newVect2 = newVect.RotatedBy(MathHelper.ToRadians(45));
			Vector2 newVect3 = newVect.RotatedBy(MathHelper.ToRadians(90));
			Vector2 newVect4 = newVect.RotatedBy(MathHelper.ToRadians(135));
			Vector2 newVect5 = newVect.RotatedBy(MathHelper.ToRadians(180));
			Vector2 newVect6 = newVect.RotatedBy(MathHelper.ToRadians(225));
			Vector2 newVect7 = newVect.RotatedBy(MathHelper.ToRadians(270));
			Vector2 newVect8 = newVect.RotatedBy(MathHelper.ToRadians(315));
			dust = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("UndeadDust"), newVect.X, newVect.Y);
			int dust2 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("UndeadDust"), newVect2.X, newVect2.Y);
			int dust3 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("UndeadDust"), newVect3.X, newVect3.Y);
			int dust4 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("UndeadDust"), newVect4.X, newVect4.Y);
			int dust5 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("UndeadDust"), newVect5.X, newVect5.Y);
			int dust6 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("UndeadDust"), newVect6.X, newVect6.Y);
			int dust7 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("UndeadDust"), newVect7.X, newVect7.Y);
			int dust8 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("UndeadDust"), newVect8.X, newVect8.Y);
			Main.dust[dust].noGravity = true;
			Main.dust[dust2].noGravity = true;
			Main.dust[dust3].noGravity = true;
			Main.dust[dust4].noGravity = true;
			Main.dust[dust5].noGravity = true;
			Main.dust[dust6].noGravity = true;
			Main.dust[dust7].noGravity = true;
			Main.dust[dust8].noGravity = true;
			Main.dust[dust].scale = 2;
			Main.dust[dust2].scale = 2;
			Main.dust[dust3].scale = 2;
			Main.dust[dust4].scale = 2;
			Main.dust[dust5].scale = 2;
			Main.dust[dust6].scale = 2;
			Main.dust[dust7].scale = 2;
			Main.dust[dust8].scale = 2;
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
				color26 = Microsoft.Xna.Framework.Color.Lerp(color26, Microsoft.Xna.Framework.Color.Red, 0.5f);
				
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
		
		public override void AI()
		{
			projectile.rotation += MathHelper.Pi / 60;
			cap--;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.player[projectile.owner];
			if (cap == 0)
			{
				int quickthing = Main.rand.Next(2) + 1;
                player.HealEffect(quickthing);
                player.statLife += (quickthing);
				cap = 10;
			}
		}
	}
}	