using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class TheComet : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Chik);
			projectile.aiStyle = 99;
			projectile.width = 16;
			projectile.height = 16;
			projectile.penetrate = -1;
			projectile.extraUpdates = 1;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Comet");
			aiType = 555;
		}

		public override void AI()
		{
			if (projectile.velocity != new Vector2 (0f, 0f))
			{
				for (int index1 = 0; index1 < 1; ++index1)
				{
				  int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, 0.0f, 0.0f, 0, new Color(), 1f);
				  Main.dust[index2].velocity *= 0.5f;
				  Main.dust[index2].scale *= 1.3f;
				  Main.dust[index2].fadeIn = 1f;
				  Main.dust[index2].noGravity = true;
				}
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("CosmosBoom"), projectile.damage, 0f, projectile.owner, 0, 0);
			target.AddBuff(mod.BuffType("CosmicCurse"), 180, false);
		}
	}
}