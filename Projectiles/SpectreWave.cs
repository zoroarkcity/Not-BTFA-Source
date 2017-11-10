using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class SpectreWave : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 100;
			projectile.light = 0.5f;
			projectile.extraUpdates = 1;
			projectile.tileCollide = false;
			projectile.scale = 1.3f;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spectre Wave");
		}
		
		public override void AI()
		{
			if (projectile.timeLeft <= 90)
			{
				for (int index1 = 0; index1 < 3; ++index1)
				{
					float num1 = projectile.velocity.X / 3f * (float) index1;
					float num2 = projectile.velocity.Y / 3f * (float) index1;
					int num3 = 4;
					int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, 56, 0.0f, 0.0f, 100, new Color(), 1.4f);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity *= 0.1f;
					Main.dust[index2].velocity += projectile.velocity * 0.1f;
					Main.dust[index2].position.X -= num1;
					Main.dust[index2].position.Y -= num2;
					Main.dust[index2].scale = 1.2f;
				}
			}
		}
	}
}