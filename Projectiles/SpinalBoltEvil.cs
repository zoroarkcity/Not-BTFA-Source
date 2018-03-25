using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class SpinalBoltEvil : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 0;
			projectile.hostile = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 450;
			projectile.alpha = 255;
            //projectile.noGravity = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spinal Bolt");
		}
		
		public override void AI()
		{
			for (int index1 = 0; index1 < 2; ++index1)
			{
				float num1 = projectile.velocity.X / 3f * (float) index1;
				float num2 = projectile.velocity.Y / 3f * (float) index1;
				int num3 = 4;
				int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, mod.DustType("BloodDust2"), 0.0f, 0.0f, 0, default(Color), 1f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].scale = 1.6f;
				Main.dust[index2].velocity *= 0.1f;
				Main.dust[index2].velocity += projectile.velocity * 0.1f;
				Main.dust[index2].position.X -= num1;
				Main.dust[index2].position.Y -= num2;
			}
			if (Main.rand.Next(2) == 0)
			{
				int num = 4;
				int index = Dust.NewDust(new Vector2(projectile.position.X + (float) num, projectile.position.Y + (float) num), projectile.width - num * 2, projectile.height - num * 2, 60, 0.0f, 0.0f, 0, default(Color), 1f);
				Main.dust[index].velocity *= 0.25f;
				Main.dust[index].velocity += projectile.velocity * 0.5f;
				Main.dust[index].noGravity = true;
			}

            if (projectile.ai[0] == 1f)
                projectile.velocity.Y += 0.35f;
		}

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.Bleeding, 30 * Main.rand.Next(12, 21)); //6-10 sec
		}
		
		public override bool PreKill(int timeLeft)
		{
			int p = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, -4f, mod.ProjectileType("SpinalFountain"), projectile.damage, 1f, projectile.owner, 0, 1f);
			Main.projectile[p].magic = false;
			Main.projectile[p].friendly = false;
			Main.projectile[p].hostile = true;
			Main.projectile[p].timeLeft += 120 + 15 * Main.rand.Next(9); //180 to 300 ticks total
			return true;
		}
	}
}