using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.GhastlyEnt.Boss.Projectiles
{
	public class Cursed_Flame_Eruption_Alt : ModProjectile
	{
		protected int dustTimer = 0;
		public override void SetDefaults()
		{
            projectile.width = 36;
            projectile.height = 36;
            projectile.aiStyle = 1;
			projectile.hostile = true;
			aiType = ProjectileID.WoodenArrowFriendly;
			projectile.tileCollide = true;
            projectile.penetrate = -1;
		}
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unholy Meteor");
        } 
		public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override void AI()
        {
			dustTimer++;
			Player player = Main.player[projectile.owner];
			if (dustTimer % 4 == 0)
			{
				float num = 16f;
				  for (int index1 = 0; (double) index1 < (double) num; ++index1)
				  {
					Vector2 v = (Vector2.UnitX * 0.0f + -Vector2.UnitY.RotatedBy((double) index1 * (6.28318548202515 / (double) num), new Vector2()) * new Vector2(1f, 4f)).RotatedBy((double) projectile.velocity.ToRotation(), new Vector2());
					int index2 = Dust.NewDust(projectile.Center, 0, 0, 75, 0.0f, 0.0f, 0, new Color(), 1f);
					Main.dust[index2].scale = 1.5f;
					Main.dust[index2].noGravity = true;
					Main.dust[index2].position = projectile.Center + v;
					Main.dust[index2].velocity = projectile.velocity * 0.0f + v.SafeNormalize(Vector2.UnitY) * 1f;
				  }
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Player player = Main.player[projectile.owner];
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 20, 0f, -8f, mod.ProjectileType("Cursed_Flame_Eruption"), 10, 10f, 0);
		}
	}
}