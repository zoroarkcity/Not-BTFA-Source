using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles 
{
	public class ChainingLightning : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 100;
			projectile.height = 100;
			projectile.aiStyle = 2;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.timeLeft = 5;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.tileCollide = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Electricity");
		}
		public override bool PreAI()
		{
			int amountOfDust = 2;
			for (int i = 0; i < amountOfDust; ++i)
			{
				projectile.tileCollide = false;
				int dust;
				dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 226, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			return false;
		}
		public virtual bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("ChainingLightning"), projectile.damage, 5f, projectile.owner);
		}
	}
}	