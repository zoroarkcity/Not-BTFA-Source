using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Bazaar
{
	public class ElysianProj : ModProjectile
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
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			int amountOfProjectiles = Main.rand.Next(1, 4);
			
			for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-60, 61) * 0.1f;
					float sY = (float)Main.rand.Next(-60, 61) * 0.1f;
					int z = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, 228, projectile.damage, 5f, projectile.owner);
				}
				target.AddBuff(BuffID.Poisoned,	120);
		}
	}
}
