using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class RedwoodPike : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 40;
			projectile.scale = 1.1f;
			projectile.aiStyle = 19;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.timeLeft = 90;
			projectile.hide = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Redwood Pike");
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			target.immune[projectile.owner] = 11;
		}


		public override void AI()
		{
			Main.player[projectile.owner].direction = projectile.direction;
			Main.player[projectile.owner].heldProj = projectile.whoAmI;
			Main.player[projectile.owner].itemTime = Main.player[projectile.owner].itemAnimation;
			projectile.position.X = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - (float)(projectile.width / 2);
			projectile.position.Y = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - (float)(projectile.height / 2);
			if (projectile.ai[0] == 0f)
			{
				projectile.ai[0] = 3f;
				projectile.netUpdate = true;
			}
			if (Main.player[projectile.owner].itemAnimation < Main.player[projectile.owner].itemAnimationMax / 3)
			{
				projectile.ai[0] -= 1f;
				if (projectile.localAI[0] == 0f && Main.myPlayer == projectile.owner)
				{
					projectile.localAI[0] = 1f;
				}
        	}
			else
			{
				projectile.ai[0] += 1.2f;
			}

			if (Main.player[projectile.owner].itemAnimation == 0)
			{
				projectile.Kill();
			}

			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 2.355f;
			if (projectile.spriteDirection == -1)
			{
				projectile.rotation -= 1.57f;
			}
			
			if (Main.rand.Next(5) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.Center + (projectile.velocity * 9f), projectile.width, projectile.height, 7, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 0.7f;
			}
			projectile.position += projectile.velocity * projectile.ai[0];
		}
	}
}