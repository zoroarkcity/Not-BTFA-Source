using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.Utilities;

namespace ForgottenMemories.Projectiles
{
	public class BlightedEmber2 : ModProjectile
	{
		//Vector2 Gay;
		Vector2 Gayer;
		bool canMeme = false;
		//float memers = 0;
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 80;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Ember");
		}
		
		public override void AI()
		{
			float num7 = projectile.velocity.ToRotation();
			Gayer = projectile.velocity.RotatedBy(MathHelper.ToRadians(Main.rand.Next(-50, 50)));
			float num8 = num7.AngleLerp(Gayer.ToRotation(), 0.1f);
			projectile.velocity = new Vector2(projectile.velocity.Length(), 0f).RotatedBy((double)num8, default(Vector2));
			
			for (int index1 = 0; index1 < 5; ++index1)
			{
				float num1 = projectile.velocity.X / 3f * (float) index1;
				float num2 = projectile.velocity.Y / 3f * (float) index1;
				int num3 = 4;
				int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, 173, 0.0f, 0.0f, 100, new Color(), 1.4f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 0.1f;
				Main.dust[index2].velocity += projectile.velocity * 0.1f;
				Main.dust[index2].position.X -= num1;
				Main.dust[index2].position.Y -= num2;
			}
			
			if (Main.rand.Next(30) == 0 && projectile.ai[0] != 1)
			{
				//float num872 = (float)Main.rand.Next(-3, 4) * 1.04719758f / 3f;
				Vector2 vector101 = projectile.velocity.RotatedBy(MathHelper.ToRadians(Main.rand.Next(-90, 90)));
				int p = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector101.X, vector101.Y, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, 1f, 0f);
				Main.projectile[p].timeLeft = projectile.timeLeft;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("BlightFlame"), 180, false);
		}
	}
}