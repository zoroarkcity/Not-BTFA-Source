using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class BlightBolt : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 2;
			projectile.height = 2;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.penetrate = 2;
			ProjectileID.Sets.MinionShot[projectile.type] = true;
			projectile.alpha = 255;
			projectile.timeLeft = 360;
			projectile.extraUpdates = 10;
			projectile.light = 0.5f;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 0;
			projectile.scale = 1.2f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Purple Lightning");
		}
		
		public override void AI()
		{
			if(Tools.OneIn(10) && projectile.ai[0] < 10)
			{
				projectile.ai[0] += 2;
			}
			if(Tools.OneIn(10) && projectile.ai[0] > -10)
			{
				projectile.ai[0] -= 2;
			}
			if(Tools.OneIn(10) && projectile.ai[1] < 10)
			{
				projectile.ai[1] += 2;
			}
			if(Tools.OneIn(10) && projectile.ai[1] > -10)
			{
				projectile.ai[1] -= 2;
			}
				
			for (int index1 = 0; index1 < 2; ++index1)
			{
				float num1 = projectile.velocity.X / 3f * (float) index1;
				float num2 = projectile.velocity.Y / 3f * (float) index1;
				int num3 = 4;
				int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, 173, 0.0f, 0.0f, 200, default(Color), 1.2f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 0.1f; 
				Main.dust[index2].velocity += projectile.velocity * 0.1f;
				Main.dust[index2].position.X -= num1;
				Main.dust[index2].position.Y -= num2;
				Main.dust[index2].position += new Vector2(0, projectile.ai[0]).RotatedBy(projectile.velocity.ToRotation());
			}
			for (int index1 = 0; index1 < 2; ++index1)
			{
				float num1 = projectile.velocity.X / 3f * (float) index1;
				float num2 = projectile.velocity.Y / 3f * (float) index1;
				int num3 = 4;
				int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, 173, 0.0f, 0.0f, 200, default(Color), 1.2f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 0.1f; 
				Main.dust[index2].velocity += projectile.velocity * 0.1f;
				Main.dust[index2].position.X -= num1;
				Main.dust[index2].position.Y -= num2;
				Main.dust[index2].position += new Vector2(0, projectile.ai[1]).RotatedBy(projectile.velocity.ToRotation());
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("BlightFlame"), 180, false);
		}
	}
}