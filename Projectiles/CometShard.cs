using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class CometShard : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 24;
			projectile.height = 22;
			projectile.aiStyle = -1;
			projectile.ranged = true;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 1;
			projectile.tileCollide = true;
			projectile.timeLeft = 360;
			projectile.light = 0.5f;
			projectile.extraUpdates = 1;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Comet Shard");
		}
		
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
			Vector2 vector2 = projectile.Center + Vector2.Normalize(projectile.velocity) * 10f;
			Dust dust1 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, 0.0f, 0.0f, 0, new Color(), 1f)];
			dust1.position = vector2;
			dust1.velocity = projectile.velocity.RotatedBy(1.57079637050629, new Vector2()) * 0.33f + projectile.velocity / 4f;
			dust1.position += projectile.velocity.RotatedBy(1.57079637050629, new Vector2());
			dust1.fadeIn = 0.5f;
			dust1.noGravity = true;
			Dust dust2 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, 0.0f, 0.0f, 0, new Color(), 1f)];
			dust2.position = vector2;
			dust2.velocity = projectile.velocity.RotatedBy(-1.57079637050629, new Vector2()) * 0.33f + projectile.velocity / 4f;
			dust2.position += projectile.velocity.RotatedBy(-1.57079637050629, new Vector2());
			dust2.fadeIn = 0.5f;
			dust2.noGravity = true;
			for (int index1 = 0; index1 < 1; ++index1)
			{
			  int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, 0.0f, 0.0f, 0, new Color(), 1f);
			  Main.dust[index2].velocity *= 0.5f;
			  Main.dust[index2].scale *= 1.3f;
			  Main.dust[index2].fadeIn = 1f;
			  Main.dust[index2].noGravity = true;
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
			  int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, 0.0f, 0.0f, 100, new Color(), 2.5f);
			  Main.dust[index2].noGravity = true;
			  Main.dust[index2].velocity *= 3f;
			  int index3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, 0.0f, 0.0f, 100, new Color(), 1.5f);
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
				15,
				176,
				59
			  }), 2.5f * (float) projectile.direction, -2.5f, 0, new Color(), 1f);
			  Main.dust[index2].alpha = 200;
			  Main.dust[index2].velocity *= 2.4f;
			  Main.dust[index2].scale += Main.rand.NextFloat();
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			target.AddBuff(mod.BuffType("CosmicCurse"), 180, false);
		}
		
		public override bool OnTileCollide (Vector2 velocity1)
		{
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
			return false;
		}
	}
}