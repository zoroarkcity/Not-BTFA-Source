using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles.SinFlower
{
	public class FlameBoltMini : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 70;
			projectile.extraUpdates = 4;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flame Bolt");
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 60, false);
			target.AddBuff(mod.BuffType("DevilsFlame"), 60, false);
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 127, 0f, 0f);
			Main.dust[dust].scale = 1f;
			Main.dust[dust].noGravity = true;

			if (Main.rand.Next(15) == 0)
			{
				Vector2 newVect = projectile.velocity.RotatedBy(System.Math.PI / 25);
				projectile.velocity = newVect;
			}	
			if (Main.rand.Next(15) == 0)
			{
				Vector2 newVect2 = projectile.velocity.RotatedBy(System.Math.PI / -25);
				projectile.velocity = newVect2;
			}			
		}
	}
}