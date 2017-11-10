using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles {
	public class solarboom : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 25;
			projectile.height = 25;
			projectile.scale = 2f;
			projectile.aiStyle = -1;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.friendly = true;
			projectile.timeLeft = 10;
			projectile.extraUpdates = 1;
			projectile.tileCollide = false;
			projectile.light = 0.5f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Solar Detonator");
			Main.projFrames[projectile.type] = 5;
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
		}
		
		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 2)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 5;
			} 
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(189, 180, false);
		}
	}
}	