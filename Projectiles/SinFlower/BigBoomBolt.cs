using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles.SinFlower
{
	public class BigBoomBolt : ModProjectile
	{
		int timer = 0;
		int timer2 = 0;
		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 250;
			projectile.extraUpdates = 10;
			projectile.alpha = 255;
			projectile.tileCollide = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flame Bolt");
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 360, false);
			
			target.AddBuff(mod.BuffType("DevilsFlame"), 360, false);
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 127, 0f, 0f);
			Main.dust[dust].scale = 2f;
			Main.dust[dust].noGravity = true;

			if (timer == 25)
			{
				timer = 6;
			}
			
			
			timer2++;
			if (timer2 >= 15)
			{
				projectile.tileCollide = true;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item89, projectile.position);
			projectile.position.X += (float) (projectile.width / 2);
			projectile.position.Y += (float) (projectile.height / 2);
			projectile.width = (int) (180.0 * (double) projectile.scale);
			projectile.height = (int) (180.0 * (double) projectile.scale);
			projectile.position.X -= (float) (projectile.width / 2);
			projectile.position.Y -= (float) (projectile.height / 2);
			for (int index = 0; index < 8; ++index)
			  Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 127, 0.0f, 0.0f, 100, new Color(), 1.5f);
			for (int index1 = 0; index1 < 48; ++index1)
			{
			  int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 127, 0.0f, 0.0f, 100, new Color(), 3.5f);
			  Main.dust[index2].noGravity = true;
			  Main.dust[index2].velocity *= 3f;
			  int index3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 127, 0.0f, 0.0f, 100, new Color(), 1.5f);
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