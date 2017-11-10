using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class LightBall : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 5;
			projectile.height = 5;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 1;
			projectile.ignoreWater = false;
			projectile.timeLeft = 70;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("LightBall");
		}
		
		public override void AI()
		{
			for (int index1 = 0; index1 < 7; ++index1)
			{
				float num1 = projectile.velocity.X / 3f * (int)index1;
				float num2 = projectile.velocity.Y / 3f * (int)index1;
				int num3 = 4;
				int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, 20, 0.0f, 0.0f, 0, default(Color), 1f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 0.1f;
				Main.dust[index2].velocity += projectile.velocity * 0.1f;
				Main.dust[index2].position.X -= num1;
				Main.dust[index2].position.Y -= num2;
				Main.dust[index2].color = new Color(255, 255, 255, 0);
			}
			if (Main.rand.Next(5) == 0)
			{
				int num = 4;
				int index = Dust.NewDust(new Vector2(projectile.position.X + (float) num, projectile.position.Y + (float) num), projectile.width - num * 2, projectile.height - num * 2, 20, 0.0f, 0.0f, 0, default(Color), 1f);
				Main.dust[index].velocity *= 0.25f;
				Main.dust[index].velocity += projectile.velocity * 0.5f;
				Main.dust[index].color = new Color(255, 255, 255, 0);
			}
		}
		
		public override bool OnTileCollide(Vector2 velocity1)
		{
			if ((double) projectile.velocity.Y != (double) velocity1.Y || (double) projectile.velocity.X != (double) velocity1.X)
			{
			  if ((double) projectile.velocity.X != (double) velocity1.X)
				projectile.velocity.X = -velocity1.X;
			  if ((double) projectile.velocity.Y != (double) velocity1.Y)
				projectile.velocity.Y = -velocity1.Y;
			}
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 9);
			int p = Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 1000, 0, 20, mod.ProjectileType("LightPillar"), damage/3, knockback, projectile.owner);
			Main.projectile[p].ai[1] = projectile.position.Y;
		}
	}
}