using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles.Town
{
	public class FireGrenadeProjF : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.aiStyle = 14;
			projectile.penetrate = 1;
			projectile.timeLeft = 300;
			projectile.thrown = true;
			projectile.friendly = true;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fire Grenade");
		}
		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("FireGrenadeBoom"), projectile.damage, 0f, projectile.owner, 0f, 0f);
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 34);
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 180, false);
		}
	}
}	