using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class BlightLaserOrbit : ModProjectile
	{
		Vector2 Gay = new Vector2 (150, 0);
		Vector2 Gayer = new Vector2 (0, 0);
		bool canMeme = false;
		float memers = 0;
		public override void SetDefaults()
		{
			projectile.width = 1;
			projectile.height = 1;
			projectile.friendly = true;
			projectile.tileCollide = false;
			Main.projFrames[projectile.type] = 4;
			projectile.extraUpdates = 100;
			projectile.alpha = 255;
			projectile.light = 0.5f;
			projectile.penetrate = 12;
			projectile.timeLeft = 2;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Fire");
		}
		
		public override void AI()
		{
			Vector2 Gayer = Gay.RotatedBy(MathHelper.Pi/150);
			Gay = Gayer;
			projectile.position.X = Main.player[projectile.owner].Center.X + Gay.X;
			projectile.position.Y = Main.player[projectile.owner].Center.Y + Gay.Y;
			
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
			//dust = Dust.NewDust(projectile.position, projectile.width/2, projectile.height/2, 65, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			//Main.dust[dust].scale = 0.9f;
			//Main.dust[dust].noGravity = true;
			int dust2;
			dust2 = Dust.NewDust(projectile.position, 0, 0, 173, 0, 0);
			Main.dust[dust2].scale = 0.8f;
			Main.dust[dust2].noGravity = true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("BlightFlame"), 580, false);
		}
	}
}