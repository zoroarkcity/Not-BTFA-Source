using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;
using ForgottenMemories.Projectiles.InfoA;

namespace ForgottenMemories.Projectiles
{
	public class SpiderWeb : ModProjectile
	{
		int timer = 0;
		int timer2 = 0;
		public override void SetDefaults()
		{
			projectile.width = 78;
			projectile.height = 76;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 100;
			projectile.alpha = 255;
			projectile.tileCollide = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("DeathWeb");
		}
		
		
		public override bool PreAI()
		{
			if (projectile.alpha >= 10)
			{
				projectile.alpha -= 4;
			}
			timer++;
			timer2++;
			if (timer <= 5)
			{
				int amountOfDust = 2;
				for (int i = 0; i < amountOfDust; ++i)
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
					dust = Dust.NewDust(projectile.position + vector2, 0, 0, 14, newVect.X, newVect.Y);
					int dust2 = Dust.NewDust(projectile.position + vector2, 0, 0, 14, newVect2.X, newVect2.Y);
					int dust3 = Dust.NewDust(projectile.position + vector2, 0, 0, 14, newVect3.X, newVect3.Y);
					int dust4 = Dust.NewDust(projectile.position + vector2, 0, 0, 14, newVect4.X, newVect4.Y);
					int dust5 = Dust.NewDust(projectile.position + vector2, 0, 0, 14, newVect5.X, newVect5.Y);
					int dust6 = Dust.NewDust(projectile.position + vector2, 0, 0, 14, newVect6.X, newVect6.Y);
					int dust7 = Dust.NewDust(projectile.position + vector2, 0, 0, 14, newVect7.X, newVect7.Y);
					int dust8 = Dust.NewDust(projectile.position + vector2, 0, 0, 14, newVect8.X, newVect8.Y);
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
			
			if (timer2 >= 15)
			{
				int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, 379, projectile.damage, 5f, projectile.owner);
				Main.projectile[proj].magic = true;
				Main.projectile[proj].friendly = true;
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].timeLeft = 120;
				Main.projectile[proj].GetGlobalProjectile<Info>(mod).NotSummon = true;
				timer2 = 0;
			}
			
			int deadchildren;
			deadchildren = Dust.NewDust(projectile.position, projectile.width, projectile.height, 65, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[deadchildren].scale = 1f;
			Main.dust[deadchildren].noGravity = true;
			return false;
		}
		
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 14);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Venom, 180, false);
		}
	}
}