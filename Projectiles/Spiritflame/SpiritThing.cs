using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles.Spiritflame
{
	public class SpiritThing : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 180;
			projectile.height = 180;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 10;
			projectile.alpha = 255;
			projectile.tileCollide = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spirit Magic");
		}
		
		public override void AI()
		{
			float num = 40f;
			for (int index1 = 0; (double) index1 < (double) num; ++index1)
			{
				Vector2 v = (Vector2.UnitX * 0.0f + -Vector2.UnitY.RotatedBy((double) index1 * (6.28318548202515 / (double) num), new Vector2()) * new Vector2(1f, 4f));
				int index2 = Dust.NewDust(projectile.Center, 0, 0, 160, 0.0f, 0.0f, 0, new Color(), 1f);
				Main.dust[index2].scale = 1.5f;
				Main.dust[index2].fadeIn = 1.3f;
				Main.dust[index2].noGravity = true;
				Main.dust[index2].position = projectile.Center + v*18f;
				Main.dust[index2].velocity = projectile.velocity * 0.0f + v.SafeNormalize(Vector2.UnitY) * 3f;
			}
			
			for (int index3 = 0; (double) index3 < (double) num; ++index3)
			{
				Vector2 v = (Vector2.UnitX * 0.0f + -Vector2.UnitY.RotatedBy((double) index3 * (6.28318548202515 / (double) num), new Vector2()) * new Vector2(4f, 1f));
				int index2 = Dust.NewDust(projectile.Center, 0, 0, 160, 0.0f, 0.0f, 0, new Color(), 1f);
				Main.dust[index2].scale = 1.5f;
				Main.dust[index2].fadeIn = 1.3f;
				Main.dust[index2].noGravity = true;
				Main.dust[index2].position = projectile.Center + v*18f;
				Main.dust[index2].velocity = projectile.velocity * 0.0f + v.SafeNormalize(Vector2.UnitX) * 3f;
			}
			
			int amountOfDust = 24;
			for (int i = 0; i < amountOfDust; ++i)
			{
				int dust;
				Vector2 newVect = new Vector2 (0.5f, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(45 * i)));
				Vector2 vector2 = newVect * 144;
				dust = Dust.NewDust(projectile.Center + vector2, 0, 0, 160, newVect.X, newVect.Y);
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			target.AddBuff(mod.BuffType("Spiritflame"), 180, false);
		}
	}
}