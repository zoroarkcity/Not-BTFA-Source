using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles.Arterius
{
	public class BloodBoltA : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 450;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spinal Bolt");
		}
		
		public override bool OnTileCollide (Vector2 velocity1)
		{
			return true;
		}
		
		public override void AI()
		{
			for (int index1 = 0; index1 < 2; ++index1)
			{
				float num1 = projectile.velocity.X / 3f * (float) index1;
				float num2 = projectile.velocity.Y / 3f * (float) index1;
				int num3 = 4;
				int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, mod.DustType("BloodDust"), 0.0f, 0.0f, 0, default(Color), 1f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].scale = 1.6f;
				Main.dust[index2].velocity *= 0.1f;
				Main.dust[index2].velocity += projectile.velocity * 0.1f;
				Main.dust[index2].position.X -= num1;
				Main.dust[index2].position.Y -= num2;
			}
			if (Main.rand.Next(2) == 0)
			{
				int num = 4;
				int index = Dust.NewDust(new Vector2(projectile.position.X + (float) num, projectile.position.Y + (float) num), projectile.width - num * 2, projectile.height - num * 2, 60, 0.0f, 0.0f, 0, default(Color), 1f);
				Main.dust[index].velocity *= 0.25f;
				Main.dust[index].velocity += projectile.velocity * 0.5f;
				Main.dust[index].noGravity = true;
			}
		}
		
		
		public override void Kill(int timeLeft)
		{
			int kek = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, -4f, mod.ProjectileType("BloodBoltB"), projectile.damage, 1f, projectile.owner);
		}
	}
}