using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles 
{
	public class LeechingArrow : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.penetrate = 1;
			projectile.ranged = true;
			projectile.friendly = true;
			projectile.alpha = 0;
			projectile.aiStyle = 1;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leeching Arrow");
		}
		
		   public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("UndeadDust"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].scale = 0.9f;
			Main.dust[dust].noGravity = true;				
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("UndeadDust"));
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}
	}	
}