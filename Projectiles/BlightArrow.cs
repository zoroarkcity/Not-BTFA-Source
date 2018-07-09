using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles
{
	public class BlightArrow : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.arrow = true;
			projectile.extraUpdates = 1;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Arrow");
		}

		public override void AI()
		{
			for (int i = 0; i < 2; i++)
			{
				int dust = Dust.NewDust(projectile.Center, 0, 0, 173, 0f, 0f); 
				Main.dust[dust].scale = 1.2f;
				Main.dust[dust].noGravity = true;
			}
		}

		public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("BlightFlame"), 360);

			if (crit)
			{
				Vector2 Source = Main.player[projectile.owner].Center;
				Vector2 offset = new Vector2(Main.rand.Next(100, 151), 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(360)));
				Source += offset;
				int p = Projectile.NewProjectile(Source.X,  Source.Y, 0, 0, mod.ProjectileType("BlightBoomRange"), projectile.damage / 3, 4f, projectile.owner, target.Center.X, target.Center.Y);
				Main.projectile[p].scale = 0.5f;
				Main.projectile[p].timeLeft += 5;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y); //create a sound
			
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173);
				int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity = projectile.velocity.RotatedByRandom(MathHelper.Pi / 8);
				
			}
		}
	}
}	