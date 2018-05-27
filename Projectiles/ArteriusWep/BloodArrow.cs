using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles.ArteriusWep
{
	public class BloodArrow : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.arrow = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood Arrow");
		}

		public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Hematohidrosis"), 180);
		}

		public override void AI()
		{
			Lighting.AddLight(projectile.position, 0.5f, 0, 0);
			
			for (int i = 0; i < 2; i++)
			{
				int dust = Dust.NewDust(projectile.Center, 0, 0, 117, 0f, 0f); 
				Main.dust[dust].scale = 1f;
				Main.dust[dust].noGravity = true;
			}
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y); //create a sound
		}
	}
}	