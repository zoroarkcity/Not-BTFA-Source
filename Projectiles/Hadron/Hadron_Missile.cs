using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using System;

namespace ForgottenMemories.Projectiles.Hadron
{
    public class Hadron_Missile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hadron Missile");
        } 
        public override void SetDefaults()
        {
            projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 1;
			projectile.timeLeft = 100;
			aiType = ProjectileID.Bullet;;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.ignoreWater = true;
			Main.projFrames[projectile.type] = 3;
        }
        public override void AI()
		{
			Player player = Main.player[projectile.owner];
			{         	
				projectile.frameCounter++;
			
				if (projectile.frameCounter > 4)
				{
					projectile.frame++;
					projectile.frameCounter = 1;
				}
				if (projectile.frame > 2)
				{
					projectile.frame = 0;
				}
			}
			for (int index1 = 0; index1 < 3; ++index1)
			{
				float x = projectile.position.X - projectile.velocity.X / 3f * (float) index1;
				float y = projectile.position.Y - projectile.velocity.Y / 3f * (float) index1;
				int index2 = Dust.NewDust(new Vector2(x, y), 1, 1, 160, 0.0f, 0.0f, 0, new Color(), 1f);
				Main.dust[index2].alpha = projectile.alpha;
				Main.dust[index2].position.X = x;
				Main.dust[index2].position.Y = y;
				Main.dust[index2].scale = (float) Main.rand.Next(50, 80) * 0.013f;
				Main.dust[index2].velocity *= 0.0f;
				Main.dust[index2].noGravity = true;
			}
			for (int index1 = 0; index1 < 6; ++index1)
			{
				float x = projectile.position.X - projectile.velocity.X / 5f * (float) index1;
				float y = projectile.position.Y - projectile.velocity.Y / 5f * (float) index1;
				int index2 = Dust.NewDust(new Vector2(x, y), 1, 1, 160, 0.0f, 0.0f, 0, new Color(), 1f);
				Main.dust[index2].alpha = projectile.alpha;
				Main.dust[index2].position.X = x;
				Main.dust[index2].position.Y = y;
				Main.dust[index2].scale = (float) Main.rand.Next(20, 50) * 0.013f;
				Main.dust[index2].velocity *= 0.0f;
				Main.dust[index2].noGravity = true;
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			SpriteEffects effects1 = SpriteEffects.None;
				Texture2D texture = Main.projectileTexture[projectile.type];
				int height = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
				int y2 = height * projectile.frame;
				Vector2 position = (projectile.position - (0.5f * projectile.velocity) + new Vector2((float) projectile.width, (float) projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition).Floor();
				float num1 = 1f;
				Main.spriteBatch.Draw(mod.GetTexture("Projectiles/Hadron/Hadron_Missile"), position, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y2, texture.Width, height)), lightColor, projectile.rotation, new Vector2((float) texture.Width / 2f, (float) height / 2f), projectile.scale, effects1, 0.0f);
				Main.spriteBatch.Draw(mod.GetTexture("Projectiles/Hadron/Hadron_Missile_Glow"), position, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y2, texture.Width, height)), Color.White, projectile.rotation, new Vector2((float) texture.Width / 2f, (float) height / 2f), projectile.scale, effects1, 0.0f);
			return false;
		}
		public override void Kill(int timeLeft)
		{
			projectile.position = projectile.Center;
			projectile.width = projectile.height = 160;
			projectile.Center = projectile.position;
			projectile.maxPenetrate = -1;
			projectile.penetrate = -1;
			projectile.Damage();
			Main.PlaySound(SoundID.Item14, projectile.position);
			Vector2 Position = projectile.Center + Vector2.One * -20f;
			int Width = 40;
			int Height = Width;
			for (int index1 = 0; index1 < 4; ++index1)
			{
			  int index2 = Dust.NewDust(Position, Width, Height, 240, 0.0f, 0.0f, 100, new Color(), 1.5f);
			  Main.dust[index2].position = projectile.Center + Vector2.UnitY.RotatedByRandom(3.14159274101257) * (float) Main.rand.NextDouble() * (float) Width / 2f;
			}
			for (int index1 = 0; index1 < 20; ++index1)
			{
			  int index2 = Dust.NewDust(Position, Width, Height, 156, 0.0f, 0.0f, 200, new Color(), 1f);
			  Main.dust[index2].position = projectile.Center + Vector2.UnitY.RotatedByRandom(3.14159274101257) * (float) Main.rand.NextDouble() * (float) Width / 2f;
			  Main.dust[index2].noGravity = true;
			  Main.dust[index2].noLight = true;
			  Main.dust[index2].velocity *= 3f;
			  Main.dust[index2].velocity += projectile.DirectionTo(Main.dust[index2].position) * (float) (2.0 + (double) Main.rand.NextFloat() * 4.0);
			  int index3 = Dust.NewDust(Position, Width, Height, 156, 0.0f, 0.0f, 100, new Color(), 1.5f);
			  Main.dust[index3].position = projectile.Center + Vector2.UnitY.RotatedByRandom(3.14159274101257) * (float) Main.rand.NextDouble() * (float) Width / 2f;
			  Main.dust[index3].velocity *= 2f;
			  Main.dust[index3].noGravity = true;
			  Main.dust[index3].fadeIn = 1f;
			  Main.dust[index3].color = Color.Crimson * 0.5f;
			  Main.dust[index3].noLight = true;
			  Main.dust[index3].velocity += projectile.DirectionTo(Main.dust[index3].position) * 8f;
			}
			for (int index1 = 0; index1 < 20; ++index1)
			{
			  int index2 = Dust.NewDust(Position, Width, Height, 156, 0.0f, 0.0f, 0, new Color(), 1f);
			  Main.dust[index2].position = projectile.Center + Vector2.UnitX.RotatedByRandom(3.14159274101257).RotatedBy((double) projectile.velocity.ToRotation(), new Vector2()) * (float) Width / 2f;
			  Main.dust[index2].noGravity = true;
			  Main.dust[index2].noLight = true;
			  Main.dust[index2].velocity *= 3f;
			  Main.dust[index2].velocity += projectile.DirectionTo(Main.dust[index2].position) * 2f;
			}
			for (int index1 = 0; index1 < 70; ++index1)
			{
			  int index2 = Dust.NewDust(Position, Width, Height, 240, 0.0f, 0.0f, 0, new Color(), 1.5f);
			  Main.dust[index2].position = projectile.Center + Vector2.UnitX.RotatedByRandom(3.14159274101257).RotatedBy((double) projectile.velocity.ToRotation(), new Vector2()) * (float) Width / 2f;
			  Main.dust[index2].noGravity = true;
			  Main.dust[index2].velocity *= 3f;
			  Main.dust[index2].velocity += projectile.DirectionTo(Main.dust[index2].position) * 3f;
			}
        }
    }
}