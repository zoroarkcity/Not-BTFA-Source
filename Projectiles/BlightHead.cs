using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class BlightHead : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 48;
			projectile.height = 44;
			projectile.aiStyle = -1;
			projectile.melee = true;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 1;
			projectile.tileCollide = false;
			projectile.extraUpdates = 1;
			projectile.light = 0.5f;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 5;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Meteor");
		}
		
		public override void AI()
		{
			projectile.rotation += 0.1f;
			int num3 = projectile.frameCounter;
			if (projectile.ai[0] >= 0f && projectile.ai[0] < 200f)
			{
				int num552 = (int)projectile.ai[0];
				if (Main.npc[num552].active)
				{
					float num553 = 8f;
					Vector2 vector43 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
					float num554 = Main.npc[num552].position.X - vector43.X;
					float num555 = Main.npc[num552].position.Y - vector43.Y;
					float num556 = (float)Math.Sqrt((double)(num554 * num554 + num555 * num555));
					num556 = num553 / num556;
					num554 *= num556;
					num555 *= num556;
					projectile.velocity.X = (projectile.velocity.X * 14f + num554) / 15f;
					projectile.velocity.Y = (projectile.velocity.Y * 14f + num555) / 15f;
				}
				else
				{
					float num557 = 1000f;
					for (int num558 = 0; num558 < 200; num558 = num3 + 1)
					{
						if (Main.npc[num558].CanBeChasedBy(this, false))
						{
							float num559 = Main.npc[num558].position.X + (float)(Main.npc[num558].width / 2);
							float num560 = Main.npc[num558].position.Y + (float)(Main.npc[num558].height / 2);
							float num561 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num559) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num560);
							if (num561 < num557 && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[num558].position, Main.npc[num558].width, Main.npc[num558].height))
							{
								num557 = num561;
								projectile.ai[0] = (float)num558;
							}
						}
						num3 = num558;
					}
				}
				int num562 = 8;
				int num563 = Dust.NewDust(new Vector2(projectile.position.X + (float)num562, projectile.position.Y + (float)num562), projectile.width - num562 * 2, projectile.height - num562 * 2, 173, 0f, 0f, 0, default(Color), 1f);
				Dust dust3 = Main.dust[num563];
				dust3.velocity *= 0.5f;
				dust3 = Main.dust[num563];
				dust3.velocity += projectile.velocity * 0.5f;
				Main.dust[num563].noGravity = true;
				Main.dust[num563].noLight = true;
				Main.dust[num563].scale = 1.4f;
				return;
			}
			projectile.Kill();
			return;
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
			  int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 173, 0.0f, 0.0f, 100, new Color(), 2.5f);
			  Main.dust[index2].noGravity = true;
			  Main.dust[index2].velocity *= 3f;
			  int index3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 173, 0.0f, 0.0f, 100, new Color(), 1.5f);
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
				65,
				173,
				21
			  }), 2.5f * (float) projectile.direction, -2.5f, 0, new Color(), 1f);
			  Main.dust[index2].alpha = 200;
			  Main.dust[index2].velocity *= 2.4f;
			  Main.dust[index2].scale += Main.rand.NextFloat();
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			target.immune[projectile.owner] = 5;
			target.AddBuff(mod.BuffType("BlightFlame"), 180, false);
		}
	}
}