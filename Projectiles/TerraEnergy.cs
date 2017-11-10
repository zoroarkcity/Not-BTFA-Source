using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class TerraEnergy : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 200;
			projectile.alpha = 255;
			projectile.tileCollide = true;
			projectile.extraUpdates = 3;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Terra Energy");
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 74, 0f, 0f);
			Main.dust[dust].scale = 0.9f;
			Main.dust[dust].noGravity = true;
		}
	}
}