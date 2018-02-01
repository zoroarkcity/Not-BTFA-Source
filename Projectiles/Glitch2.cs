using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class Glitch2 : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 200;
			projectile.alpha = 255;
			projectile.tileCollide = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glitch");
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, Main.rand.Next(3, 200), 0f, 0f);
			Main.dust[dust].scale = 2f;
			Main.dust[dust].noGravity = true;
			if (Main.rand.Next(5) == 0)
			{
				Vector2 newVect = projectile.velocity.RotatedBy(System.Math.PI / 10);
				projectile.velocity = newVect;
			}	
			if (Main.rand.Next(5) == 0)
			{
				Vector2 newVect2 = projectile.velocity.RotatedBy(System.Math.PI / -10);
				projectile.velocity = newVect2;
			}			
			if (Main.rand.Next(10) == 0)
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("glitchboom"), 50, 5f, projectile.owner);
			}
			if (Main.rand.Next(40) == 0) {
				NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y- 200, Main.rand.Next(1, 579));
				
			}
			Player player = Main.player[projectile.owner];
			if (Main.rand.Next(400) == 0){
			player.GetModPlayer<BTFAPlayer>(mod).isGlitch = true;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("glitchboom"), 50, 5f, projectile.owner);
				target.aiStyle = Main.rand.Next(3, 32);
				
				if(Main.rand.Next(10) == 0) {
					target.velocity.X *= 10;
					target.velocity.Y *= 10;
					
				}
				if (Main.rand.Next(20) == 0)
			{
				target.noGravity = true;
			}
			if (Main.rand.Next(5) == 0)
			{
				target.noGravity = false;
			}
			if (Main.rand.Next(20) == 0)
			{
				target.noTileCollide = true;
			}
			if (Main.rand.Next(5) == 0)
			{
				target.noTileCollide = false;
			}
				target.dripping = true;
				target.drippingSlime = true;
		}
	}
}
