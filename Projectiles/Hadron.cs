using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace ForgottenMemories.Projectiles
{
	public class Hadron : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 22;
			//projectile.aiStyle = 75;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.hide = false;
			projectile.ranged = true;
			projectile.ignoreWater = true;	
			Main.projFrames[projectile.type] = 9;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hadron");
		}
		
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			float num1 = 0.0f;
			Player player1 = Main.player[projectile.owner];
			Vector2 vector2_1 = player1.RotatedRelativePoint(player1.MountedCenter, true);
			if (projectile.spriteDirection == -1)
				num1 = 3.141593f;
			++projectile.ai[0];
			int num2 = 0;
			if ((double) projectile.ai[0] >= 40.0)
				++num2;
			if ((double) projectile.ai[0] >= 80.0)
				++num2;
			if ((double) projectile.ai[0] >= 120.0)
				++num2;
			int num3 = 40;
			int num4 = 0;
			--projectile.ai[1];
			bool flag = false;
			int num5 = -1;
			if ((double) projectile.ai[1] <= 0.0)
			{
				projectile.ai[1] = (float) (num3);
				flag = true;
				if ((int) projectile.ai[0] / (num3 - num4 * num2) % 7 == 0)
					num5 = 0;
			}
			projectile.frameCounter++;
			if (projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				projectile.frame = projectile.frame + 1;
				if (projectile.frame >= Main.projFrames[projectile.type])
					projectile.frame = 0;
			}
			if (flag && Main.myPlayer == projectile.owner)
			{
				bool canShoot = player1.channel && player1.HasAmmo(player1.inventory[player1.selectedItem], true) && !player1.noItems && !player1.CCed;
				int shoot = 14;
				float speed = 14f * ((num2 / 6) + 1);
				int weaponDamage = player1.GetWeaponDamage(player1.inventory[player1.selectedItem]) * ((num2 / 6) + 1);
				float knockBack = player1.inventory[player1.selectedItem].knockBack;
				if (canShoot)
				{
					player1.PickAmmo(player1.inventory[player1.selectedItem], ref shoot, ref speed, ref canShoot, ref weaponDamage, ref knockBack, false);
					float weaponKnockback = player1.GetWeaponKnockback(player1.inventory[player1.selectedItem], knockBack);
					float num6 = player1.inventory[player1.selectedItem].shootSpeed * projectile.scale * ((num2 / 6) + 1);
					Vector2 vector2_2 = vector2_1;
					Vector2 vector2_3 = ((Main.screenPosition + new Vector2((float) Main.mouseX, (float) Main.mouseY)) - vector2_2);
					if ((double) player1.gravDir == -1.0)
						vector2_3.Y = ((float) (Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - vector2_2.Y);
					Vector2 vector2_4 = Vector2.Normalize(vector2_3);
					if (float.IsNaN((float) vector2_4.X) || float.IsNaN((float) vector2_4.Y))
						vector2_4 = Vector2.UnitY;
					Vector2 vector2_5 = (vector2_4 * num6).RotatedBy(Main.rand.NextDouble() * 0.130899697542191 - 0.0654498487710953);
					if (vector2_5.X != projectile.velocity.X || vector2_5.Y != projectile.velocity.Y)
						projectile.netUpdate = true;
					projectile.velocity = vector2_5;
					for (int index = 0; index < 4; ++index)
					{
						Vector2 vector2_6 = (Vector2.Normalize(projectile.velocity) * speed).RotatedBy(Main.rand.NextDouble() * 0.196349546313286 - 0.0981747731566429);
						if (float.IsNaN((float) vector2_6.X) || float.IsNaN((float) vector2_6.Y))
							vector2_6 = (Vector2.UnitY);
						Projectile.NewProjectile((float) vector2_2.X, (float) vector2_2.Y, (float) vector2_6.X, (float) vector2_6.Y, shoot, weaponDamage, weaponKnockback, projectile.owner, 0.0f, 0.0f);
					}
					float num7 = 8f;
					{
						Vector2 vector2_6 = (Vector2.Normalize(projectile.velocity) * num7).RotatedBy(Main.rand.NextDouble() * 0.392699092626572 - 0.196349546313286);
						if (float.IsNaN((float) vector2_6.X) || float.IsNaN((float) vector2_6.Y))
							vector2_6 = (Vector2.UnitY);
						Projectile.NewProjectile((float) vector2_2.X, (float) vector2_2.Y, (float) vector2_6.X, (float) vector2_6.Y, 616, weaponDamage * 2, weaponKnockback * 1.25f, projectile.owner, 0.0f, 0.0f);
						
						Main.PlaySound(SoundID.Item36, projectile.position);
					}
				}
				else
					projectile.Kill();
			}
			projectile.position = player.RotatedRelativePoint(player.MountedCenter, true) - projectile.Size / 2f;
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.Pi/4;
			//projectile.spriteDirection = projectile.direction;
			projectile.timeLeft = 2;
			player.ChangeDir(projectile.direction);
			player.heldProj = projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = (float)Math.Atan2((double)(projectile.velocity.Y * (float)projectile.direction), (double)(projectile.velocity.X * (float)projectile.direction));
			Vector2 vector38 = Main.OffsetsPlayerOnhand[player.bodyFrame.Y / 56] * 2f;
			if (player.direction != 1)
			{
				vector38.X = (float)player.bodyFrame.Width - vector38.X;
			}
			if (player.gravDir != 1f)
			{
				vector38.Y = (float)player.bodyFrame.Height - vector38.Y;
			}
			vector38 -= new Vector2((float)(player.bodyFrame.Width - player.width), (float)(player.bodyFrame.Height - 42)) / 2f;
			projectile.Center = player.RotatedRelativePoint(player.position + vector38, true) - projectile.velocity;
			
			projectile.position.Y += player1.gravDir * 2;
		}
	}
}