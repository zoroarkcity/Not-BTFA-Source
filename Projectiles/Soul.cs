using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class Soul : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 4;
			projectile.height = 4;
			//projectile.aiStyle = 51;
			projectile.friendly = true;
			projectile.alpha = (int) byte.MaxValue;
			projectile.magic = true;
			projectile.extraUpdates = 2;
			projectile.timeLeft = 240;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul");
		}
		
		public override void AI()
		{
			projectile.localAI[0] += 1;
			if ((double) projectile.localAI[0] > 4.0)
			{
				for (int index1 = 0; index1 < 4; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 175, 0.0f, 0.0f, 100, new Color(), 2f);
					Main.dust[index2].noGravity = true;
					Dust dust = Main.dust[index2];
					dust.velocity = (dust.velocity * 0.0f);
				}
			}
			float num1 = (float) projectile.Center.X;
			float num2 = (float) projectile.Center.Y;
			float num3 = 400f;
			bool flag = false;
			int num4 = 0;
			for (int index = 0; index < 200; ++index)
			{
				if (Main.npc[index].CanBeChasedBy((object) this, false) && (double) projectile.Distance(Main.npc[index].Center) < (double) num3)
				{
					float num5 = (float) Main.npc[index].position.X + (float) (Main.npc[index].width / 2);
					float num6 = (float) Main.npc[index].position.Y + (float) (Main.npc[index].height / 2);
					float num7 = Math.Abs((float) projectile.position.X + (float) (projectile.width / 2) - num5) + Math.Abs((float) projectile.position.Y + (float) (projectile.height / 2) - num6);
					if ((double) num7 < (double) num3)
					{
						num3 = num7;
						num1 = num5;
						num2 = num6;
						flag = true;
						num4 = index;
					}
				}
			}
			if (!flag)
				return;
			float num9 = 9f;
			Vector2 vector2 = new Vector2((float)(projectile.position.X + (double) projectile.width * 0.5), (float)(projectile.position.Y + (double) projectile.height * 0.5));
			float num10 = num1 - (float) vector2.X;
			float num11 = num2 - (float) vector2.Y;
			float num12 = (float) Math.Sqrt((double) num10 * (double) num10 + (double) num11 * (double) num11);
			float num13 = (float)(num9 / num12);
			float num14 = (float)(num10 * num13);
			float num15 = (float)(num11 * num13);
			projectile.velocity.X = ((projectile.velocity.X * 20f + num14) / 21f);
			projectile.velocity.Y = ((projectile.velocity.Y * 20f + num15) / 21f);
		}
	}
}