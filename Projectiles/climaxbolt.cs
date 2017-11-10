using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class climaxbolt : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 40;
			projectile.extraUpdates = 4;
			projectile.alpha = 255;
			projectile.tileCollide = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Climax Bolt");
		}
		
		public override void AI()
		{
			float sX = (float)Main.rand.Next(-60, 61) * 0.1f;
			float sY = (float)Main.rand.Next(-60, 61) * 0.1f;
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, mod.ProjectileType("climaxproj"), projectile.damage, 5f, projectile.owner);
		}
	}
}