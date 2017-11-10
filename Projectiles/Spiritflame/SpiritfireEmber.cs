using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles.Spiritflame
{
	public class SpiritfireEmber : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 16;
			projectile.aiStyle = 14;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 360;
			projectile.alpha = 255;
			//projectile.extraUpdates = 1;
			projectile.noEnchantments = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spiritflame Ember");
		}
		
		public override bool OnTileCollide (Vector2 velocity1)
		{
			return false;
		}
		
		public override void AI()
		{
			if ((double) projectile.ai[1] == 0.0)
			{
				projectile.ai[1] = 1f;
				Main.PlaySound(SoundID.Item13, projectile.position);
			}
			int index1 = Dust.NewDust(projectile.position, projectile.width / 2, projectile.height / 2, 160, 0.0f, 0.0f, 100, new Color(), 1f);
			Main.dust[index1].position.X -= 2f;
			Main.dust[index1].position.Y += 2f;
			Dust dust1 = Main.dust[index1];
			dust1.scale = dust1.scale + (float) Main.rand.Next(50) * 0.01f;
			Main.dust[index1].noGravity = true;
			Main.dust[index1].velocity.Y -= 8f;
			if (Main.rand.Next(2) == 0)
			{
				int index2 = Dust.NewDust(projectile.position, projectile.width / 2, projectile.height / 2, 160, 0.0f, 0.0f, 100, new Color(), 1f);
				Main.dust[index2].position.X -= 2f;
				Main.dust[index2].position.Y += 2f;
				Dust dust2 = Main.dust[index2];
				dust2.scale = dust2.scale + (float) (0.300000011920929 + (double) Main.rand.Next(50) * 0.00999999977648258);
				Main.dust[index2].noGravity = true;
				Dust dust3 = Main.dust[index2];
				dust3.velocity.Y *= 0.8f;
			}
			if ((double) projectile.velocity.Y < 0.25 && (double) projectile.velocity.Y > 0.15)
			{
				projectile.velocity.X *= 0.8f;
			}
			projectile.rotation = (float) (-projectile.velocity.X * 0.0500000007450581);
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Spiritflame"), 180, false);
		}
	}
}