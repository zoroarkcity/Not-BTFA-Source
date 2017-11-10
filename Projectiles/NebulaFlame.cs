using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class NebulaFlame : ModProjectile
	{
		int timer = 0;
		
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 200;
			projectile.tileCollide = false;
			Main.projFrames[projectile.type] = 4;
			projectile.scale = 1.2f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nebula Flame");
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 242, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].scale = 1.2f;
			Main.dust[dust].noGravity = true;
			
			timer++;
			
			projectile.frameCounter++;
			if (projectile.frameCounter >= 3)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			} 
			
			if (timer >= 25)
			{
				Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.Lerp(-(.5f/3.14f), (.5f / 3.14f), (1f / (3f - 1f))));
				Vector2 move = Vector2.Zero;
				float distance = 400f;
				bool target = false;
				for (int k = 0; k < 200; k++)
				{
					if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
					{
						Vector2 newMove = Main.npc[k].Center - projectile.Center;
						float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
						if (distanceTo < distance)
						{
							newMove.Normalize();
							move = newMove;
							distance = distanceTo;
							target = true;
						}
					}
				}
				if (target)
				{
					projectile.velocity = (move * 20f);
				}
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("neboom"), 50, 5f, projectile.owner);
		}
	}
}