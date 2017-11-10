using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Bazaar
{
	public class AtlanteanWater : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 2;
			projectile.timeLeft = 80;
			projectile.alpha = 255;
			projectile.tileCollide = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Water");
		}
		
		public override void AI()
		{
			if (projectile.timeLeft <= 75 && projectile.timeLeft >= 2)
			{
				for (int index1 = 0; index1 < 2; ++index1)
				{
					float num1 = projectile.velocity.X / 3f * (float) index1;
					float num2 = projectile.velocity.Y / 3f * (float) index1;
					int num3 = 4;
					int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, 33);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity *= 0.1f;
					Main.dust[index2].velocity += projectile.velocity * 0.1f;
					Main.dust[index2].position.X -= num1;
					Main.dust[index2].position.Y -= num2;
					Main.dust[index2].scale = 1.5f;
				}
			}
			projectile.velocity *= 0.96f;
		}
	
	public override void Kill(int timeLeft)
	{
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