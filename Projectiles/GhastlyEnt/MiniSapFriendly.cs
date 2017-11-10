using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.GhastlyEnt {
public class MiniSapFriendly : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.width = 10;
		projectile.height = 10;
		projectile.aiStyle = 2;
		projectile.penetrate = 5;
		projectile.friendly = true;
		projectile.hostile = false;
		projectile.melee = true;
		projectile.alpha = 0;
		projectile.timeLeft = 100;
	}
	
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corrosive Sap");
		}
	
			public override void AI()
	{
		if (Main.rand.Next(3) == 0)
		{
			Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 64, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
		}
	}
	
	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		projectile.velocity *= 0;
		projectile.aiStyle = 0;
		return false;
	}
}}