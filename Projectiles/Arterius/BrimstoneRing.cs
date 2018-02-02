using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Projectiles.Arterius
{
	public class BrimstoneRing : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 150;
			projectile.height = 150;
			projectile.aiStyle = 2;
			projectile.penetrate = -1;
			projectile.timeLeft = 6;
			projectile.hostile = true;
			projectile.alpha = 255;
			projectile.tileCollide = false;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brimstone");
		}
		public override bool PreAI()
		{
			Lighting.AddLight(projectile.position, 1f, 0f, 0f);
            for (int i = 0; i < 8; i++)
			{
				Vector2 velocity = new Vector2(Main.rand.Next(4, 8), 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(45) + i * 45));
				Dust newDust = Dust.NewDustDirect(projectile.Center, 0, 0, 130, velocity.X, velocity.Y);
				newDust.noGravity = true;
				newDust.fadeIn = 0.2f;
				newDust.scale = 2;
			}
			return false;
		}
		public virtual bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
	}
}	