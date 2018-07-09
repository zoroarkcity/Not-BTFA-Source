using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class TitanBat : ModProjectile
	{
		int npc;
		float moveX;
		float moveY;
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 14;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 1;
			projectile.alpha = 255;
			projectile.tileCollide = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titan Bat");
			Main.projFrames[projectile.type] = 4;
		}
		
		public override void AI()
		{
			if (projectile.alpha > 0)
			{
				projectile.alpha -= 25;
			}
			else
			{
				projectile.alpha = 0;
			}
			
			projectile.spriteDirection = (projectile.velocity.X < 0) ? 1 : -1;
			projectile.rotation = projectile.velocity.X * 0.05f;
			projectile.frameCounter++;
			if (projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			}
			
			Vector2 move = Vector2.Zero;
			float distance = 190f;
			bool target = false;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && Main.npc[k].type != 488)
				{
					Vector2 newMove = Main.npc[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						newMove.Normalize();
						move = newMove;
						distance = distanceTo;
						target = true;
						npc = k;
					}
				}
			}
			if (target)
			{
				if(projectile.Center.X > Main.npc[npc].Center.X && moveX > -3f)
					moveX -= 0.2f;
				if(projectile.Center.X > Main.npc[npc].Center.X && moveX > 0f)
					moveX -= 1f;
				
				if(projectile.Center.X < Main.npc[npc].Center.X && moveX < 3f)
					moveX += 0.2f;
				if(projectile.Center.X < Main.npc[npc].Center.X && moveX < 0f)
					moveX += 1f;
				
				if(projectile.Center.Y < Main.npc[npc].Center.Y && moveY < 2f)
					moveY += 0.2f;
				if(projectile.Center.Y < Main.npc[npc].Center.Y && moveY < 0f)
					moveY += 1f;
				
				if(projectile.Center.Y > Main.npc[npc].Center.Y && moveY > -2f)
					moveY -= 0.2f;
				if(projectile.Center.Y > Main.npc[npc].Center.Y && moveY > 0f)
					moveY -= 1f;

				projectile.velocity = new Vector2(moveX, moveY);
			}
			
			projectile.ai[0]++;
			if (projectile.ai[0] > 30)
			{
				projectile.netUpdate = true;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 10; ++i)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 60);
			}
			
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 1);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, projectile.position);
		}
	}
}