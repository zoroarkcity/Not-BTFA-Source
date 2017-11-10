using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace ForgottenMemories.Projectiles
{
	public class FlameBolt : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 1;
			ProjectileID.Sets.MinionShot[projectile.type] = true;
			projectile.alpha = 255;
			projectile.timeLeft = 360;
			projectile.extraUpdates = 4;
			projectile.light = 0.5f;
			projectile.scale = 1.2f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flame Bolt");
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 360, false);
			
			target.AddBuff(mod.BuffType("DevilsFlame"), 360, false);
		}
		
		public override void AI()
		{
			for (int index = 0; index < 4; ++index)
			{
				if (Main.rand.Next(2) != 0)
				{
					Dust dust1 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6, (float) (projectile.velocity.X * 0.200000002980232), (float) (projectile.velocity.Y * 0.200000002980232), 100, new Color(), 2f);
					dust1.noGravity = true;
					Dust dust2 = dust1;
					Vector2 vector2 = (dust2.velocity * 0.3f);
					dust2.velocity = vector2;
					{
						float num2 = (float) dust1.velocity.Y + Math.Sign((float) dust1.velocity.Y) * 1.20000004768372f;
						dust1.velocity.Y = num2;
						dust1.fadeIn += 0.5f;
					}
				}
			}
			
			if (Main.rand.Next(60) == 0)
			{
			  int index2 = Gore.NewGore(projectile.position + new Vector2((float) (projectile.width * Main.rand.Next(100)) / 100f, (float) (projectile.height * Main.rand.Next(100)) / 100f) - Vector2.One * 10f, new Vector2(), Main.rand.Next(61, 64), 1f);
			  Main.gore[index2].velocity *= 0.3f;
			  Main.gore[index2].velocity.X += (float) Main.rand.Next(-10, 11) * 0.05f;
			  Main.gore[index2].velocity.Y += (float) Main.rand.Next(-10, 11) * 0.05f;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item89, projectile.position);
			projectile.position.X += (float) (projectile.width / 2);
			projectile.position.Y += (float) (projectile.height / 2);
			projectile.width = (int) (90.0 * (double) projectile.scale);
			projectile.height = (int) (90.0 * (double) projectile.scale);
			projectile.position.X -= (float) (projectile.width / 2);
			projectile.position.Y -= (float) (projectile.height / 2);
			for (int index = 0; index < 8; ++index)
			  Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 127, 0.0f, 0.0f, 100, new Color(), 1.5f);
			for (int index1 = 0; index1 < 48; ++index1)
			{
			  int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 127, 0.0f, 0.0f, 100, new Color(), 3.5f);
			  Main.dust[index2].noGravity = true;
			  Main.dust[index2].velocity *= 3f;
			  int index3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 127, 0.0f, 0.0f, 100, new Color(), 1.5f);
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
		}
	}
}