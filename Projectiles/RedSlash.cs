using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles
{
	public class RedSlash : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 1;
			projectile.penetrate = 5;
			projectile.magic = true;
			projectile.friendly = true;
			projectile.alpha = 20;
			projectile.timeLeft = 120;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodspike");
		}
		
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("UndeadDust"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Main.dust[dust].scale = 1f;
			Main.dust[dust].noGravity = true;		

			if (projectile.timeLeft <= 10)
			{
				projectile.alpha += 25;
			}
		}
		
		
		
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
			{
				Player player = Main.player[projectile.owner];
				player.HealEffect(1);
				player.statLife += 2;
			}
		}
	}
}	