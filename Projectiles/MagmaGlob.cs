using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class MagmaGlob : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 1;
			projectile.ignoreWater = false;
			projectile.timeLeft = 1000;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magma Glob");
		}
		
		public override void AI()
		{
			for (int index1 = 0; index1 < 7; ++index1)
			{
				float num1 = projectile.velocity.X / 3f * (int)index1;
				float num2 = projectile.velocity.Y / 3f * (int)index1;
				int num3 = 4;
				int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, 6, 0.0f, 0.0f, 0, default(Color), 1f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 0.1f;
				Main.dust[index2].scale *= 2;
				Main.dust[index2].velocity += projectile.velocity * 0.1f;
				Main.dust[index2].position.X -= num1;
				Main.dust[index2].position.Y -= num2;
			}
			if (Main.rand.Next(5) == 0)
			{
				int num = 4;
				int index = Dust.NewDust(new Vector2(projectile.position.X + (float) num, projectile.position.Y + (float) num), projectile.width - num * 2, projectile.height - num * 2, 6, 0.0f, 0.0f, 0, default(Color), 1f);
				Main.dust[index].velocity *= 0.25f;
				Main.dust[index].velocity += projectile.velocity * 0.5f;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 3; i++)
			{
				Vector2 vector2 = new Vector2(4, 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(360)));
				int kek = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, vector2.X, vector2.Y, ProjectileID.MolotovFire, (int)(projectile.damage/2), 5f, projectile.owner);
				Main.projectile[kek].thrown = false;
				Main.projectile[kek].magic = true;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 420, false);
		}
	}
}