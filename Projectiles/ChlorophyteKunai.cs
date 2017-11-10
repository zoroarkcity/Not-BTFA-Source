using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class ChlorophyteKunai : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = 6;
			projectile.timeLeft = 1000;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chlorophyte Kunai");
		}
		
		public override void Kill(int timeLeft)
		{
			if (Main.rand.Next(3) == 0)
        	{
        		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("ChlorophyteKunai"));
        	}
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 128);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			int amountOfProjectiles = Main.rand.Next(1, 4);
			
			for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-60, 61) * 0.1f;
					float sY = (float)Main.rand.Next(-60, 61) * 0.1f;
					int z = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, 228, projectile.damage / 2, 5f, projectile.owner);
					Main.projectile[z].melee = false;
					Main.projectile[z].thrown = true;
					Main.projectile[z].timeLeft = 15;
				}
		}
		
		public override void AI()
		{
			if (projectile.velocity.X >= 0)
			{
				projectile.velocity.X -= 0.10f;
			}
			if (projectile.velocity.X <= 0)
			{
				projectile.velocity.X += 0.10f;
			}
			if (projectile.velocity.X == 0)
			{
				projectile.velocity.X -= 0f;
			}
			projectile.velocity.Y += 0.10f;
			if (Main.rand.Next(5) == 0)
			{
				int dust2 = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0,  128, 0f, 0f);
			}
		}
	}
}