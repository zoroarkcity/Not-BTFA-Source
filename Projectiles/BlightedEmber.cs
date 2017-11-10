using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class BlightedEmber : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 2;
			projectile.height = 2;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 30;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Ember");
		}
		
		public override void AI()
		{
			int num;
			for (int num164 = 0; num164 < 10; num164 = num + 1)
				{
					float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)num164;
					float y2 = projectile.position.Y - projectile.velocity.Y / 10f * (float)num164;
					int num165 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 65, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num165].position.X = x2;
					Main.dust[num165].position.Y = y2;
					Dust dust3 = Main.dust[num165];
					dust3.velocity *= 0f;
					Main.dust[num165].noGravity = true;
					num = num164;
				}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("BlightFlame"), 580, false);
		}
	}
}