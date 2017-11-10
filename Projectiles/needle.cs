using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class needle : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 6;
			projectile.height = 10;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.alpha = 255;
			projectile.light = 0.5f;
			projectile.extraUpdates = 1;
			projectile.ranged = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Needle");
			aiType = ProjectileID.Bullet;
		}
		
		public override void AI()
		{
			if (Main.rand.Next(10) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.Center, projectile.width, projectile.height, 60, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
		
	}
}