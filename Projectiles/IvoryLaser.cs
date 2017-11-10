using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class IvoryLaser : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 4;
			projectile.height = 4;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 20;
			projectile.extraUpdates = 100;
			projectile.alpha = 255;
			projectile.tileCollide = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ivory Laser");
		}
		
		public override void AI()
		{
			for (int i = 0; i <= 4; i++)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 63, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity = -(projectile.velocity * (float)(0.20 * i/2));
				Main.dust[dust].scale = Main.rand.Next(75, 100) * 0.01f;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			target.immune[projectile.owner] = 0;
		}
	}
}