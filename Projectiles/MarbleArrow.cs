using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class MarbleArrow : ModProjectile
	{
		int index1 = 999;
		int a = 0;
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			//projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
			projectile.magic = true;
			projectile.alpha = 20;
			projectile.light = 0.5f;
			projectile.timeLeft = 360;
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 10; i++)
			{
				int num5 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 55, 0f, 0f, 200, new Color(), 0.5f);
				Main.dust[num5].noGravity = true;
				Main.dust[num5].velocity *= 0.75f;
				Main.dust[num5].fadeIn = 1.3f;
			}
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
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Energy Arrow");
		}
		
		
		public override void AI()
		{
			if (a == 0)
			{
				float num = 16f;
				for (int index1 = 0; (double) index1 < (double) num; ++index1)
				{
					Vector2 v = (Vector2.UnitX * 0.0f + -Vector2.UnitY.RotatedBy((double) index1 * (6.28318548202515 / (double) num), new Vector2()) * new Vector2(1f, 4f)).RotatedBy((double) projectile.velocity.ToRotation(), new Vector2());
					int index2 = Dust.NewDust(projectile.Center, 0, 0, 55, 0.0f, 0.0f, 200, new Color(), 1f);
					Main.dust[index2].scale = 1.5f;
					Main.dust[index2].fadeIn = 1.3f;
					Main.dust[index2].noGravity = true;
					Main.dust[index2].position = projectile.Center + v;
					Main.dust[index2].velocity = projectile.velocity * 0.0f + v.SafeNormalize(Vector2.UnitY) * 1f;
				}
				a++;
			}
			
			if (projectile.timeLeft < 350)
			{
				projectile.tileCollide = true;
			}
			int num1 = 25;
			if ((double) projectile.ai[0] == 0.0)
			{
				projectile.ai[1] += 1f;
				if (projectile.ai[1] >= 45f)
				{
					float num984 = 0.98f;
					float num985 = 0.35f;
					if (projectile.type == 636)
					{
						num984 = 0.995f;
						num985 = 0.15f;
					}
					projectile.ai[1] = 45f;
					projectile.velocity.X = projectile.velocity.X * num984;
					projectile.velocity.Y = projectile.velocity.Y + num985;
				}
				projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
			}
			
			if ((double) projectile.ai[0] == 1.0)
			{
				projectile.ignoreWater = true;
				projectile.tileCollide = false;
				int num2 = 15;
				bool flag1 = false;
				bool flag2 = false;
				++projectile.localAI[0];
				if ((double) projectile.localAI[0] % 30.0 == 0.0)
					flag2 = true;
				int index = (int) projectile.ai[1];
				if ((double) projectile.localAI[0] >= (double) (60 * num2))
					flag1 = true;
				else if (index < 0 || index >= 200)
					flag1 = true;
				else if (Main.npc[index].active && !Main.npc[index].dontTakeDamage)
				{
					projectile.Center = Main.npc[index].Center - projectile.velocity * 2f;
					projectile.gfxOffY = Main.npc[index].gfxOffY;
					if (flag2)
						Main.npc[index].HitEffect(0, 1.0);
				}
				else
					flag1 = true;
				if (flag1)
					projectile.Kill();
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("MarbleArrow"), 900, false);
			
			projectile.ai[0] = 1f;
			for (int i = 0; i <= 200; i++)
			{
				if (Main.npc[i] == target)
				{
					index1 = i;
					projectile.ai[1] = (float) index1;
				}
			}
			projectile.velocity = (target.Center - projectile.Center) * 0.75f;
			projectile.netUpdate = true;
			
			projectile.damage = 0;
			int length = 6;
			Point[] pointArray = new Point[length];
			int num2 = 0;
			for (int x = 0; x < 1000; ++x)
			{
				if (x != projectile.whoAmI && Main.projectile[x].active && (Main.projectile[x].owner == Main.myPlayer && Main.projectile[x].type == projectile.type) && ((double) Main.projectile[x].ai[0] == 1.0 && (double) Main.projectile[x].ai[1] == (double) index1))
				{
					pointArray[num2++] = new Point(x, Main.projectile[x].timeLeft);
					if (num2 >= pointArray.Length)
						break;
				}
			}
			if (num2 >= pointArray.Length)
			{
				int index2 = 0;
				for (int index3 = 1; index3 < pointArray.Length; ++index3)
				{
					if (pointArray[index3].Y < pointArray[index2].Y)
						index2 = index3;
				}
				Main.projectile[pointArray[index2].X].Kill();
			}
		}
	}
}