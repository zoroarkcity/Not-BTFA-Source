using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles.Arterius
{
	public class zBloodStream : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = -1;
			projectile.hostile = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.timeLeft = 180;
			projectile.extraUpdates = 1;
			projectile.light = 0.75f;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood");
		}
		
		
		public override void AI()
		{
			for (int i = 0; i < 5; i++)
			{
				int dust;
				dust = Dust.NewDust(projectile.Center + projectile.velocity, projectile.width, projectile.height, mod.DustType("BloodDust"), 0f, 0f);
				Main.dust[dust].scale = 1.2f;
				Main.dust[dust].velocity *= i/5;
			}
		}
	}
}