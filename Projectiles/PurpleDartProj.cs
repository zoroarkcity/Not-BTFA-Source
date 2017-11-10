using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles
{
	public class PurpleDartProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 5;
			projectile.height = 7;
			projectile.aiStyle = 1;
			projectile.penetrate = 1;
			projectile.ranged = true;
			projectile.friendly = true;
			projectile.timeLeft = 3000;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Purple Dart");
		}
		
		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("PurpleDartBoom"), projectile.damage, 0f, projectile.owner, 0f, 0f);
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 34);
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			target.immune[projectile.owner] = 5;
		}
	}
}	