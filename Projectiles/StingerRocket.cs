using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class StingerRocket : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.alpha = 0;
			projectile.ranged = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stinger Rocket");
			aiType = ProjectileID.Bullet;
		}
		
		public override void AI()
		{
			if (Main.rand.Next(5) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.Center, projectile.width, projectile.height, 39, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("StingerBoom"), projectile.damage, 0f, projectile.owner, 0f, 0f);
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 34);
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(20, 360, false);
			target.immune[projectile.owner] = 5;
		}	
	}
}