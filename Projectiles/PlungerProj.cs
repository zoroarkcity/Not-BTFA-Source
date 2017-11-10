using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class PlungerProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 10;
			projectile.penetrate = 1;
			projectile.ranged = true;
			projectile.friendly = true;
			projectile.alpha = 0;
			projectile.aiStyle = 1;
			projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
		}
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 0);
				Main.dust[dust].scale = 1.2f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}
	}
}
