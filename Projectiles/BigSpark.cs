using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class BigSpark : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 30;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spark");
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 127, 0f, 0f);
			Main.dust[dust].scale = 1.2f;
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i <= 4; i++)
			{
				float sX = Main.rand.Next(-60, 60) * 0.1f;
				float sY = Main.rand.Next(-60, 60) * 0.1f;
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, 504, projectile.damage, 5f, projectile.owner);
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(24, 3600, false);
		}
	}
}