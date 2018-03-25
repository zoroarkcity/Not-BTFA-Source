using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class SpinalFountain : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 10;
			projectile.timeLeft = 60;
			projectile.alpha = 255;
			projectile.extraUpdates = 1;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spinal Bolt");
		}
		
		public override void AI()
		{
			projectile.ai[0]++;
			if (projectile.ai[0] > 4)
			{
				int p = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("SpinalFountain2"), projectile.damage, 1f, projectile.owner, 0, 0);
				
				if (projectile.ai[1] == 1f)
				{
					Main.projectile[p].magic = false;
					Main.projectile[p].friendly = false;
					Main.projectile[p].hostile = true;
					Main.projectile[p].ai[1] = 1f;
				}

				projectile.ai[0] = 0;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("DevilsFlame"), 360, false);
		}

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (projectile.ai[1] == 1f)
				target.AddBuff(BuffID.Bleeding, 30 * Main.rand.Next(12, 21)); //6-10 sec
		}
	}
}