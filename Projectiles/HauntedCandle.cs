using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class HauntedCandle : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Haunted Candle");
			Main.projFrames[projectile.type] = 4;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.LightPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 36;
			projectile.penetrate = -1;
			projectile.netImportant = true;
			projectile.timeLeft *= 5;
			projectile.friendly = true;
			projectile.ignoreWater = true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			if (Main.player[projectile.owner].dead)
				projectile.Kill();
			if (Main.myPlayer == projectile.owner && modPlayer.hauntedCandle)
			  projectile.timeLeft = 2;
			if (projectile.tileCollide)
			{
				if (!Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.player[projectile.owner].Center, 1, 1))
					projectile.tileCollide = false;
				else if (!Collision.SolidCollision(projectile.position, projectile.width, projectile.height) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, Main.player[projectile.owner].Center, 1, 1))
					projectile.tileCollide = true;
			}
			projectile.direction = Main.player[projectile.owner].direction;
			projectile.spriteDirection = -projectile.direction;
			Lighting.AddLight(projectile.position, 0f, 0f, 1f);
			Vector2 vector2 = (Main.player[projectile.owner].Center - projectile.Center);
			vector2.X += projectile.direction * 40;
			vector2.Y -= 40;
			float num4 = vector2.Length();
			if ((double) num4 > 1000.0)
				projectile.Center = Main.player[projectile.owner].Center;
			float num5 = 3f;
			float num6 = 4f;
			if ((double) num4 > 200.0)
			{
				num6 += (float) (((double) num4 - 200.0) * 0.100000001490116);
				projectile.tileCollide = false;
			}
			if ((double) num4 < (double) num6)
			{
				projectile.velocity = (projectile.velocity * 0.25f);
				num6 = num4;
			}
			if (vector2.X != 0.0 || vector2.Y != 0.0)
			{
				vector2.Normalize();
				vector2 *= num6;
			}
			projectile.velocity = ((projectile.velocity * (num5 - 1f)) + vector2)/ num5;
			if (projectile.velocity.Length() > 6.0)
			{
				float num1 = (float) Math.Atan2((double) projectile.velocity.Y, (double) projectile.velocity.X) + 1.57f;
				if ((double) Math.Abs(projectile.rotation - num1) >= 3.14)
					projectile.rotation = (double) num1 >= (double) projectile.rotation ? projectile.rotation + 6.28f : projectile.rotation - 6.28f;
				projectile.rotation = (float) (((double) projectile.rotation * 4.0 + (double) num1) / 5.0);
			}
			else
			{
				if ((double) projectile.rotation > 3.14)
					projectile.rotation = projectile.rotation - 6.28f;
				projectile.rotation = (double) projectile.rotation <= -0.01 || (double) projectile.rotation >= 0.01 ? projectile.rotation * 0.9f : 0.0f;
			}
			projectile.frameCounter = projectile.frameCounter + 1;
			if (projectile.frameCounter > 6)
			{
				projectile.frameCounter = 0;
				projectile.frame = projectile.frame + 1;
				if (projectile.frame > 3)
					projectile.frame = 0;
			}
		}
	}
}