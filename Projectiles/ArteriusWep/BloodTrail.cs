using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles.ArteriusWep
{
	public class BloodTrail : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 70;
			//projectile.extraUpdates = 1;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood");
		}
		
		public override void AI()
		{
			projectile.velocity *= 0.9f;
			for (int index1 = 0; index1 < 5; ++index1)
			{
				float num1 = projectile.velocity.X / 3f * (float) index1;
				float num2 = projectile.velocity.Y / 3f * (float) index1;
				int num3 = 4;
				int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, mod.DustType("BloodDust"), 0.0f, 0.0f, 200, default(Color), 1.2f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 0.1f;
				Main.dust[index2].velocity += projectile.velocity * 0.1f;
				Main.dust[index2].position.X -= num1;
				Main.dust[index2].position.Y -= num2;
			}
			if (Main.rand.Next(5) == 0)
			{
				int num = 4;
				int index = Dust.NewDust(new Vector2(projectile.position.X + (float) num, projectile.position.Y + (float) num), projectile.width - num * 2, projectile.height - num * 2, mod.DustType("BloodDust"), 0.0f, 0.0f, 200, default(Color), 0.6f);
				Main.dust[index].velocity *= 0.25f;
				Main.dust[index].velocity += projectile.velocity * 0.5f;
			}
		}
	}
}