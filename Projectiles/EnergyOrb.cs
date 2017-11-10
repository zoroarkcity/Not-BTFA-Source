using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class EnergyOrb : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 24;
			projectile.height = 10;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.magic = true;
			Main.projFrames[projectile.type] = 4;
			projectile.penetrate = 1;
			projectile.alpha = 255;
			projectile.light = 0.5f;
			aiType = ProjectileID.Bullet;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laser Bullet");
		}
		
		public override void AI()
		{
			if (Main.rand.Next(10) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, (int)projectile.width/4, (int)projectile.height/4, 130, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 0.5f;
				Main.dust[dust].noGravity = true;
			}
			
			projectile.frameCounter++;
			if (projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			}
			
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item89, projectile.position);
			projectile.position.X += (float) (projectile.width / 2);
			projectile.position.Y += (float) (projectile.height / 2);
			projectile.height = (int)(150 * projectile.scale);
			projectile.width = (int)(150 * projectile.scale);
			projectile.position.X -= (float) (projectile.width / 2);
			projectile.position.Y -= (float) (projectile.height / 2);
			int amountOfDust = 5;
			for (int i = 0; i < amountOfDust; ++i)
			{
				Vector2 vector2 = new Vector2(projectile.width/2, projectile.height/2);
				int dust;
				Vector2 newVect = new Vector2 (6, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(45)));
				Vector2 newVect2 = newVect.RotatedBy(MathHelper.ToRadians(45));
				Vector2 newVect3 = newVect.RotatedBy(MathHelper.ToRadians(90));
				Vector2 newVect4 = newVect.RotatedBy(MathHelper.ToRadians(135));
				Vector2 newVect5 = newVect.RotatedBy(MathHelper.ToRadians(180));
				Vector2 newVect6 = newVect.RotatedBy(MathHelper.ToRadians(225));
				Vector2 newVect7 = newVect.RotatedBy(MathHelper.ToRadians(270));
				Vector2 newVect8 = newVect.RotatedBy(MathHelper.ToRadians(315));
				dust = Dust.NewDust(projectile.position + vector2, 0, 0, 130, newVect.X, newVect.Y);
				int dust2 = Dust.NewDust(projectile.position + vector2, 0, 0, 130, newVect2.X, newVect2.Y);
				int dust3 = Dust.NewDust(projectile.position + vector2, 0, 0, 130, newVect3.X, newVect3.Y);
				int dust4 = Dust.NewDust(projectile.position + vector2, 0, 0, 130, newVect4.X, newVect4.Y);
				int dust5 = Dust.NewDust(projectile.position + vector2, 0, 0, 130, newVect5.X, newVect5.Y);
				int dust6 = Dust.NewDust(projectile.position + vector2, 0, 0, 130, newVect6.X, newVect6.Y);
				int dust7 = Dust.NewDust(projectile.position + vector2, 0, 0, 130, newVect7.X, newVect7.Y);
				int dust8 = Dust.NewDust(projectile.position + vector2, 0, 0, 130, newVect8.X, newVect8.Y);
				Main.dust[dust].noGravity = true;
				Main.dust[dust2].noGravity = true;
				Main.dust[dust3].noGravity = true;
				Main.dust[dust4].noGravity = true;
				Main.dust[dust5].noGravity = true;
				Main.dust[dust6].noGravity = true;
				Main.dust[dust7].noGravity = true;
				Main.dust[dust8].noGravity = true;
			}
			if (projectile.owner == Main.myPlayer)
			{
			  projectile.localAI[1] = -1f;
			  projectile.maxPenetrate = 0;
			  projectile.Damage();
			}
		}
	}
}