using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class hellorb : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 25;
			projectile.height = 25;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 1;
			projectile.ignoreWater = false;
			projectile.timeLeft = 1000;
			projectile.alpha = 255;
			projectile.extraUpdates = 10;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magma Beam");
		}
		
		public override void AI()
		{
			if (projectile.timeLeft > 995)
				return;
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
			Main.PlaySound(SoundID.Item89, projectile.position);
			projectile.position.X += (float) (projectile.width / 2);
			projectile.position.Y += (float) (projectile.height / 2);
			projectile.width = (int) (100.0 * (double) projectile.scale);
			projectile.height = (int) (100.0 * (double) projectile.scale);
			projectile.position.X -= (float) (projectile.width / 2);
			projectile.position.Y -= (float) (projectile.height / 2);
			for (int index = 0; index < 8; ++index)
			Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
			for (int index1 = 0; index1 < 32; ++index1)
			{
				int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0.0f, 0.0f, 100, new Color(), 2.5f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 3f;
				int index3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0.0f, 0.0f, 100, new Color(), 1.5f);
				Main.dust[index3].velocity *= 2f;
				Main.dust[index3].noGravity = true;
			}
			for (int index1 = 0; index1 < 2; ++index1)
			{
				int index2 = Gore.NewGore(projectile.position + new Vector2((float) (projectile.width * Main.rand.Next(100)) / 100f, (float) (projectile.height * Main.rand.Next(100)) / 100f) - Vector2.One * 10f, new Vector2(), Main.rand.Next(61, 64), 1f);
				Main.gore[index2].velocity *= 0.3f;
				Main.gore[index2].velocity.X += (float) Main.rand.Next(-10, 11) * 0.05f;
				Main.gore[index2].velocity.Y += (float) Main.rand.Next(-10, 11) * 0.05f;
			}
			if (projectile.owner == Main.myPlayer)
			{
				projectile.localAI[1] = -1f;
				projectile.maxPenetrate = 0;
				projectile.Damage();
			}
			
			for (int i = 0; i < 2; i++)
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
			target.immune[projectile.owner] = 5;
		}
	}
}