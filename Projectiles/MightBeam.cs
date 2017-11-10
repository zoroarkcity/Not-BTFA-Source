using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class MightBeam : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 27;
			projectile.melee = true;
			projectile.penetrate = 1;
			projectile.light = 0.5f;
			projectile.alpha = (int) byte.MaxValue;
			projectile.friendly = true;
			projectile.timeLeft = 120;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Might Beam");
		}
		
		public override void AI()
		{
			int index = Dust.NewDust(new Vector2((float) projectile.position.X, (float) (projectile.position.Y + 4.0)), 8, 8, 88, (float) projectile.oldVelocity.X, (float) projectile.oldVelocity.Y, 100, new Color(), 0.6f);
            Dust dust = Main.dust[index];
            dust.velocity = (dust.velocity * -0.25f);
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item89, projectile.position);
			projectile.position.X += (float) (projectile.width / 2);
			projectile.position.Y += (float) (projectile.height / 2);
			projectile.width = (int) (150.0 * (double) projectile.scale);
			projectile.height = (int) (150.0 * (double) projectile.scale);
			projectile.position.X -= (float) (projectile.width / 2);
			projectile.position.Y -= (float) (projectile.height / 2);
			for (int index = 0; index < 8; ++index)
			  Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
			for (int index1 = 0; index1 < 32; ++index1)
			{
			  int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 88, 0.0f, 0.0f, 100, new Color(), 2.5f);
			  Main.dust[index2].noGravity = true;
			  Main.dust[index2].velocity *= 3f;
			  int index3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 88, 0.0f, 0.0f, 100, new Color(), 1.5f);
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
			for (int index1 = 0; index1 < 5; ++index1)
			{
			  int index2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, Utils.SelectRandom<int>(Main.rand, new int[3]
			  {
				15,
				88,
				59
			  }), 2.5f * (float) projectile.direction, -2.5f, 0, new Color(), 1f);
			  Main.dust[index2].alpha = 200;
			  Main.dust[index2].velocity *= 2.4f;
			  Main.dust[index2].scale += Main.rand.NextFloat();
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			target.immune[projectile.owner] = 5;
		}
	}
}