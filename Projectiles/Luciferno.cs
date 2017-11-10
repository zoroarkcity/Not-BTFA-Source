using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class Luciferno : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 300;
			projectile.height = 300;
			projectile.friendly = true;
			projectile.alpha = (int) byte.MaxValue;
			projectile.magic = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demonic Inferno");
		}
		
		public override void AI()
		{
			if ((double) projectile.localAI[0] == 0.0)
			{
				Main.PlaySound(SoundID.Item74, projectile.position);
				projectile.localAI[0] += 1;
			}
			projectile.ai[0] += 2;
			
			float num1 = 25f;
			if ((double) projectile.ai[0] > 180.0)
				num1 -= (float) (((double) projectile.ai[0] - 180.0) / 2.0);
			if ((double) num1 <= 0.0)
			{
				num1 = 0.0f;
				projectile.Kill();
			}
			for (int index1 = 0; (double) index1 < (double) num1; ++index1)
			{
				float num2 = (float) Main.rand.Next(-10, 11);
				float num3 = (float) Main.rand.Next(-10, 11);
				float num4 = (float) Main.rand.Next(6, 18) / (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
				float num5 = num2 * num4;
				float num6 = num3 * num4;
				int index2 = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 174, 0.0f, 0.0f, 100, new Color(), 1.5f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].position.X = projectile.Center.X;
				Main.dust[index2].position.Y = projectile.Center.Y;
				Main.dust[index2].position.X = Main.dust[index2].position.X + (float) Main.rand.Next(-10, 11);
				Main.dust[index2].position.Y = Main.dust[index2].position.Y + (float) Main.rand.Next(-10, 11);
				Main.dust[index2].velocity.X = num5;
				Main.dust[index2].velocity.Y = num6;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (target.position.X + (double) (target.width / 2) < projectile.position.X + (double) (projectile.width / 2))
				projectile.direction = -1;
			else
				projectile.direction = 1;
		  
			target.AddBuff(mod.BuffType("DevilsFlame"), 360, false);
			target.AddBuff(24, 360, false);
		}
	}
}