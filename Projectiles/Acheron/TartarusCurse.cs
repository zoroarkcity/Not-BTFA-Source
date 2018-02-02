using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles.Acheron
{
	public class TartarusCurse : ModProjectile
	{
		int timer = 0;
		float dist;
		float dist2;
		public override void SetDefaults()
		{
			projectile.width = 48;
			projectile.netImportant = true;
			projectile.height = 48;
			projectile.aiStyle = -1;
			projectile.penetrate = -1;
			Main.projPet[projectile.type] = true;
			projectile.minion = true;
			projectile.alpha = 255;
			projectile.tileCollide = false;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
			
			Main.projFrames[projectile.type] = 4;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Curse of Tartarus");
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
			
			Player player = Main.player[projectile.owner];
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (player.direction == -1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
			
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
				
				Main.spriteBatch.Draw(texture2D3, value4 + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color26, num165 + projectile.rotation * num160 * (float)(num161 - 1) * -(float)spriteEffects.HasFlag(SpriteEffects.FlipHorizontally).ToDirectionInt(), origin2, projectile.scale, effects, 0f);
				goto IL_6881;
			}
					
			Microsoft.Xna.Framework.Color color29 = projectile.GetAlpha(color25);
			Main.spriteBatch.Draw(texture2D3, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color29, projectile.rotation, origin2, projectile.scale, spriteEffects, 0f);
			return false;
		}
		
		public override void AI()
		{
			Lighting.AddLight(projectile.position, 0f, 0f, 1f);
			projectile.frameCounter++;
			if (projectile.frameCounter > 8)
			{
			   projectile.frame++;
               projectile.frameCounter = 1;
			}
			if (projectile.frame > 3)
            {
               projectile.frame = 0;
            }
			
			
			if (projectile.alpha > 0)
				projectile.alpha -= 5;
			
			Player player = Main.player[projectile.owner];
			BTFAPlayer modPlayer = player.GetModPlayer<BTFAPlayer>(mod);
			if (modPlayer.Tartarus)
			{
				projectile.timeLeft = 2;
			}
			projectile.ai[1] += 0.1f;
			int mememaster = (int)Math.Sin(projectile.ai[1]) * 10;
			
			projectile.position.Y = (player.position.Y - 50) + mememaster;
			projectile.position.X = player.Center.X - 24;
			
			projectile.ai[0]++;
			Lighting.AddLight(projectile.position, 0f, 0f, 1f);
			
			if ((int)projectile.ai[0] % 60 == 0 && Main.npc[(int)projectile.ai[1]].active && projectile.Distance(Main.npc[(int)projectile.ai[1]].Center) < 300)
			{
				int p = Projectile.NewProjectile(Main.npc[(int)projectile.ai[1]].Center, Vector2.Zero, mod.ProjectileType("Tartarus"), projectile.damage + (int)(Main.npc[(int)projectile.ai[1]].defense / 2), 0, projectile.owner, 0, 0);
				if (Main.expertMode)
					Main.projectile[p].damage += Main.npc[(int)projectile.ai[1]].defense / 4;
			}
			
			else for(int index2 = 0; index2 < 200; index2++)
			{
				if (Main.npc[index2].CanBeChasedBy((object) projectile, false) && Main.npc[index2].friendly == false && !Main.npc[index2].immortal && !Main.npc[index2].dontTakeDamage && Main.npc[index2].active)
				{
					dist2 = projectile.Distance(Main.npc[index2].Center);
					if (dist2 < ((int)dist | 300))
					{
						dist = dist2;
						projectile.ai[1] = index2;
					}
				}
			}
		}
	}
}