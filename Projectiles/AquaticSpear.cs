using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class AquaticSpear : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 19;
			projectile.height = 19;
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
			DisplayName.SetDefault("Aquatic Spear");
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
				projectile.ai[0] -= 0.5f;
				if (projectile.localAI[0] == 0f && Main.myPlayer == projectile.owner)
				{
					projectile.localAI[0] = 1f;
					if (Main.rand.Next(2) == 0)
					{
						Projectile.NewProjectile(projectile.Center.X + (projectile.velocity.X * 3/4), projectile.Center.Y + (projectile.velocity.Y * 3/4), projectile.velocity.X * 1.4f, projectile.velocity.Y * 1.4f, mod.ProjectileType("AquaBolt"), (int)((double)projectile.damage * 0.85f), projectile.knockBack * 0.85f, projectile.owner, 0f, 0f);
					}
				}
        	}
			else
			{
				projectile.ai[0] += 0.5f;
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
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 33, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
			}
			projectile.position += projectile.velocity * projectile.ai[0];
		}
	}
}