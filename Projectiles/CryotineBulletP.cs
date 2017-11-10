using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class CryotineBulletP : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 2;
			projectile.height = 10;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 600;
			projectile.light = 0.5f;
			projectile.extraUpdates = 1;
			aiType = ProjectileID.Bullet;
			projectile.tileCollide = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cryotine Bullet");
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 67);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}	
		}
		
		public override void AI()
		{
			if (Main.rand.Next(3) == 0)
			{
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 135, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].scale = 0.7f;
			Main.dust[dust].noGravity = true;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			target.AddBuff(BuffID.Frostburn, 1800, false);
		}
		
	}
}