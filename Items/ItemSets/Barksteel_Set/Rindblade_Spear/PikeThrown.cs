using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Barksteel_Set.Rindblade_Spear
{
	public class PikeThrown : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nomad's Pike");
		}

		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = -1;
		}


		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
			{
				targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
			}
			return projHitbox.Intersects(targetHitbox);
		}

		public override void Kill(int timeLeft)
		{
			Player player = Main.player[projectile.owner];
			
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
			Vector2 usePos = projectile.position;	
			Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); 
			usePos += rotVector * 16f;

			for (int i = 0; i < 20; i++)
			{	
				int dustIndex = Dust.NewDust(usePos, projectile.width, projectile.height, 8, 0f, 0f, 0, default(Color), 1f);
				Dust currentDust = Main.dust[dustIndex];
				currentDust.position = (currentDust.position + projectile.Center) / 2f;
				currentDust.velocity += rotVector * 2f;
				currentDust.velocity *= 0.5f;
				currentDust.noGravity = true;
				usePos -= rotVector * 8f;
			}
			for (int index2 = 0; index2 < 1; ++index2)
			{
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("PikeTotem"), 0, 0f, player.whoAmI, 0f, 0f); 
            }
		}

		private const float maxTicks = 45f;
		private const int alphaReduction = 25;
		
		public override void AI()
		{
			if (projectile.alpha > 0)
			{
				projectile.alpha -= alphaReduction;
			}
			if (projectile.alpha < 0)
			{
				projectile.alpha = 0;
			}
			if (projectile.ai[0] == 0f)
			{
				projectile.ai[1] += 1f;
				if (projectile.ai[1] >= maxTicks)
				{
					float velXmult = 0.98f;
					float velYmult = 0.35f;
					projectile.ai[1] = maxTicks;
					projectile.velocity.X = projectile.velocity.X * velXmult;
					projectile.velocity.Y = projectile.velocity.Y + velYmult;
				}
				projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f); // Please notice the MathHelper usage, offset the rotation by 90 degrees (to radians because rotation uses radians) because the sprite's rotation is not aligned!

				if (Main.rand.Next(3) == 0)
				{
					int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 8, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 200, default(Color), 1.2f);
					Main.dust[dustIndex].velocity += projectile.velocity * 0.3f;
					Main.dust[dustIndex].velocity *= 0.2f;
				}
				if (Main.rand.Next(4) == 0)
				{
					int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 8, 0f, 0f, 254, default(Color), 0.3f);
					Main.dust[dustIndex].velocity += projectile.velocity * 0.5f;
					Main.dust[dustIndex].velocity *= 0.5f;
					return;
				}
			}
		}
	}
}
