using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class WrathArrow : ModProjectile
    {
		int timer = 0;
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
            projectile.extraUpdates = 1;
            projectile.alpha = 0;
			projectile.tileCollide = true;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wrath Arrow");
		}
		
		
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			Vector2 vector2 = projectile.Center + Vector2.Normalize(projectile.velocity) * 10f;
			Dust dust1 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, 0.0f, 0.0f, 0, new Color(), 1f)];
			dust1.position = vector2;
			dust1.velocity = projectile.velocity.RotatedBy(1.57079637050629, new Vector2()) * 0.33f + projectile.velocity / 6f;
			dust1.position += projectile.velocity.RotatedBy(1.57079637050629, new Vector2()) * 0.33f;
			dust1.fadeIn = 0.5f;
			dust1.noGravity = true;
			Dust dust2 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, 0.0f, 0.0f, 0, new Color(), 1f)];
			dust2.position = vector2;
			dust2.velocity = projectile.velocity.RotatedBy(-1.57079637050629, new Vector2()) * 0.33f + projectile.velocity / 6f;
			dust2.position += projectile.velocity.RotatedBy(-1.57079637050629, new Vector2()) * 0.33f;
			dust2.fadeIn = 0.5f;
			dust2.noGravity = true;
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item89, projectile.position);
			projectile.position.X += (float) (projectile.width / 4);
			projectile.position.Y += (float) (projectile.height / 4);
			projectile.width = (int) (64.0 * (double) projectile.scale);
			projectile.height = (int) (64.0 * (double) projectile.scale);
			projectile.position.X -= (float) (projectile.width / 4);
			projectile.position.Y -= (float) (projectile.height / 4);
			for (int index1 = 0; index1 < 16; ++index1)
			{
			  int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 173, 0.0f, 0.0f, 100, new Color(), 2.5f);
			  Main.dust[index2].noGravity = true;
			  Main.dust[index2].velocity *= 3f;
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
				65,
				173,
				21
			  }), 2.5f * (float) projectile.direction, -2.5f, 0, new Color(), 1f);
			  Main.dust[index2].alpha = 200;
			  Main.dust[index2].velocity *= 2.4f;
			  Main.dust[index2].scale += Main.rand.NextFloat();
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			target.immune[projectile.owner] = 5;
			target.AddBuff(mod.BuffType("BlightFlame"), 180, false);
		}
    }
}