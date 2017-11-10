using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Bazaar
{
	public class IntergalacticBolt : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 100;
			projectile.alpha = 255;
			projectile.tileCollide = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Intergalactic");
		}
		
		public override void AI()
		{
			if (projectile.timeLeft <= 98)
			{
				for (int index1 = 0; index1 < 2; ++index1)
				{
					float num1 = projectile.velocity.X / 3f * (float) index1;
					float num2 = projectile.velocity.Y / 3f * (float) index1;
					int num3 = 4;
					int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, 62);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity *= 0.1f;
					Main.dust[index2].velocity += projectile.velocity * 0.1f;
					Main.dust[index2].position.X -= num1;
					Main.dust[index2].position.Y -= num2;
				}
				int num6 = 4;
				int index3 = Dust.NewDust(new Vector2(projectile.position.X + (float) num6, projectile.position.Y + (float) num6), projectile.width - num6 * 2, projectile.height - num6 * 2, mod.DustType("SpaceDust"));
				Main.dust[index3].noGravity = true;
				Main.dust[index3].velocity *= 0.1f;
				Main.dust[index3].velocity += projectile.velocity * 0.1f;
				Main.dust[index3].scale = 1.2f;
			}
		}
	}
}