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

		/*public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 3; i++)
			{
				float SpeedX = projectile.velocity.X * Main.rand.Next(20, 51) * 0.005f + Main.rand.Next(-20, 21) * 0.4f;
				float SpeedY = -Math.Abs(projectile.velocity.Y) * Main.rand.Next(30, 51) * 0.01f + Main.rand.Next(-20, 21) * 0.4f;
				int p = Projectile.NewProjectile(projectile.Center.X + SpeedX, projectile.Center.Y + SpeedY, SpeedX, SpeedY, mod.ProjectileType("BoilingBlood"), projectile.damage / 2, projectile.knockBack / 4, projectile.owner);
				Main.projectile[p].scale = 0.75f + (float) Main.rand.Next(51) / 100;
			}
		}*/
	}
}	