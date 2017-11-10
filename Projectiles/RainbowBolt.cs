using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class RainbowBolt : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 50;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.melee = true;
			projectile.tileCollide = false;
			Main.projFrames[projectile.type] = 4;
			projectile.penetrate = 2;
			projectile.light = 0.5f;
			projectile.timeLeft = 400;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rainbow Bolt");
			aiType = ProjectileID.Bullet;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			target.immune[projectile.owner] = 5;
			projectile.damage += (int)(projectile.damage/4);
			
			Vector2 spinningpoint = new Vector2(0f, -3f - projectile.ai[0]).RotatedByRandom(3.1415927410125732);
			float num13 = 10f + projectile.ai[0] * 4f;
			Vector2 value6 = new Vector2(1.05f, 1f);
			for (float num14 = 0f; num14 < num13; num14 += 1f)
			{
				int num15 = Dust.NewDust(projectile.Center, 0, 0, 66, 0f, 0f, 0, Color.Transparent, 1f);
				Main.dust[num15].position = projectile.Center;
				Main.dust[num15].velocity = spinningpoint.RotatedBy((double)(6.28318548f * num14 / num13), default(Vector2)) * value6 * (0.8f + Main.rand.NextFloat() * 0.4f);
				Main.dust[num15].color = Main.hslToRgb(num14 / num13, 1f, 0.5f);
				Main.dust[num15].noGravity = true;
				Main.dust[num15].scale = 1f + projectile.ai[0] / 3f;
			}
			
			if (Main.rand.Next(3) == 0)
			{
				int thing = 153;
				switch (Main.rand.Next(8))
				{
				case 0: thing = 189;
					break;
				case 1: thing = mod.BuffType("DevilsFlame");
					break;
				case 2: thing = mod.BuffType("Electrified");
					break;
				case 3: thing = mod.BuffType("BlightFlame");
					break;
				case 4: thing = 69;
					break;
				case 5: thing = 72;
					break;
				case 6: thing = 70;
					break;
				case 7: thing = 153;
					break;
				default: break;
				}
				target.AddBuff(thing, 360, false);
			}
		}
		
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
		}
		
		public override void AI()
		{
			if (projectile.position.Y > (double) projectile.ai[1])
			projectile.tileCollide = true;
			
			if (Main.rand.Next(10) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, (int)projectile.width/4, (int)projectile.height/4, mod.DustType("RainbowDust"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 0.5f;
				Main.dust[dust].noGravity = true;
			}
			int dust2;
			dust2 = Dust.NewDust(projectile.position, (int)projectile.width/4, (int)projectile.height/4, mod.DustType("RainbowDust"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust2].scale = 0.5f;
			Main.dust[dust2].noGravity = true;
			
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - 1.57f;
			
			projectile.frameCounter++;
			if (projectile.frameCounter >= 5)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			} 
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item9, projectile.position);
			projectile.position.X += (float) (projectile.width / 2);
			projectile.position.Y += (float) (projectile.height / 2);
			projectile.width = (int) (100.0 * (double) projectile.scale);
			projectile.height = (int) (100.0 * (double) projectile.scale);
			projectile.position.X -= (float) (projectile.width / 2);
			projectile.position.Y -= (float) (projectile.height / 2);
			
			Vector2 spinningpoint = new Vector2(0f, -8f - projectile.ai[0]).RotatedByRandom(3.1415927410125732);
			float num13 = 10f + projectile.ai[0] * 4f;
			Vector2 value6 = new Vector2(1.05f, 1f);
			for (float num14 = 0f; num14 < num13; num14 += 1f)
			{
				int num15 = Dust.NewDust(projectile.Center, 0, 0, 66, 0f, 0f, 0, Color.Transparent, 1f);
				Main.dust[num15].position = projectile.Center;
				Main.dust[num15].velocity = spinningpoint.RotatedBy((double)(6.28318548f * num14 / num13), default(Vector2)) * value6 * (0.8f + Main.rand.NextFloat() * 0.4f);
				Main.dust[num15].color = Main.hslToRgb(num14 / num13, 1f, 0.5f);
				Main.dust[num15].noGravity = true;
				Main.dust[num15].scale = 1f + projectile.ai[0] / 3f;
			}
		}
		
		public override bool OnTileCollide (Vector2 velocity1)
		{
			projectile.penetrate--;
			if (projectile.penetrate < 1)
			{
				projectile.Kill();
			}
			if ((double) projectile.velocity.Y != (double) velocity1.Y || (double) projectile.velocity.X != (double) velocity1.X)
			{
				if ((double) projectile.velocity.X != (double) velocity1.X)
				projectile.velocity.X = -velocity1.X;
				if ((double) projectile.velocity.Y != (double) velocity1.Y)
				projectile.velocity.Y = -velocity1.Y;
			}
			if (projectile.penetrate > 0 && projectile.owner == Main.myPlayer)
			{
				int[] numArray = new int[10];
				int maxValue = 0;
				int num1 = 700;
				int num2 = 20;
				for (int index = 0; index < 200; ++index)
				{
					if (Main.npc[index].CanBeChasedBy((object) this, false))
					{
						float num3 = (projectile.Center - Main.npc[index].Center).Length();
						if ((double) num3 > (double) num2 && (double) num3 < (double) num1 && Collision.CanHitLine(projectile.Center, 1, 1, Main.npc[index].Center, 1, 1))
						{
							numArray[maxValue] = index;
							++maxValue;
							if (maxValue >= 9)
							break;
						}
					}
				}
				if (maxValue > 0)
				{
					int index = Main.rand.Next(maxValue);
					Vector2 vector2 = Main.npc[numArray[index]].Center - projectile.Center;
					float num3 = projectile.velocity.Length();
					vector2.Normalize();
					projectile.velocity = vector2 * num3;
					projectile.netUpdate = true;
				}
			}
			
			Vector2 spinningpoint = new Vector2(0f, -3f - projectile.ai[0]).RotatedByRandom(3.1415927410125732);
			float num13 = 10f + projectile.ai[0] * 4f;
			Vector2 value6 = new Vector2(1.05f, 1f);
			for (float num14 = 0f; num14 < num13; num14 += 1f)
			{
				int num15 = Dust.NewDust(projectile.Center, 0, 0, 66, 0f, 0f, 0, Color.Transparent, 1f);
				Main.dust[num15].position = projectile.Center;
				Main.dust[num15].velocity = spinningpoint.RotatedBy((double)(6.28318548f * num14 / num13), default(Vector2)) * value6 * (0.8f + Main.rand.NextFloat() * 0.4f);
				Main.dust[num15].color = Main.hslToRgb(num14 / num13, 1f, 0.5f);
				Main.dust[num15].noGravity = true;
				Main.dust[num15].scale = 1f + projectile.ai[0] / 3f;
			}
			return false;
		}
	}
}