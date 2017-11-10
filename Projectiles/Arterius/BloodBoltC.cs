using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles.Arterius
{
	public class BloodBoltC : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 40;
			projectile.aiStyle = 0;
			projectile.hostile = true;
			//projectile.magic = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 100;
			projectile.light = 0.7f;
			projectile.alpha = 255;
			projectile.friendly = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spinal Bolt");
		}
		
		public override void AI()
		{
			for (int index1 = 0; index1 < 1; ++index1)
			{
				float num1 = projectile.velocity.X / 3f * (float) index1;
				float num2 = projectile.velocity.Y / 3f * (float) index1;
				int num3 = 0;
				int index2 = Dust.NewDust(new Vector2(projectile.Center.X + (float) num3, projectile.Center.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, mod.DustType("BloodDust"), Main.rand.Next(-50, 50) * 1f, -3f, 0, default(Color), 1f);
				Main.dust[index2].scale = 1.6f;
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 0.1f;
				Main.dust[index2].velocity += projectile.velocity * 0.1f;
				Main.dust[index2].position.X -= num1;
				Main.dust[index2].position.Y -= num2;
			}
		}
		
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("DevilsFlame"), 360, false);
		}
	}
}