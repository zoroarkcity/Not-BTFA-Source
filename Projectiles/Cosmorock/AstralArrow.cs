using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Cosmorock
{
	public class AstralArrow : ModProjectile
	{
		protected int dustTimer = 19;
		public override void SetDefaults()
		{
            projectile.width = 14;
            projectile.height = 36;
            projectile.aiStyle = -1;
			projectile.alpha = 255;
			projectile.friendly = true;
			projectile.tileCollide = false;
            projectile.penetrate = -1;
			projectile.ranged = true;
			projectile.light = 0.75f;
		}
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astral Arrow");
        }
		
        public override void AI()
        {
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
			projectile.ai[0]++;
			if (projectile.alpha > 100 && projectile.ai[0] <= 60)
				projectile.alpha -= 5;
			
			if (projectile.ai[0] > 60)
			{
				projectile.alpha += 15;
				if(projectile.alpha > 255)
				{
					projectile.Kill();
				}
			}
			
			
			dustTimer++;
			
			Vector2 targetPos = projectile.Center;
			float targetDist = 200f;
			bool targetAcquired = false;
			
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].CanBeChasedBy(projectile) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[i].Center, 1, 1) && Main.npc[i].immune[projectile.owner] == 0)
				{
					float dist = projectile.Distance(Main.npc[i].Center);
					if (dist < targetDist)
					{
						targetDist = dist;
						targetPos = Main.npc[i].Center;
						targetAcquired = true;
					}
				}
			}
			
			if (targetAcquired)
			{
				float homingSpeedFactor = 15f;
				Vector2 homingVect = targetPos - projectile.Center;
				float dist = projectile.Distance(targetPos);
				dist = homingSpeedFactor / dist;
				homingVect *= dist;

				projectile.velocity = (projectile.velocity * 20 + homingVect) / 21f;
			}
			
			Player player = Main.player[projectile.owner];
			if (dustTimer % 20 == 0)
			{
				float num = 16f;
				for (int index1 = 0; (double) index1 < (double) num; ++index1)
				{
					int type = (projectile.ai[1] == 1) ? 269 : 
					(projectile.ai[1] == 2) ? 6 : 
					(projectile.ai[1] == 3) ? 21 : 
					(projectile.ai[1] == 4) ? 75 : 15;
					
					Vector2 v = (Vector2.UnitX * 0.0f + -Vector2.UnitY.RotatedBy((double) index1 * (6.28318548202515 / (double) num), new Vector2()) * new Vector2(1f, 4f)).RotatedBy((double) projectile.velocity.ToRotation(), new Vector2());
					int index2 = Dust.NewDust(projectile.Center, 0, 0, type, 0.0f, 0.0f, 100, new Color(), 1f);
					Main.dust[index2].scale = 1.5f;
					Main.dust[index2].fadeIn = 1.3f;
					Main.dust[index2].noGravity = true;
					Main.dust[index2].position = projectile.Center + (v*projectile.scale);
					Main.dust[index2].velocity = projectile.velocity * 0.0f + v.SafeNormalize(Vector2.UnitY) * 1f;
				}
			}
		}
	}
}