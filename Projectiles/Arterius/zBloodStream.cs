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
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = -1;
			projectile.hostile = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.timeLeft = 180;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood");
		}
		
		
		public override void AI()
		{
			
			Lighting.AddLight(projectile.position, 0.75f, 0f, 0.1f);
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