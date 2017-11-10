using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Archeron
{
	public class HomingSoul2 : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 2;
			projectile.height = 2;
			projectile.aiStyle = -1;
			projectile.hostile = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 175;
			projectile.alpha = 255;
			projectile.tileCollide = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lost Soul");
		}
		

		public override void AI()
		{
			if (projectile.timeLeft <= 195)
			{
				for (int index1 = 0; index1 < 5; ++index1)
				{
					float num1 = projectile.velocity.X / 3f * (float) index1;
					float num2 = projectile.velocity.Y / 3f * (float) index1;
					int num3 = 4;
					int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, 20, 0.0f, 0.0f, 100, new Color(), 1.4f);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity *= 0.1f;
					Main.dust[index2].velocity += projectile.velocity * 0.1f;
					Main.dust[index2].position.X -= num1;
					Main.dust[index2].position.Y -= num2;
					Main.dust[index2].scale = 1.1f;
				}
				
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
						if ((num5 < num4 || num3 == -1))
						{
							num4 = num5;
							num3 = k;
						}
					}
					num = k;
				}
				if (num3 != -1)
				{
					projectile.ai[1] = 21f;
					projectile.ai[0] = (float)num3;
					projectile.netUpdate = true;
				}
			}
			else if (projectile.ai[1] > 20f && projectile.ai[1] < 100f)
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
					float targetAngle = vector2.ToRotation();
					if (vector2 == Vector2.Zero)
					{
						targetAngle = num7;
					}
					float num8 = num7.AngleLerp(targetAngle, 0.01f);
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
	}
}