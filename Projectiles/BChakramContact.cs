using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class BChakramContact : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 5;
			projectile.light = 0.5f;
			projectile.tileCollide = false;
			projectile.scale = 1f;
			projectile.alpha = 155;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Chakram");
		}
		
		public override void AI()
		{
			projectile.alpha += 20;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("BlightFlame"), 180, false);
		}		
	}
}