using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class BlightedWave : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 40;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.timeLeft = 30;
			Main.projFrames[projectile.type] = 4;
			projectile.alpha = 255;
			projectile.light = 0.5f;
			aiType = ProjectileID.Bullet;
			projectile.tileCollide = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Wave");
		}
		
		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 5)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			} 
			projectile.alpha = projectile.alpha - 40;
			if (projectile.alpha < 0)
				projectile.alpha = 0;
			
			++projectile.localAI[0];
			if (Main.rand.Next(3) == 0)
			{
				for (int index = 0; index < 1; ++index)
				{ //copypasted from vanilla
					double rotate = projectile.velocity.ToRotation();
					Vector2 vector2_1 = Utils.RandomVector2(Main.rand, -0.5f, 0.5f) * new Vector2(5f, 20f).RotatedBy(rotate);
					Dust dust = Dust.NewDustDirect(projectile.Center, 0, 0, 173, projectile.velocity.X, projectile.velocity.Y, 0, new Color(170, 66, 244), 1f);
					int maxValue = (int) sbyte.MaxValue;
					dust.alpha = maxValue;
					double num1 = 1.5;
					dust.fadeIn = (float) num1;
					double num2 = 1.3;
					dust.scale = (float) num2;
					Vector2 vector2_2 = dust.velocity * 0.7f;
					dust.velocity = vector2_2;
					Vector2 vector2_3 = projectile.Center + vector2_1;
					dust.position = vector2_3;
					int num3 = 1;
					dust.noGravity = num3 != 0;
					int num4 = 1;
					dust.noLight = num4 != 0;
					Color color = new Color(255, 0, 255);
					dust.color = color;
				}
			}
			Lighting.AddLight(projectile.Center, 1.1f, 0.3f, 0.4f);
		}
		
		public override void Kill(int timeLeft)
		{
			int num = Main.rand.Next(15, 25);
			for (int index1 = 0; index1 < num; ++index1)
			{
				int index2 = Dust.NewDust(projectile.Center, 0, 0, 173, 0.0f, 0.0f, 100, new Color(170, 66, 244), 1.3f);
				Dust dust1 = Main.dust[index2];
				dust1.velocity = dust1.velocity * (float) (3.0 * (0.3 + 0.7 * (double) Main.rand.NextFloat()));
				Main.dust[index2].fadeIn = (float) (1.3 + (double) Main.rand.NextFloat() * 0.2);
				Main.dust[index2].noLight = true;
				Main.dust[index2].noGravity = true;
				Dust dust2 = Main.dust[index2];
				dust2.position = dust2.position + Main.dust[index2].velocity * 4f;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("BlightMark"), 240);
		}
	}
}