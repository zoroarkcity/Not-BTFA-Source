using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class TitanSpinP : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 12;
			projectile.height = 12;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 70;
			projectile.light = 0.5f;
			projectile.tileCollide = false;
			projectile.scale = 1f;
			projectile.alpha = 100;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Afterimage");
		}
		
		public override void AI()
		{
			projectile.alpha += 3;
		}
	}
}