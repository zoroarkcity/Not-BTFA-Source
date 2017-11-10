using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.GhastlyEntBoss {
public class MiniSap : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.width = 8;
		projectile.height = 8;
		projectile.aiStyle = 2;
		projectile.penetrate = 5;
		projectile.friendly = false;
		projectile.hostile = true;
		projectile.alpha = 0;
		projectile.timeLeft = 6000;
	}
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corrosive Sap");
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 64);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
	
	public override void AI()
		{
			projectile.ai[0]++;
			if (projectile.ai[0] > 600)
				projectile.alpha += 5;
			
			if (projectile.alpha >= 255)
				projectile.Kill();
		}
	
	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		projectile.velocity *= 0;
		return false;
	}
}}