using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class SpectreShuriken : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 2;
			projectile.penetrate = 1;
			projectile.thrown = true;
			projectile.friendly = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spectre Shuriken");
		}
		
		public override void Kill(int timeLeft)
		{
			if (Main.rand.Next(3) == 0)
			{
				Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("SpectreShuriken"));
			}
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 56);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}
		
		public override void AI()
		{
			if (Main.rand.Next(5) == 0)
			{
				int dust2;
				dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, projectile.velocity.X * -1f, projectile.velocity.Y * -1f);
				Main.dust[dust2].scale = 1.5f;
				Main.dust[dust2].noGravity = true;
			}
			if (Main.rand.Next(3) == 0)
			{
				int dust3;
				dust3 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 56, projectile.velocity.X * -1f, projectile.velocity.Y * -1f);
				Main.dust[dust3].scale = 1.5f;
				Main.dust[dust3].noGravity = true;
			}
			Vector2 targetPos = projectile.Center;
            float targetDist = 350f;
            bool targetAcquired = false;
			
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].CanBeChasedBy(projectile) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[i].Center, 1, 1) && Main.npc[i].immune[projectile.owner] == 0)
                {
                    float dist = projectile.Distance(Main.npc[i].Center);
                    if (dist < targetDist)
                    {
                        targetDist = dist;
                        targetPos = Main.npc[i].Center;
                        targetAcquired = true;
						projectile.aiStyle = -1;
                    }
                }
            }
			
            if (targetAcquired)
            {
                float homingSpeedFactor = 12f;
                Vector2 homingVect = targetPos - projectile.Center;
                float dist = projectile.Distance(targetPos);
                dist = homingSpeedFactor / dist;
                homingVect *= dist;
				projectile.rotation += projectile.velocity.X / 2f;
                projectile.velocity = (projectile.velocity * 20 + homingVect) / 21f;
            }
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D3 = Main.projectileTexture[projectile.type];
			int num156 = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
			int y3 = num156 * projectile.frame;
			Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(0, y3, texture2D3.Width, num156);
			Vector2 origin2 = rectangle.Size() / 2f;
			Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.position + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Color.White, projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
	}
}	