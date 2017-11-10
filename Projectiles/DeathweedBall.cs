using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class DeathweedBall : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 42;
			projectile.height = 42;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 5;
			projectile.timeLeft = 180;
			projectile.tileCollide = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Deathweed Ball");
		}
		
		public override void AI()
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.Center + projectile.velocity, projectile.width, projectile.height, 77, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].noGravity = true;
			}
			projectile.rotation += 0.1f;
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 77);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
	}
}