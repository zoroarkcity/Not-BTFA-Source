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
		
		private void MakeProjectile(Vector2 velocity, int type)
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, velocity.X, velocity.Y, type, projectile.damage, 5f, projectile.owner);
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
				if (projectile.ai[1] % 80 == 0)
                {
					Player player = Main.player[Player.FindClosest(projectile.Center, 0, 0)];
					Vector2 Vel = (player.Center - projectile.Center);
					Vel.Normalize();
					Vector2 Vel2;
					Vector2 Vel3;
					int type;
					if (Main.expertMode && projectile.ai[1] % 240 == 0) //replaces every third shot in expert
					{
						Vel *= 12;
						Vel2 = Vel.RotatedBy(MathHelper.Pi / 10);
						Vel3 = Vel.RotatedBy(-MathHelper.Pi / 10);
						type = mod.ProjectileType("HomingSoul");
						MakeProjectile(Vel, type);
					}
					else
					{
						Vel *= 10;
						Vel2 = Vel.RotatedBy(MathHelper.Pi / 6);
						Vel3 = Vel.RotatedBy(-MathHelper.Pi / 6);
						type = mod.ProjectileType("HomingSoul2");
					}
					MakeProjectile(Vel2, type);
					MakeProjectile(Vel3, type);
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