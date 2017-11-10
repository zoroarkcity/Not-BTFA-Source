using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class VortexRocket : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 24;
			projectile.height = 10;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.ranged = true;
			projectile.penetrate = 1;
			projectile.alpha = 255;
			projectile.light = 0.5f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vortex Missile");
			aiType = ProjectileID.Bullet;
		}
		
		public override void AI()
		{
			if (Main.rand.Next(10) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.Center, (int)projectile.width/4, (int)projectile.height/4, 229, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 0.5f;
				Main.dust[dust].noGravity = true;
			}
			int dust2;
			dust2 = Dust.NewDust(projectile.Center, (int)projectile.width/4, (int)projectile.height/4, 229, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust2].scale = 0.5f;
			Main.dust[dust2].noGravity = true;
			
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
		}
		
		public override void Kill(int timeLeft)
		{
			
			for (int i = 0; i < 4; i++)
			{
				Vector2 vector2 = new Vector2(8, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(360)));
				int kek = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, vector2.X, vector2.Y, mod.ProjectileType("LightningVortex"), (int)(projectile.damage * 0.75), 5f, projectile.owner);
			}
			
			Main.PlaySound(SoundID.Item14, projectile.position);
			projectile.position.X += (float) (projectile.width / 2);
			projectile.position.Y += (float) (projectile.height / 2);
			projectile.width = (int) (100.0 * (double) projectile.scale);
			projectile.height = (int) (100.0 * (double) projectile.scale);
			projectile.position.X -= (float) (projectile.width / 2);
			projectile.position.Y -= (float) (projectile.height / 2);
			for (int index = 0; index < 8; ++index)
			  Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 226, 0.0f, 0.0f, 100, new Color(), 1.5f);
			for (int index1 = 0; index1 < 32; ++index1)
			{
			  int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 229, 0.0f, 0.0f, 100, new Color(), 2.5f);
			  Main.dust[index2].noGravity = true;
			  Main.dust[index2].velocity *= 3f;
			  int index3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 211, 0.0f, 0.0f, 100, new Color(), 1.5f);
			  Main.dust[index3].velocity *= 2f;
			  Main.dust[index3].noGravity = true;
			}
			for (int index1 = 0; index1 < 2; ++index1)
			{
			  int index2 = Gore.NewGore(projectile.position + new Vector2((float) (projectile.width * Main.rand.Next(100)) / 100f, (float) (projectile.height * Main.rand.Next(100)) / 100f) - Vector2.One * 10f, new Vector2(), Main.rand.Next(61, 64), 1f);
			  Main.gore[index2].velocity *= 0.3f;
			  Main.gore[index2].velocity.X += (float) Main.rand.Next(-10, 11) * 0.05f;
			  Main.gore[index2].velocity.Y += (float) Main.rand.Next(-10, 11) * 0.05f;
			}
			if (projectile.owner == Main.myPlayer)
			{
			  projectile.localAI[1] = -1f;
			  projectile.maxPenetrate = 0;
			  projectile.Damage();
			}
		}
	}
}