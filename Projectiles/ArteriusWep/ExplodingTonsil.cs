using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles.ArteriusWep
{
	public class ExplodingTonsil : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 15;
			projectile.height = 15;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			Main.projFrames[projectile.type] = 4;
			projectile.ranged = true;
			projectile.penetrate = -1;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Exploding Tonsil");
		}

		public override void Kill(int timeLeft)
		{
			//change this sound effect
			Main.PlaySound(SoundID.Item14, projectile.position);

			projectile.position.X += projectile.width / 2;
			projectile.position.Y += projectile.height / 2;

			projectile.width = (int) (100f * projectile.scale);
			projectile.height = (int) (100f * projectile.scale);

			projectile.position.X -= projectile.width / 2;
			projectile.position.Y -= projectile.height / 2;

			for(int i = 0; i < 44; i++) //dust shit. looks like garbage, pls spray dust juice on
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("BloodDust2"), 0, 0, 0, default(Color), 4.4f);
					
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity *= 6.4f;
				Main.dust[dust].noLight = true;

				int rng = Main.rand.Next(3);

				if (rng == 0)
				{
					Main.dust[dust].velocity *= 1.5f;
					Main.dust[dust].scale *= 0.7f;
				}
				else if (rng == 1)
				{
					Main.dust[dust].velocity *= 1.2f;
					Main.dust[dust].scale *= 0.9f;
				}
			}
			
			if (projectile.owner == Main.myPlayer)
			{
				projectile.localAI[1] = -1f; //literally why
				projectile.Damage();
			}
		}

		public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
		{
			if (projectile.timeLeft > 1)
				projectile.timeLeft = 1;
		}
	}
}	