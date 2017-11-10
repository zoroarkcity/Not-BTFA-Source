using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class gelchunk : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 200;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gel Chunk");
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, mod.DustType("geldust"), 0f, 0f);
			Main.dust[dust].scale = 1.5f;
			Main.dust[dust].noGravity = true;
		}
		
		public override void Kill(int timeLeft)
		{
			int amountOfProjectiles = Main.rand.Next(1, 4);
			
			for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-60, 61) * 0.1f;
					float sY = (float)Main.rand.Next(-60, 61) * 0.1f;
					int z = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, mod.ProjectileType("gelshot"), projectile.damage / 3, 5f, projectile.owner);
					Main.projectile[z].ranged = false;
					Main.projectile[z].magic = true;
					Main.projectile[z].timeLeft = 100;
				}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Gelled"), 60, false);
		}
	}
}