using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class TitanSpin : ModProjectile
	{
		int timer = 0;
		public override void SetDefaults()
		{
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titan's Spin");
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 15f;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 300;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 16f;
		}

		public override void AI()
		{
			if (Main.rand.Next(10) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 130, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("TitanSpinP"), projectile.damage, 5f, projectile.owner);
		}
	}
}