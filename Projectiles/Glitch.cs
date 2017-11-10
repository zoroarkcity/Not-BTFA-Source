using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class Glitch : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 200;
			projectile.alpha = 255;
			projectile.tileCollide = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glitch");
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, Main.rand.Next(3, 200), 0f, 0f);
			Main.dust[dust].scale = 2f;
			Main.dust[dust].noGravity = true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(5) == 0)
			{
				target.aiStyle = Main.rand.Next(3, 32);
				if (target.aiStyle == 12)
				{
					target.aiStyle = 1;
				}
			}
			if (Main.rand.Next(20) == 0)
			{
				target.type = Main.rand.Next(3, 578);
			}
			target.noTileCollide = false;
			if (Main.rand.Next(20) == 0)
			{
				target.noGravity = true;
			}
			if (Main.rand.Next(20) == 0)
			{
				target.noGravity = false;
			}
		}
	}
}