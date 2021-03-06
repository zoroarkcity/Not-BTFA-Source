using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.Projectiles
{
    public class BlightedChakram : ModProjectile
    {
        public bool hasHitSomething = false;

		public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = 3;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = -1;
			projectile.extraUpdates = 2;
            projectile.timeLeft = 600;

			ProjectileID.Sets.TrailCacheLength[projectile.type] = 15;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
        } 
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Chakram");
		}

		public override bool PreDraw (SpriteBatch spriteBatch, Color lightColor)
		{
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (projectile.spriteDirection == -1)
				spriteEffects = SpriteEffects.FlipHorizontally;
			Microsoft.Xna.Framework.Color color25 = Lighting.GetColor((int)(projectile.Center.X / 16), (int)(projectile.Center.Y / 16));

			int num157 = 15; //number of trailing sprites to draw
			int num156 = Main.projectileTexture[projectile.type].Height; //ypos of lower right corner of sprite to draw
			int y3 = 0; //ypos of upper left corner of sprite to draw

			Texture2D texture2D3 = mod.GetTexture("Projectiles/BlightedChakram");

			Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(0, y3, texture2D3.Width, num156);
			Vector2 origin2 = rectangle.Size() / 2f;

			int arg_5ADA_0 = projectile.type;
			int arg_5AE7_0 = projectile.type;
			int arg_5AF4_0 = projectile.type;
			int num158 = 2;
			int num159 = 1;
			float value3 = 1f;
			float num160 = 0f;
			
			int num161 = num159;
			while (((num158 > 0 && num161 < num157) || (num158 < 0 && num161 > num157))) //trail
			{
				Microsoft.Xna.Framework.Color color26 = color25;
				color26 = projectile.GetAlpha(color26);		
				{
					goto IL_6899;
				}
				//color26 = Microsoft.Xna.Framework.Color.Lerp(color26, Microsoft.Xna.Framework.Color.Transparent, 0.75f);
				color26.A += (byte)(150);
				
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
				Vector2 value4 = (projectile.oldPos[num161]);
				float num165 = projectile.rotation;
				SpriteEffects effects = spriteEffects;
				Main.spriteBatch.Draw(texture2D3, value4 + projectile.Size / 2f - Main.screenPosition + new Vector2(0, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color26, num165 + projectile.rotation * num160 * (float)(num161 - 1) * projectile.spriteDirection, origin2, projectile.scale, effects, 0f);
				goto IL_6881;
			}

			Main.spriteBatch.Draw(texture2D3, projectile.position + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), lightColor, projectile.rotation, origin2, projectile.scale, spriteEffects, 0f);
			return false;
		}

		public override void AI()
		{
			//Lighting.AddLight(projectile.Center, 0.8052f, 0.1818f, 1f);

			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, 0f, 0f); 
			Main.dust[dust].scale = 1f;
			Main.dust[dust].noGravity = true;
			
			if (projectile.velocity.X > 0)
				projectile.spriteDirection = 1;
            else
				projectile.spriteDirection = -1;
			
			Vector2 target = projectile.position;

            float minimumRange = 800f;

            bool flag = false;
            
			if (!hasHitSomething && projectile.ai[0] != 1f && projectile.ai[1] > 10f)
            {
				for (int index = 0; index < 200; ++index)
				{
					NPC npc = Main.npc[index];
					
					if (npc.CanBeChasedBy((object) projectile, false))
					{
						Vector2 distance = npc.Center - projectile.Center;
						float length = distance.Length();
						if (length < minimumRange && Collision.CanHit(projectile.Center, 1, 1, npc.position, npc.width, npc.height) &&
							Math.Abs(projectile.velocity.ToRotation() - distance.ToRotation()) < 2.35619449) //dont target enemies directly behind self
						{
							minimumRange = length;
							target = npc.Center;
							flag = true;
						}
					}
				}
            }

            if (!flag)
            {
				target = projectile.Center + projectile.velocity * 100;

				if (projectile.ai[1] >= 30)
				{
					projectile.ai[0] = 1f;
					projectile.ai[1] = 0f;
					projectile.netUpdate = true;
				}
            }

            float num8 = 0.25f;
            Vector2 vector2 = target - projectile.Center;
            float num12 = 12f / vector2.Length();
			vector2 *= num12;

            if (projectile.velocity.X < vector2.X)
            {
				projectile.velocity.X += num8;
				if (projectile.velocity.X < 0 && vector2.X > 0)
				{
					projectile.velocity.X += num8 * 2f;
				}
			}
			else if (projectile.velocity.X > vector2.X)
			{
				projectile.velocity.X -= num8;
				if (projectile.velocity.X > 0 && vector2.X < 0)
				{
					projectile.velocity.X -= num8 * 2f;
				}
			}
			if (projectile.velocity.Y < vector2.Y)
			{
				projectile.velocity.Y += num8;
				if (projectile.velocity.Y < 0 && vector2.Y > 0)
				{
					projectile.velocity.Y += num8 * 2f;
				}
			}
			else if (projectile.velocity.Y > vector2.Y)
			{
				projectile.velocity.Y -= num8;
				if (projectile.velocity.Y > 0 && vector2.Y < 0)
				{
					projectile.velocity.Y -= num8 * 2f;
				}
            }

			//Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("BChakramContact"), projectile.damage, projectile.knockBack, projectile.owner);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			hasHitSomething = true;
			target.immune[projectile.owner] = 5;
			target.GetGlobalNPC<BTFANPC>(mod).blightChakramHits++;
			if (target.GetGlobalNPC<BTFANPC>(mod).blightChakramHits == 4)
			{
				target.GetGlobalNPC<BTFANPC>(mod).blightChakramHits = 0;
				target.immune[projectile.owner] = 0;
				
				for (int i = 0; i < 5; i++)
				{
					float posX = target.position.X + Main.rand.Next(target.width);
					float posY = target.position.Y + Main.rand.Next(target.height);
					int p = Projectile.NewProjectile(posX, posY, 0, 0, mod.ProjectileType("BlightBoomRange"), damage * 2, knockback * 1.5f, projectile.owner);
					Main.projectile[p].ranged = false;
					Main.projectile[p].thrown = true;
					Main.projectile[p].scale = 1f + Main.rand.Next(-75, 51) / 100f;
					Main.projectile[p].Damage();
				}

				Main.PlaySound(SoundID.Item20, target.position);
			}
			
			target.AddBuff(mod.BuffType("BlightFlame"), 420, false);
		}
    }
}