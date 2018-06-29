using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Utilities;
using Terraria.World.Generation;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Revenant
{
    public class Rune : ModProjectile
    {
		Vector2 Location;
		Vector2 Location2;
		bool checkedfornpc = false;
		bool launchedatplayer = false;
        public override void SetDefaults()
        {
			projectile.hostile = true;
			projectile.friendly = false;
            projectile.width = 18;
            projectile.height = 18;
			projectile.alpha = 255;
			projectile.timeLeft = 300;
			projectile.light = 0.5f;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rune");
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
			SpriteEffects spriteEffects = SpriteEffects.None;
			Microsoft.Xna.Framework.Color color25 = Lighting.GetColor((int)((double)projectile.position.X + (double)projectile.width * 0.5) / 16, (int)(((double)projectile.position.Y + (double)projectile.height * 0.5) / 16.0));
			Texture2D texture2D3 = (projectile.ai[1] == 0) ? Main.projectileTexture[projectile.type] : ((projectile.ai[1] == 1) ? mod.GetTexture("Projectiles/Revenant/Rune2") : mod.GetTexture("Projectiles/Revenant/Rune3"));
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
				color26 = Microsoft.Xna.Framework.Color.Lerp(color26, Microsoft.Xna.Framework.Color.Purple, 0.5f);
				
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
				Vector2 value4 = (projectile.oldPos[num161] + (2 * projectile.Center))/3;
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
			if(projectile.alpha > 0)
			{
				projectile.alpha -= 25;
			}
			else
			{
				projectile.alpha = 0;
			}
			
            Player player = Main.player[Player.FindClosest(projectile.Center, 0, 0)];
			
			if(Main.npc[(int)projectile.ai[0]].active && projectile.timeLeft > 240)
			{
				if (!checkedfornpc)
				{
					projectile.ai[1] = Main.rand.Next(3);
					Location = projectile.Center - Main.npc[(int)projectile.ai[0]].Center;
					Location2 = projectile.Center - Main.npc[(int)projectile.ai[0]].Center;
					checkedfornpc = true;
					projectile.netUpdate = true;
				}
				else
				{
					Location2 = Location.RotatedBy((MathHelper.Pi / 60));
					Location = Location2;
					projectile.Center = Location + Main.npc[(int)projectile.ai[0]].Center;
				}
			}
			
			else if (!launchedatplayer)
			{
				projectile.netUpdate = true;
				launchedatplayer = true;
				Vector2 v = (player.Center - projectile.Center);
				v.Normalize();
				v *= 6;
				projectile.velocity = v;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 8; i++)
			{
				Vector2 velocity = new Vector2(4, 0).RotatedBy((Main.rand.Next(45) + i * 45).ToRadians());
				Dust newDust = Dust.NewDustDirect(projectile.Center, 0, 0, 173, velocity.X, velocity.Y);
				newDust.noGravity = true;
				newDust.scale = 2;
			}
		}
	}
}
