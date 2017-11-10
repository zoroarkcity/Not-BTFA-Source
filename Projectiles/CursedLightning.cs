using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class CursedLightning : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 70;
			projectile.extraUpdates = 4;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Lightning");
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
             target.AddBuff(39, 180, false);
        }
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 75, 0f, 0f);
			Main.dust[dust].scale = 1f;
			Main.dust[dust].noGravity = true;

			if (Main.rand.Next(10) == 0)
			{
				Vector2 newVect = projectile.velocity.RotatedBy(System.Math.PI / 10);
				projectile.velocity = newVect;
			}	
			if (Main.rand.Next(10) == 0)
			{
				Vector2 newVect2 = projectile.velocity.RotatedBy(System.Math.PI / -10);
				projectile.velocity = newVect2;
			}			
		}
	}
}