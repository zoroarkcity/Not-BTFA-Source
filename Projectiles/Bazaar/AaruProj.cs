using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Bazaar
{
	public class AaruProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 12f;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 250f;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 12f;
		}

		public override void SetDefaults()
		{
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
		}
		
		public override void AI()
		{
			for (int index1 = 0; index1 < 3; ++index1)
			{
				float num1 = projectile.velocity.X / 3f * (int)index1;
				float num2 = projectile.velocity.Y / 3f * (int)index1;
				int num3 = 4;
				int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, 6, 0.0f, 0.0f, 0, default(Color), 1f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 0.1f;
				Main.dust[index2].scale *= 2;
				Main.dust[index2].velocity += projectile.velocity * 0.1f;
				Main.dust[index2].position.X -= num1;
				Main.dust[index2].position.Y -= num2;
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire,	120);
			
			int amountOfProjectiles = Main.rand.Next(3) + 1;
			
			for (int i = 0; i < amountOfProjectiles; ++i)
			{
				Vector2 newVect1 = new Vector2 (8, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(360)));
				int proj = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect1.X, newVect1.Y, 249, 10, 5f, projectile.owner);
				Main.projectile[proj].ranged = false;
				Main.projectile[proj].melee = true;
			}
		}
	}
}
