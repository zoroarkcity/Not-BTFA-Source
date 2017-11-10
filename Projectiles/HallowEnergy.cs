using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class HallowEnergy : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 200;
			projectile.alpha = 255;
			projectile.tileCollide = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hallowed Energy");
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, mod.DustType("bluedust"), 0f, 0f);
			Main.dust[dust].scale = 1.5f;
			Main.dust[dust].noGravity = true;
			int hitler;
			hitler = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, mod.DustType("pinkdust"), 0f, 0f);
			Main.dust[hitler].scale = 1.5f;
			Main.dust[hitler].noGravity = true;
			projectile.rotation += 10;
		}
	}
}