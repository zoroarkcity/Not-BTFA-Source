using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Pet.Fatfrog
{
	public class Fatfrog : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fatfrog");
			Main.projFrames[projectile.type] = 3;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 38;
			projectile.height = 40;
			projectile.aiStyle = 1;
			aiType = ProjectileID.Bullet;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			BTFAPlayer modPlayer = player.GetModPlayer<BTFAPlayer>(mod);
			if (player.dead)
			{
				modPlayer.Frog = false;
			}
			if (modPlayer.Frog)
			{
				projectile.timeLeft = 2;
			}
			projectile.frameCounter++;
			
			if (projectile.frameCounter > 6)
			{
			   projectile.frame++;
               projectile.frameCounter = 0;
			}
            if (projectile.frame > 2)
            {
               projectile.frame = 0;
            }
			
			if (Main.rand.Next(2500)==0)
			{
				Main.PlaySound(31, projectile.position);
			}
			if (projectile.alpha > 70)
			{
				projectile.alpha -= 15;
				if (projectile.alpha < 70)
				{
					projectile.alpha = 70;
				}
			}
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			projectile.direction = player.direction;
			Vector2 move = Vector2.Zero;
			float distance = 800f;
			bool target = false;
					Vector2 newMove = player.Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						move = newMove;
						distance = distanceTo;
						target = true;
					}
			if (target)
			{
				AdjustMagnitude(ref move);
				projectile.velocity = (8 * projectile.velocity + move) / 3f;
				AdjustMagnitude(ref projectile.velocity);
			}
        }
		private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 6f)
			{
				vector *= 6f / magnitude;
			}
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
			projectile.timeLeft--;
            if (projectile.timeLeft <= 0)
            {    
               projectile.Kill();
            }
            projectile.velocity.X = 0;
            projectile.velocity.Y = -3;
            return false;
			
			projectile.active = true;
			projectile.velocity.X += 0.3f;
			projectile.velocity.Y += 0.3f;
        }
	}
}