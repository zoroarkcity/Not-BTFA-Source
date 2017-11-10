using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles 
{
	public class PurpleDartBoom : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 100;
			projectile.height = 100;
			projectile.aiStyle = 2;
			projectile.penetrate = -1;
			projectile.ranged = true;
			projectile.timeLeft = 5;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.tileCollide = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Purple Dart");
		}
		
		
		public override bool PreAI()
		{
			int amountOfDust = 2;
			for (int i = 0; i < amountOfDust; ++i)
			{
				Vector2 vector2 = new Vector2(projectile.width/2, projectile.height/2);
				int dust;
				Vector2 newVect = new Vector2 (18, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(45)));
				Vector2 newVect2 = newVect.RotatedBy(MathHelper.ToRadians(45));
				Vector2 newVect3 = newVect.RotatedBy(MathHelper.ToRadians(90));
				Vector2 newVect4 = newVect.RotatedBy(MathHelper.ToRadians(135));
				Vector2 newVect5 = newVect.RotatedBy(MathHelper.ToRadians(180));
				Vector2 newVect6 = newVect.RotatedBy(MathHelper.ToRadians(225));
				Vector2 newVect7 = newVect.RotatedBy(MathHelper.ToRadians(270));
				Vector2 newVect8 = newVect.RotatedBy(MathHelper.ToRadians(315));
				dust = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("BouncyDust"), newVect.X, newVect.Y);
				int dust2 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("BouncyDust"), newVect2.X, newVect2.Y);
				int dust3 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("BouncyDust"), newVect3.X, newVect3.Y);
				int dust4 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("BouncyDust"), newVect4.X, newVect4.Y);
				int dust5 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("BouncyDust"), newVect5.X, newVect5.Y);
				int dust6 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("BouncyDust"), newVect6.X, newVect6.Y);
				int dust7 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("BouncyDust"), newVect7.X, newVect7.Y);
				int dust8 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("BouncyDust"), newVect8.X, newVect8.Y);
				Main.dust[dust].noGravity = true;
				Main.dust[dust2].noGravity = true;
				Main.dust[dust3].noGravity = true;
				Main.dust[dust4].noGravity = true;
				Main.dust[dust5].noGravity = true;
				Main.dust[dust6].noGravity = true;
				Main.dust[dust7].noGravity = true;
				Main.dust[dust8].noGravity = true;
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust2].scale = 1.5f;
				Main.dust[dust3].scale = 1.5f;
				Main.dust[dust4].scale = 1.5f;
				Main.dust[dust5].scale = 1.5f;
				Main.dust[dust6].scale = 1.5f;
				Main.dust[dust7].scale = 1.5f;
				Main.dust[dust8].scale = 1.5f;
			}
			return false;
		}
		
		public virtual bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}

	}
}	