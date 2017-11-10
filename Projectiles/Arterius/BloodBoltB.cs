using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles.Arterius
{
	public class BloodBoltB : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 0;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.penetrate = 10;
			projectile.timeLeft = 100;
			projectile.alpha = 255;
			projectile.extraUpdates = 2;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spinal Bolt");
		}
		
		public override void AI()
		{
			for (int index1 = 0; index1 < 2; ++index1)
			{
				float num1 = projectile.velocity.X / 3f * (float) index1;
				float num2 = projectile.velocity.Y / 3f * (float) index1;
				int num3 = 4;
				int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, 5, Main.rand.Next(-50, 50) * 1f, -3f, 0, default(Color), 1f);
				Main.dust[index2].scale = 1.6f;
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 0.1f;
				Main.dust[index2].velocity += projectile.velocity * 0.1f;
				Main.dust[index2].position.X -= num1;
				Main.dust[index2].position.Y -= num2;
			}
			projectile.ai[0]++;
			if (projectile.ai[0] > 9)
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("BloodBoltC"), projectile.damage, 1f, projectile.owner);
				projectile.ai[0] = 0;
			}
		}
	}
}