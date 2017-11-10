using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class wooboomfriendly : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 70;
			projectile.height = 70;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 12;
			projectile.light = 0.5f;
			projectile.tileCollide = false;
			Main.projFrames[projectile.type] = 6;
			projectile.scale = 1.25f;
			projectile.thrown = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blossom Explosion");
		}
		
		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 2)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 6;
			} 
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 12;
		}
	}
}