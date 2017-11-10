using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.GhastlyEnt 
{
	public class SapSphere : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 2;
			projectile.penetrate = 5;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.alpha = 0;
			projectile.timeLeft = 150;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corrosive Sap");
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(186, 500, false);
		}
		
		public override void AI()
		{
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 64, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}
		
	}
}