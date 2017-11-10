using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class BlightBeam : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 4;
			projectile.height = 4;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 3;
			//projectile.timeLeft = 60;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10;
			projectile.extraUpdates = 10;
			projectile.alpha = 255;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Fire");
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("BlightFlame"), 180, false);
		}

		public override void AI()
		{
			if ((double) projectile.localAI[0] == 0.0)
			{
			  projectile.localAI[0] = 1f;
			  Main.PlaySound(SoundID.Item17, projectile.position);
			}
			
			
			if ((double) projectile.ai[0] > 3.0)
			{
				for (int index1 = 0; index1 < 1; ++index1)
				{
					for (int index2 = 0; index2 < 3; ++index2)
					{
						float num1 = (float) (projectile.velocity.X / 3.0) * (float) index2;
						float num2 = (float) (projectile.velocity.Y / 3.0) * (float) index2;
						int num3 = 6;
						int index3 = Dust.NewDust(new Vector2((float) projectile.position.X + (float) num3, (float) projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, 173, 0.0f, 0.0f, 100, new Color(), 1.2f);
						Main.dust[index3].noGravity = true;
						Dust dust1 = Main.dust[index3];
						dust1.velocity *= 0.3f;
						Dust dust2 = Main.dust[index3];
						dust2.velocity = (dust2.velocity + (projectile.velocity * 0.5f));
						Main.dust[index3].position.X -= num1;
						Main.dust[index3].position.Y -= num2;
					}
					if (Main.rand.Next(8) == 0)
					{
						int num = 6;
						int index2 = Dust.NewDust(new Vector2((float) projectile.position.X + (float) num, (float) projectile.position.Y + (float) num), projectile.width - num * 2, projectile.height - num * 2, 173, 0.0f, 0.0f, 100, new Color(), 0.75f);
						Dust dust1 = Main.dust[index2];
						dust1.velocity = (dust1.velocity * 0.5f);
						Dust dust2 = Main.dust[index2];
						dust2.velocity = (dust2.velocity + (projectile.velocity * 0.5f));
					}
				}
			}
			else
			{
				projectile.ai[0]++;
			}
		}
	}
}