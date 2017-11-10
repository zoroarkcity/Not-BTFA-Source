using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class redflame : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 10;
			projectile.timeLeft = 1000;
			projectile.alpha = 255;
			projectile.extraUpdates = 2;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Flame");
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 60, 0f, 0f);
			
			if (Main.rand.Next(2) == 0)
			{
				int dust2 = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, mod.DustType("reddust"), 0f, 0f);
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("redboom"), projectile.damage, 5f, projectile.owner);
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("DevilsFlame"), 360, false);
		}
	}
}