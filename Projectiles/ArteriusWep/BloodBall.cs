using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles.ArteriusWep
{
	public class BloodBall : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.hide = true; //update sprite and then remove this line
			projectile.penetrate = -1;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("BloodBall");
		}

		public override void AI()
		{
			//dust borrowed from spinal bolt, please update!!
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
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item21, projectile.position);

			projectile.position.X += projectile.width / 2;
			projectile.position.Y += projectile.height / 2;

			float modifier = 120f;
			if (projectile.ai[0] == 1f)
				modifier *= 2f;
			
			projectile.width = (int) (modifier * projectile.scale);
			projectile.height = (int) (modifier * projectile.scale);

			projectile.position.X -= projectile.width / 2;
			projectile.position.Y -= projectile.height / 2;

			for (int index = 0; index < 8; ++index)
				Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("BloodDust2"), 0.0f, 0.0f, 0, new Color(), 2f);

			for (int index1 = 0; index1 < 32; ++index1)
			{
				int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("BloodDust2"), 0.0f, 0.0f, 0, new Color(), 3f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 3f;
				int index3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("BloodDust2"), 0.0f, 0.0f, 0, new Color(), 2f);
				Main.dust[index3].velocity *= 2f;
				Main.dust[index3].noGravity = true;
			}
			
			if (projectile.owner == Main.myPlayer)
			{
				projectile.localAI[1] = -1f;
				projectile.Damage();
			}
		}

		public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
		{
			if (projectile.timeLeft > 1)
				projectile.timeLeft = 1;

			target.AddBuff(mod.BuffType("BoilingBlood"), 240);
		}
	}
}	