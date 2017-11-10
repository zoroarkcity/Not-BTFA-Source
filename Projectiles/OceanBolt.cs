using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class OceanBolt : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 300;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ocean Bolt");
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 33, 0f, 0f);
			Main.dust[dust].scale = 1.5f;
			Main.dust[dust].noGravity = true;
			Main.dust[dust].alpha = 80;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			int amountOfProjectiles = Main.rand.Next(4, 6);
			
			for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-60, 61) * 0.1f;
					float sY = (float)Main.rand.Next(-60, 61) * 0.1f;
					int z = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, mod.ProjectileType("AquaBolt"), projectile.damage, 5f, projectile.owner);
					Main.projectile[z].magic = true;
					Main.projectile[z].melee = false;
					Main.projectile[z].tileCollide = false;
					Main.projectile[z].timeLeft = 30;
				}
			return true;
		}
	}
}