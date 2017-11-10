using Microsoft.Xna.Framework.Graphics;
using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class SolBeam : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 36;
			projectile.height = 36;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.tileCollide = true;
			projectile.penetrate = 1;
			projectile.light = 0.5f;
			projectile.alpha = 0;
			projectile.timeLeft = 100;
			Main.projFrames[projectile.type] = 4;
			projectile.scale = 1.25f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Solar Ball");
		}
		
		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 3)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			} 
			projectile.velocity *= 0.95f;
			if (Main.rand.Next(3) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 244, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i <= 3; i++)
			{
				float cX = projectile.Center.X;
				float cY = projectile.Center.Y;
				cX += Main.rand.Next(-45, 45);
				cY += Main.rand.Next(-45, 45);
				int kk = Projectile.NewProjectile(cX, cY, 0f, 0f, mod.ProjectileType("solarboom"), projectile.damage, 5f, projectile.owner);
				Main.projectile[kk].melee = false;
				Main.projectile[kk].magic = true;
			}
			
			for (int i = 0; i <= 2; i++)
			{
				float sX = Main.rand.Next(-60, 60) * 0.05f;
				float sY = Main.rand.Next(-60, 60) * 0.05f;
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, sX, sY, mod.ProjectileType("solarember"), projectile.damage/2, 5f, projectile.owner);
			}
		}
	}
}