using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class DreadBolt : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 1;
			projectile.melee = true;
			projectile.alpha = 255;
			projectile.extraUpdates = 1;
			projectile.light = 0.5f;
			projectile.scale = 1.2f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dread Bolt");
		}
		
		public override void AI()
		{
			for (int index1 = 0; index1 < 3; ++index1)
			  {
				float num1 = projectile.velocity.X / 3f * (float) index1;
				float num2 = projectile.velocity.Y / 3f * (float) index1;
				int num3 = 4;
				int index2 = Dust.NewDust(new Vector2(projectile.position.X + (float) num3, projectile.position.Y + (float) num3), projectile.width - num3 * 2, projectile.height - num3 * 2, 74, 0.0f, 0.0f, 100, new Color(), 1.2f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 0.1f;
				Main.dust[index2].velocity += projectile.velocity * 0.1f;
				Main.dust[index2].position.X -= num1;
				Main.dust[index2].position.Y -= num2;
			  }
			  if (Main.rand.Next(5) == 0)
			  {
				int num = 4;
				int index = Dust.NewDust(new Vector2(projectile.position.X + (float) num, projectile.position.Y + (float) num), projectile.width - num * 2, projectile.height - num * 2, 74, 0.0f, 0.0f, 100, new Color(), 0.6f);
				Main.dust[index].velocity *= 0.25f;
				Main.dust[index].velocity += projectile.velocity * 0.5f;
			  }
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (target.boss == false && Main.rand.Next(10) == 0 && target.CanBeChasedBy(projectile) && target.life >= 1)
			{
				target.life = 1;
			}
		}
	}
}