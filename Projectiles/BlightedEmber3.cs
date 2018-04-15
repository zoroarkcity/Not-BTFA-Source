using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class BlightedEmber3 : ModProjectile
	{
		Vector2 Gay = new Vector2 (0f, 0f);
		Vector2 Gayer = new Vector2 (0f, 0f);
		bool canMeme = false;
		float memers = 0;
		public override void SetDefaults()
		{
			projectile.width = 2;
			projectile.height = 2;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 90;
			projectile.alpha = 255;
			projectile.extraUpdates = 100;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Ember");
		}
		
		public override void AI()
		{
			if (memers == 0)
			{
				canMeme = true;
				Gay = new Vector2 (projectile.velocity.X, projectile.velocity.Y);
			}
			
			if (canMeme == true)
			{
				memers -= 0.5f;
				Gayer = Gay.RotatedBy(-1.2*(Math.Sin(memers)));
				projectile.velocity = Gayer;
			}
			
			for (int index1 = 0; index1 < 4; ++index1)
		    {
				Vector2 Position = projectile.position - ((projectile.velocity * (float) index1) * 0.25f);
				projectile.alpha = (int) byte.MaxValue;
				int index2 = Dust.NewDust(Position, 1, 1, 65, 0.0f, 0.0f, 0, new Color(), 1f);
				Main.dust[index2].position = Position;
				Main.dust[index2].position.X += (float) (projectile.width / 2);
				Main.dust[index2].position.Y += (float) (projectile.height / 2);
				Main.dust[index2].alpha = 0;
				Main.dust[index2].scale = (float) Main.rand.Next(70, 110) * 0.013f;
				Main.dust[index2].velocity = -Gayer * (((float)index1)* 0.25f);
				Main.dust[index2].noGravity = true;
		    }
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("BlightFlame"), 180, false);
		}
	}
}