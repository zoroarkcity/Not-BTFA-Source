using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class AngerBolt : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.melee = true;
			projectile.penetrate = 1;
			projectile.alpha = 255;
			projectile.timeLeft = 60;
			projectile.tileCollide = false;
			projectile.extraUpdates = 1;
			projectile.light = 0.5f;
			projectile.scale = 1.2f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Anger Bolt");
		}

		
		public override void AI()
		{
			int num;
			if (projectile.timeLeft <= 358)
			{
				for (int num164 = 0; num164 < 10; num164 = num + 1)
				{
					float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)num164;
					float y2 = projectile.position.Y - projectile.velocity.Y / 10f * (float)num164;
					int num165 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 6, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num165].position.X = x2;
					Main.dust[num165].position.Y = y2;
					Dust dust3 = Main.dust[num165];
					dust3.velocity *= 0f;
					Main.dust[num165].noGravity = true;
					num = num164;
				}
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			int ree = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, 612, projectile.damage, 5f, projectile.owner);
			Main.projectile[ree].melee = false;
			Main.projectile[ree].penetrate = -1;
		}
	}
}
