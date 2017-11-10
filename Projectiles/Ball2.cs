using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class Ball2 : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = -1;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.alpha = 255;
			projectile.timeLeft = 360;
			projectile.extraUpdates = 1;
			projectile.light = 0.5f;
			projectile.scale = 1.2f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laser");
		}
		
		public override void AI()
		{
			int num;
			for (int num164 = 0; num164 < 6; num164 = num + 1)
			{
				float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)num164;
				float y2 = projectile.position.Y - projectile.velocity.Y / 10f * (float)num164;
				int num165 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 60, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num165].position.X = x2;
				Main.dust[num165].position.Y = y2;
				Dust dust3 = Main.dust[num165];
				dust3.velocity *= 0f;
				Main.dust[num165].noGravity = true;
				num = num164;
			}
		}
	}
}