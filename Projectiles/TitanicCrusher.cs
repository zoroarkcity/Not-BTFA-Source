using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class TitanicCrusher : ModProjectile
	{
		float rotate;
		public override void SetDefaults()
		{
			projectile.width = 26;
			projectile.height = 24;
			projectile.alpha = 0;
			projectile.friendly = true;
			//projectile.extraUpdates = 1;
			projectile.melee = true;
			projectile.penetrate = -1;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titanic Crusher");
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 8;
			target.AddBuff(mod.BuffType("TitanCrush"), 420, false);
			for (int i = 0; i < 3; ++i)
			{
				Vector2 newVect1 = new Vector2 (6, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(360)));
				int stalin = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect1.X, newVect1.Y, mod.ProjectileType("BallFriendly"), projectile.damage, 5f, projectile.owner);
				Main.projectile[stalin].timeLeft = 200;
				Main.projectile[stalin].tileCollide = true;
			}
		}
		
		public override void AI()
		{
			if (Main.rand.Next(5) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 60, 0f, 0f);
				Main.dust[dust].scale = 0.7f;
				Main.dust[dust].noGravity = true;
			}
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
			if (Main.player[projectile.owner].dead)
			{
				projectile.Kill();
			}
			else
			{
				Main.player[projectile.owner].itemAnimation = 10;
				Main.player[projectile.owner].itemTime = 10;
				if ((double) projectile.position.X + (double) (projectile.width / 2) > (double) Main.player[projectile.owner].position.X + (double) (Main.player[projectile.owner].width / 2))
				{
					Main.player[projectile.owner].ChangeDir(1);
					projectile.direction = 1;
				}
				else
				{
					Main.player[projectile.owner].ChangeDir(-1);
					projectile.direction = -1;
				}
				Vector2 mountedCenter = Main.player[projectile.owner].MountedCenter;
				Vector2 vector2_1 = new Vector2(projectile.position.X + (float) projectile.width * 0.5f, projectile.position.Y + (float) projectile.height * 0.5f);
				float num1 = mountedCenter.X - vector2_1.X;
				float num2 = mountedCenter.Y - vector2_1.Y;
				float num3 = (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
				if ((double) projectile.ai[0] == 0.0)
				{
					float num4 = 240f;
					projectile.tileCollide = true;
					if ((double) num3 > (double) num4)
					{
						projectile.ai[0] = 1f;
						projectile.netUpdate = true;
					}
					else if (!Main.player[projectile.owner].channel)
					{
						if ((double) projectile.velocity.Y < 0.0)
						projectile.velocity.Y *= 0.9f;
						++projectile.velocity.Y;
						projectile.velocity.X *= 0.9f;
					}
				}
				else if ((double) projectile.ai[0] == 1.0)
				{
					float num4 = 16f / Main.player[projectile.owner].meleeSpeed;
					float num5 = 1.1f / Main.player[projectile.owner].meleeSpeed;
					float num6 = 350f;
					double num7 = (double) Math.Abs(num1);
					double num8 = (double) Math.Abs(num2);
					if ((double) projectile.ai[1] == 1.0)
					projectile.tileCollide = false;
					if (!Main.player[projectile.owner].channel || (double) num3 > (double) num6 || !projectile.tileCollide)
					{
						projectile.ai[1] = 1f;
						if (projectile.tileCollide)
						projectile.netUpdate = true;
						projectile.tileCollide = false;
						if ((double) num3 < 20.0)
						projectile.Kill();
					}
					if (!projectile.tileCollide)
					num5 *= 2f;
					
					int num9 = 80;
					if ((double) num3 > (double) num9 || !projectile.tileCollide)
					{
						float num10 = num4 / num3;
						num1 *= num10;
						num2 *= num10;
						Vector2 vector2_2 = new Vector2(projectile.velocity.X, projectile.velocity.Y);
						float num11 = num1 - projectile.velocity.X;
						float num12 = num2 - projectile.velocity.Y;
						float num13 = (float) Math.Sqrt((double) num11 * (double) num11 + (double) num12 * (double) num12);
						float num14 = num5 / num13;
						float num15 = num11 * num14;
						float num16 = num12 * num14;
						projectile.velocity.X *= 0.98f;
						projectile.velocity.Y *= 0.98f;
						projectile.velocity.X += num15;
						projectile.velocity.Y += num16;
					}
					else
					{
						if ((double) Math.Abs(projectile.velocity.X) + (double) Math.Abs(projectile.velocity.Y) < 6.0)
						{
							projectile.velocity.X *= 0.96f;
							projectile.velocity.Y += 0.2f;
						}
						if ((double) Main.player[projectile.owner].velocity.X == 0.0)
						projectile.velocity.X *= 0.96f;
					}
				}
			}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (oldVelocity != projectile.velocity)
			{
				bool flag6 = false;
				if ((double) oldVelocity.X != (double) projectile.velocity.X)
				{
					if ((double) Math.Abs(oldVelocity.X) > 4.0)
					flag6 = true;
					projectile.position.X += projectile.velocity.X;
					projectile.velocity.X = (float) (-(double) oldVelocity.X * 0.200000002980232);
				}
				if ((double) oldVelocity.Y != (double) projectile.velocity.Y)
				{
					if ((double) Math.Abs(oldVelocity.Y) > 4.0)
					flag6 = true;
					projectile.position.Y += projectile.velocity.Y;
					projectile.velocity.Y = (float) (-(double) oldVelocity.Y * 0.200000002980232);
				}
				projectile.ai[0] = 1f;
				if (flag6)
				{
					projectile.netUpdate = true;
					Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
					Main.PlaySound(0, (int) projectile.position.X, (int) projectile.position.Y, 1, 1f, 0.0f);
				}
			}
			return false;
		}
		
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 vector2 = new Vector2(projectile.position.X + (float) projectile.width * 0.5f, projectile.position.Y + (float) projectile.height * 0.5f);
			float num1 = Main.player[projectile.owner].MountedCenter.X - vector2.X;
			float num2 = Main.player[projectile.owner].MountedCenter.Y - vector2.Y;
			float rotation = (float) Math.Atan2((double) num2, (double) num1) - 1.57f;
			if (projectile.alpha == 0)
			{
				int num3 = -1;
				if ((double) projectile.position.X + (double) (projectile.width / 2) < (double) Main.player[projectile.owner].MountedCenter.X)
				num3 = 1;
				Main.player[projectile.owner].itemRotation = Main.player[projectile.owner].direction != 1 ? (float) Math.Atan2((double) num2 * (double) num3, (double) num1 * (double) num3) : (float) Math.Atan2((double) num2 * (double) num3, (double) num1 * (double) num3);
			}
			bool flag = true;
			while (flag)
			{
				float f = (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
				if ((double) f < 25.0)
				flag = false;
				else if (float.IsNaN(f))
				{
					flag = false;
				}
				else
				{
					float num3 = projectile.type == 154 || projectile.type == 247 ? 18f / f : 12f / f;
					float num4 = num1 * num3;
					float num5 = num2 * num3;
					vector2.X += num4;
					vector2.Y += num5;
					num1 = Main.player[projectile.owner].MountedCenter.X - vector2.X;
					num2 = Main.player[projectile.owner].MountedCenter.Y - vector2.Y;
					Microsoft.Xna.Framework.Color color = Lighting.GetColor((int) vector2.X / 16, (int) ((double) vector2.Y / 16.0));
					Main.spriteBatch.Draw(mod.GetTexture("Projectiles/Chain/RockChain"), new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 12, 18)), color, rotation, new Vector2((float) 12 * 0.5f, (float) 18 * 0.5f), 1f, SpriteEffects.None, 0.0f);
				}
			}
			return true;
		}
	}
}