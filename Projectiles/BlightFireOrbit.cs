using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class BlightFireOrbit : ModProjectile
	{
		Vector2 Gay = new Vector2 (0f, 0f);
		Vector2 Gayer = new Vector2 (0f, 0f);
		bool canMeme = false;
		float memers = 0;
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 26;
			projectile.friendly = true;
			projectile.tileCollide = false;
			Main.projFrames[projectile.type] = 4;
			projectile.light = 0.5f;
			projectile.penetrate = -1;
			projectile.timeLeft = 2;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Ember");
		}
		
		public override void AI()
		{
			if (canMeme == false)
			{
				canMeme = true;
				Gay = projectile.Center - Main.player[projectile.owner].Center;
			}
			
			if (canMeme == true && Main.player[projectile.owner].ownedProjectileCounts[mod.ProjectileType("BlightFireOrbit")] == 12)
			{
				//Vector2 Gayer = Gay.RotatedBy(MathHelper.Pi/150);
				//Gay = Gayer;
				projectile.position.X = Main.player[projectile.owner].Center.X + Gay.X;
				projectile.position.Y = Main.player[projectile.owner].Center.Y + Gay.Y;
			}
			
			projectile.frameCounter++;
			if (projectile.frameCounter >= 3)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			}
			
			if (Main.player[projectile.owner].dead)
			{
				projectile.Kill();
			}
			
			if (((BTFAPlayer)Main.player[projectile.owner].GetModPlayer(mod, "BTFAPlayer")).BlightFlameRing == true)
			{
				projectile.timeLeft = 2;
			}
			
			//int dust;
			//dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 65, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			//Main.dust[dust].scale = 1.2f;
			//Main.dust[dust].noGravity = true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("BlightFlame"), 580, false);
		}
	}
}