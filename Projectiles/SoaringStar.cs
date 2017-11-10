using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles
{
    public class SoaringStar : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 36; 
            projectile.height = 40; 
            projectile.aiStyle = 5; 
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 10000;
            projectile.light = 0.2f;
			projectile.extraUpdates = 1;
			projectile.tileCollide = false;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soaring Star");
		}
		
		
		
		public override void Kill(int timeLeft)
		{

			projectile.position.X += (float) (projectile.width / 2);
			projectile.position.Y += (float) (projectile.height / 2);
			projectile.width = (int) (128.0 * (double) projectile.scale);
			projectile.height = (int) (128.0 * (double) projectile.scale);
			projectile.position.X -= (float) (projectile.width / 2);
			projectile.position.Y -= (float) (projectile.height / 2);
			int amountOfDust = 2;
			for (int i = 0; i < amountOfDust; ++i)
			{
				Vector2 vector2 = new Vector2(projectile.width/2, projectile.height/2);
				int dust;
				Vector2 newVect = new Vector2 (24, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(45)));
				Vector2 newVect2 = newVect.RotatedBy(MathHelper.ToRadians(45));
				Vector2 newVect3 = newVect.RotatedBy(MathHelper.ToRadians(90));
				Vector2 newVect4 = newVect.RotatedBy(MathHelper.ToRadians(135));
				Vector2 newVect5 = newVect.RotatedBy(MathHelper.ToRadians(180));
				Vector2 newVect6 = newVect.RotatedBy(MathHelper.ToRadians(225));
				Vector2 newVect7 = newVect.RotatedBy(MathHelper.ToRadians(270));
				Vector2 newVect8 = newVect.RotatedBy(MathHelper.ToRadians(315));
				dust = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("SoaringDust"), newVect.X, newVect.Y);
				int dust2 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("SoaringDust"), newVect2.X, newVect2.Y);
				int dust3 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("SoaringDust"), newVect3.X, newVect3.Y);
				int dust4 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("SoaringDust"), newVect4.X, newVect4.Y);
				int dust5 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("SoaringDust"), newVect5.X, newVect5.Y);
				int dust6 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("SoaringDust"), newVect6.X, newVect6.Y);
				int dust7 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("SoaringDust"), newVect7.X, newVect7.Y);
				int dust8 = Dust.NewDust(projectile.position + vector2, 0, 0, mod.DustType("SoaringDust"), newVect8.X, newVect8.Y);
				Main.dust[dust].noGravity = true;
				Main.dust[dust2].noGravity = true;
				Main.dust[dust3].noGravity = true;
				Main.dust[dust4].noGravity = true;
				Main.dust[dust5].noGravity = true;
				Main.dust[dust6].noGravity = true;
				Main.dust[dust7].noGravity = true;
				Main.dust[dust8].noGravity = true;
				Main.dust[dust].scale = 2;
				Main.dust[dust2].scale = 2;
				Main.dust[dust3].scale = 2;
				Main.dust[dust4].scale = 2;
				Main.dust[dust5].scale = 2;
				Main.dust[dust6].scale = 2;
				Main.dust[dust7].scale = 2;
				Main.dust[dust8].scale = 2;
			}
		}
		
		
		public override void PostAI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			projectile.tileCollide = false;
			Player player = Main.player[projectile.owner];
			if (projectile.position.Y >= player.position.Y)
			{
				projectile.tileCollide = true;
			}
		}

    }
}