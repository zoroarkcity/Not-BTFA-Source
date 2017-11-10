using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class infrost : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 80;
			projectile.height = 48;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 60;
			projectile.alpha = 0;
			projectile.light = 0.5f;
			projectile.tileCollide = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("infrost");
		}
		
		public override void AI()
		{
			projectile.velocity.X *= 0.975f;
            projectile.velocity.Y *= 0.975f;
			
			if (Main.rand.Next(10) == 0 && projectile.alpha <= 190)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 67, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			if (Main.rand.Next(6) == 0 && projectile.alpha <= 190)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 59, projectile.velocity.X * -1f, projectile.velocity.Y * -1f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			projectile.alpha += 4;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
			{
				target.AddBuff(BuffID.Frostburn, 60, false);
			}
			if (Main.rand.Next(5) == 0)
			{
				target.AddBuff(mod.BuffType("Frozen"), 10, false);
			}
		}
		
	}
}