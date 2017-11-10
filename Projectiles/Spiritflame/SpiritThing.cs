using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles.Spiritflame
{
	public class SpiritThing : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 50;
			projectile.height = 50;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 20;
			projectile.extraUpdates = 1;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spirit Magic");
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 160, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].scale = 1.5f;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			target.AddBuff(mod.BuffType("Spiritflame"), 180, false);
		}
	}
}