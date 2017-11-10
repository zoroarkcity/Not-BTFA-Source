using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Bazaar
{
	public class AtlanteanProj : ModProjectile
	{
		int timer = 0;
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 10f;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 200f;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 10f;
		}

		public override void SetDefaults()
		{
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
		}
		
		public override void AI()
		{
			timer++;
			if (timer >= 80)
			{
				for (int i = 0; i < 2; ++i)
				{
					Vector2 newVect1 = new Vector2 (8, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(360)));
					int proj = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect1.X, newVect1.Y, mod.ProjectileType("AtlanteanWater"), projectile.damage, 5f, projectile.owner);
					Main.projectile[proj].ranged = false;
					Main.projectile[proj].melee = true;
				}
				timer = 0;
				Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 25);
				Vector2 vector2 = new Vector2(projectile.width/2, projectile.height/2);
				int dust;
				Vector2 newVect = new Vector2 (8, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(45)));
				Vector2 newVect2 = newVect.RotatedBy(MathHelper.ToRadians(45));
				Vector2 newVect3 = newVect.RotatedBy(MathHelper.ToRadians(90));
				Vector2 newVect4 = newVect.RotatedBy(MathHelper.ToRadians(135));
				Vector2 newVect5 = newVect.RotatedBy(MathHelper.ToRadians(180));
				Vector2 newVect6 = newVect.RotatedBy(MathHelper.ToRadians(225));
				Vector2 newVect7 = newVect.RotatedBy(MathHelper.ToRadians(270));
				Vector2 newVect8 = newVect.RotatedBy(MathHelper.ToRadians(315));
				dust = Dust.NewDust(projectile.position + vector2, 0, 0, 33, newVect.X, newVect.Y);
				int dust2 = Dust.NewDust(projectile.position + vector2, 0, 0, 33, newVect2.X, newVect2.Y);
				int dust3 = Dust.NewDust(projectile.position + vector2, 0, 0, 33, newVect3.X, newVect3.Y);
				int dust4 = Dust.NewDust(projectile.position + vector2, 0, 0, 33, newVect4.X, newVect4.Y);
				int dust5 = Dust.NewDust(projectile.position + vector2, 0, 0, 33, newVect5.X, newVect5.Y);
				int dust6 = Dust.NewDust(projectile.position + vector2, 0, 0, 33, newVect6.X, newVect6.Y);
				int dust7 = Dust.NewDust(projectile.position + vector2, 0, 0, 33, newVect7.X, newVect7.Y);
				int dust8 = Dust.NewDust(projectile.position + vector2, 0, 0, 33, newVect8.X, newVect8.Y);
				Main.dust[dust].noGravity = true;
				Main.dust[dust2].noGravity = true;
				Main.dust[dust3].noGravity = true;
				Main.dust[dust4].noGravity = true;
				Main.dust[dust5].noGravity = true;
				Main.dust[dust6].noGravity = true;
				Main.dust[dust7].noGravity = true;
				Main.dust[dust8].noGravity = true;
				Main.dust[dust].scale = 3;
				Main.dust[dust2].scale = 3;
				Main.dust[dust3].scale = 3;
				Main.dust[dust4].scale = 3;
				Main.dust[dust5].scale = 3;
				Main.dust[dust6].scale = 3;
				Main.dust[dust7].scale = 3;
				Main.dust[dust8].scale = 3;
			}
		}
	}
}
