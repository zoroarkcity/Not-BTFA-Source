using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles 
{
	public class IcearrowFreeze : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 250;
			projectile.height = 250;
			projectile.timeLeft = 5;
			projectile.penetrate = -1;
			projectile.ranged = true;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.tileCollide = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Icy Aura");
		}
		public override bool PreAI()
		{
			int amountOfDust = (projectile.width/35);
			for (int i = 0; i < amountOfDust; ++i)
				{
					projectile.tileCollide = false;
					int dust;
					dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 135, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
					Main.dust[dust].noGravity = true;
				}
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			if (Main.rand.Next(4) < 2)
			{
				target.AddBuff(BuffID.Frostburn, 60, false);
			}
			if (Main.rand.Next(100) < 99)
			{
				target.AddBuff(mod.BuffType("Frozen"), 10, false);
			}
		}
		
		public virtual bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
	}
}	