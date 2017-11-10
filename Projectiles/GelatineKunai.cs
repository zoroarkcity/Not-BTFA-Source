using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class GelatineKunai : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 1000;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gelatine Kunai");
		}
		
		public override void Kill(int timeLeft)
		{
			if (Main.rand.Next(3) == 0)
        	{
        		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("GelatineKunai"));
        	}
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("geldust"));
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}
		
		public override void AI()
		{
			if (projectile.velocity.X >= 0)
			{
				projectile.velocity.X -= 0.15f;
			}
			if (projectile.velocity.X <= 0)
			{
				projectile.velocity.X += 0.15f;
			}
			if (projectile.velocity.X == 0)
			{
				projectile.velocity.X -= 0f;
			}
			projectile.velocity.Y += 0.15f;
			if (Main.rand.Next(5) == 0)
			{
				int dust2 = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, mod.DustType("geldust"), 0f, 0f);
			}
		}
		
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Gelled"), 360, false);
		}
	}
}