using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Acheron
{
	public class SoulWell : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 152;
			projectile.height = 152;
			projectile.aiStyle = -1;
			projectile.hostile = true;
			projectile.penetrate = -1;
			projectile.alpha = 255;
			projectile.tileCollide = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lost Soul");
		}
		

		public override void AI()
		{
			projectile.ai[0]++;
			projectile.rotation += 0.1f;
			if (projectile.ai[0] < 51)
				projectile.alpha -= 5;
			
			else if (projectile.ai[0]  < 549)
			{
				projectile.ai[1]++;
				if (projectile.ai[1] > 80)
				{
					Vector2 Vel = (Main.player[Player.FindClosest(projectile.Center, 0, 0)].Center - projectile.Center);
					Vel.Normalize();
					Vel *= 10;
					Vector2 Vel2 = Vel.RotatedBy(MathHelper.Pi / 6);
					Vector2 Vel3 = Vel.RotatedBy(-MathHelper.Pi / 6);
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Vel3.X, Vel3.Y, mod.ProjectileType("HomingSoul2"), projectile.damage, 5f, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Vel2.X, Vel2.Y, mod.ProjectileType("HomingSoul2"), projectile.damage, 5f, projectile.owner);
					projectile.ai[1] = 0;
				}
			}
			else
			{
				projectile.alpha += 5;
				if (projectile.alpha > 255)
					projectile.Kill();
			}
		}
	}
}