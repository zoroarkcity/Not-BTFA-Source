using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles 
{
	public class BlightBoomRange : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 100;
			projectile.height = 100;
			projectile.aiStyle = 2;
			projectile.penetrate = -1;
			projectile.timeLeft = 10;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.tileCollide = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Fire");
		}
		public override bool PreAI()
		{
			int amountOfDust = 3;
			for (int i = 0; i < amountOfDust; ++i)
			{
				int dust;
				Vector2 dustPos = projectile.position + new Vector2(projectile.height/2, projectile.width/2);
				Vector2 newVect = new Vector2 (18, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(45)));
				Vector2 newVect2 = newVect.RotatedBy(MathHelper.ToRadians(45));
				Vector2 newVect3 = newVect.RotatedBy(MathHelper.ToRadians(90));
				Vector2 newVect4 = newVect.RotatedBy(MathHelper.ToRadians(135));
				Vector2 newVect5 = newVect.RotatedBy(MathHelper.ToRadians(180));
				Vector2 newVect6 = newVect.RotatedBy(MathHelper.ToRadians(225));
				Vector2 newVect7 = newVect.RotatedBy(MathHelper.ToRadians(270));
				Vector2 newVect8 = newVect.RotatedBy(MathHelper.ToRadians(315));
				dust = Dust.NewDust(dustPos, 0, 0, 173, newVect.X, newVect.Y);
				int dust2 = Dust.NewDust(dustPos, 0, 0, 173, newVect2.X, newVect2.Y);
				int dust3 = Dust.NewDust(dustPos, 0, 0, 173, newVect3.X, newVect3.Y);
				int dust4 = Dust.NewDust(dustPos, 0, 0, 173, newVect4.X, newVect4.Y);
				int dust5 = Dust.NewDust(dustPos, 0, 0, 173, newVect5.X, newVect5.Y);
				int dust6 = Dust.NewDust(dustPos, 0, 0, 173, newVect6.X, newVect6.Y);
				int dust7 = Dust.NewDust(dustPos, 0, 0, 173, newVect7.X, newVect7.Y);
				int dust8 = Dust.NewDust(dustPos, 0, 0, 173, newVect8.X, newVect8.Y);
				Main.dust[dust].scale = (float)(Main.rand.Next(20) * 0.1);
				Main.dust[dust].noGravity = true;
				Main.dust[dust2].scale = (float)(Main.rand.Next(20) * 0.1);
				Main.dust[dust2].noGravity = true;
				Main.dust[dust3].scale = (float)(Main.rand.Next(20) * 0.1);
				Main.dust[dust3].noGravity = true;
				Main.dust[dust4].scale = (float)(Main.rand.Next(20) * 0.1);
				Main.dust[dust4].noGravity = true;
				Main.dust[dust5].scale = (float)(Main.rand.Next(20) * 0.1);
				Main.dust[dust5].noGravity = true;
				Main.dust[dust6].scale = (float)(Main.rand.Next(20) * 0.1);
				Main.dust[dust6].noGravity = true;
				Main.dust[dust7].scale = (float)(Main.rand.Next(20) * 0.1);
				Main.dust[dust7].noGravity = true;
				Main.dust[dust8].scale = (float)(Main.rand.Next(20) * 0.1);
				Main.dust[dust8].noGravity = true;
			}
			return false;
		}
		public virtual bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("BlightFlame"), 580, false);
		}
	}
}	