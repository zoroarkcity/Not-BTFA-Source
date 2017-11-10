using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class SolarAfterimage : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 4;
			projectile.light = 0.5f;
			projectile.tileCollide = false;
			projectile.scale = 1f;
			projectile.alpha = 100;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Solar Ball");
			Main.projFrames[projectile.type] = 4;
		}

		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 3)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			} 
			
			if (Main.rand.Next(6) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(189, 180, false);
		}		
	}
}