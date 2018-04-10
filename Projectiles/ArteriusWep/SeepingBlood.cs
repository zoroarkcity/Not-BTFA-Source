using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles.ArteriusWep
{
	public class SeepingBlood : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 10;
			projectile.penetrate = -1;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.timeLeft = 180;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Seeping Blood");
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
				Main.dust[index2].velocity *= 0.1f;
				Main.dust[index2].velocity += projectile.velocity * 0.1f;
				Main.dust[index2].position.X -= num1;
				Main.dust[index2].position.Y -= num2;
				Main.dust[index2].scale = projectile.scale;
			}
			if (Main.rand.Next(2) == 0)
			{
				int num = 4;
				int index = Dust.NewDust(new Vector2(projectile.position.X + (float) num, projectile.position.Y + (float) num), projectile.width - num * 2, projectile.height - num * 2, 60, 0.0f, 0.0f, 0, default(Color), 1f);
				Main.dust[index].velocity *= 0.25f;
				Main.dust[index].velocity += projectile.velocity * 0.5f;
				Main.dust[index].noGravity = true;
				Main.dust[index].scale = projectile.scale / 2f;
			}
		}

		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			crit = false;
			int defense = target.defense;

			if (target.ichor)
				defense -= 20;
			if (target.betsysCurse)
				defense -= 40;

			//armor penetration accounting code here? whatever, fuck it

			if (defense > 0)
				damage += defense / 2;
		}

		/*public override bool? CanHitNPC (NPC target)
		{
			if (target.whoAmI == projectile.ai[0])
				return false;

			return null;
		}*/
	}
}	