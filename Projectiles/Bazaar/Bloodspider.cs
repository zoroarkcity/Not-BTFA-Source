using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Bazaar
{
	public class Bloodspider : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 24;
			projectile.height = 24;
            projectile.aiStyle = 2;
            projectile.friendly = true;
            projectile.magic = true;
			projectile.timeLeft = 600;
			projectile.penetrate = 1;
			projectile.ignoreWater = true;
			aiType = ProjectileID.BeachBall;
		}
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 10; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 5);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 21);
		}
	}
}
