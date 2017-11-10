using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class DarkMagicFriendly : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 5;
			projectile.height = 5;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 3;
			projectile.alpha = 255;
			projectile.tileCollide = true;
			projectile.timeLeft = 180;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Magic");
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Curse"), 60, false);
		}
		
		public override void AI()
		{
			for (int i = 0; i < 3; i++)
			{
				int dust;
				dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 173, 0f, 0f);
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
				for (int k = 0; k < 200; k = num + 1)
				{
					if (Main.npc[k].active && !Main.npc[k].immortal && !Main.npc[k].dontTakeDamage)
					{
						Vector2 center = Main.npc[k].Center;
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
			else if (projectile.ai[1] > 20f && projectile.ai[1] < 300f)
			{
				projectile.ai[1] += 1f;
				int num6 = (int)projectile.ai[0];
				if (!Main.npc[num6].active)
				{
					projectile.ai[1] = 1f;
					projectile.ai[0] = 0f;
					projectile.netUpdate = true;
				}
				else
				{
					float num7 = projectile.velocity.ToRotation();
					Vector2 vector2 = Main.npc[num6].Center - projectile.Center;
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
	}
}