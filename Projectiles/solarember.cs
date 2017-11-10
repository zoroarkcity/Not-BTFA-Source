using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class solarember : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 2;
			projectile.height = 2;
			projectile.aiStyle = 2;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 120;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Solar Ember");
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 6, 0f, 0f);
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.velocity *= 0;
			projectile.aiStyle = 0;
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(189, 30, false);
		}
	}
}