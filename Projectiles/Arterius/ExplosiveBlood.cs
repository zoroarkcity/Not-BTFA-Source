using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles.Arterius
{
	public class ExplosiveBlood : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = -1;
			projectile.hostile = true;
			projectile.penetrate = 1;
			projectile.extraUpdates = 1;
			projectile.alpha = 255;
			projectile.damage *= 2;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Homing Blood");
		}
		
		public override void AI()
		{
			for (int i = 0; i < 3; i++)
			{
				int dust;
				dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, mod.DustType("BloodDust"), 0f, 0f);
				Main.dust[dust].scale = 1.2f;
				Main.dust[dust].velocity *= i/3;
			}
			
			int num;
			if (projectile.ai[1] == 0f)
			{
				projectile.ai[1] = 1f;
			}
			else if (projectile.ai[1] == 1f && Main.netMode != 1)
			{
				int num3 = -1;
				float num4 = 2000f;
				for (int k = 0; k < 255; k = num + 1)
				{
					if (Main.player[k].active && !Main.player[k].dead)
					{
						Vector2 center = Main.player[k].Center;
						float num5 = Vector2.Distance(center, projectile.Center);
						if ((num5 < num4 || num3 == -1) && Collision.CanHit(projectile.Center, 1, 1, center, 1, 1))
						{
							num4 = num5;
							num3 = k;
						}
					}
					num = k;
				}
				if (num4 < 20f)
				{
					projectile.Kill();
					return;
				}
				if (num3 != -1)
				{
					projectile.ai[1] = 21f;
					projectile.ai[0] = (float)num3;
					projectile.netUpdate = true;
				}
			}
			else if (projectile.ai[1] > 20f && projectile.ai[1] < 300f)
			{
				projectile.ai[1] += 1f;
				int num6 = (int)projectile.ai[0];
				if (!Main.player[num6].active || Main.player[num6].dead)
				{
					projectile.ai[1] = 1f;
					projectile.ai[0] = 0f;
					projectile.netUpdate = true;
				}
				else
				{
					float num7 = projectile.velocity.ToRotation();
					Vector2 vector2 = Main.player[num6].Center - projectile.Center;
					if (vector2.Length() < 20f)
					{
						projectile.Kill();
						return;
					}
					float targetAngle = vector2.ToRotation();
					if (vector2 == Vector2.Zero)
					{
						targetAngle = num7;
					}
					float num8 = num7.AngleLerp(targetAngle, 0.008f);
					projectile.velocity = new Vector2(projectile.velocity.Length(), 0f).RotatedBy((double)num8, default(Vector2));
				}
			}
			if (projectile.ai[1] >= 1f && projectile.ai[1] < 20f)
			{
				projectile.ai[1] += 1f;
				if (projectile.ai[1] == 20f)
				{
					projectile.ai[1] = 1f;
				}
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item89, projectile.position);
			projectile.position.X += (float) (projectile.width / 2);
			projectile.position.Y += (float) (projectile.height / 2);
			projectile.width = (int) (16.0 * (double) projectile.scale);
			projectile.height = (int) (16.0 * (double) projectile.scale);
			projectile.position.X -= (float) (projectile.width / 2);
			projectile.position.Y -= (float) (projectile.height / 2);
			for (int index = 0; index < 8; ++index)
			  Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
			for (int index1 = 0; index1 < 32; ++index1)
			{
			  int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("BloodDust"), 0.0f, 0.0f, 100, new Color(), 2.5f);
			  Main.dust[index2].noGravity = true;
			  Main.dust[index2].velocity *= 3f;
			  int index3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("BloodDust"), 0.0f, 0.0f, 100, new Color(), 1.5f);
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
			for (int index1 = 0; index1 < 5; ++index1)
			{
			  int index2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, Utils.SelectRandom<int>(Main.rand, new int[3]
			  {
				mod.DustType("BloodDust"),
				5,
				60
			  }), 2.5f * (float) projectile.direction, -2.5f, 0, new Color(), 1f);
			  Main.dust[index2].alpha = 200;
			  Main.dust[index2].velocity *= 2.4f;
			  Main.dust[index2].scale += Main.rand.NextFloat();
			}
		}
	}
}