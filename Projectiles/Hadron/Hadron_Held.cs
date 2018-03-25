using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace ForgottenMemories.Projectiles.Hadron
{
	public class Hadron_Held : ModProjectile
	{
		protected int increaseSpeed = 10;
		float num1 = 1.570796f;
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = 75;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.hide = true;
			projectile.ranged = true;
			projectile.ignoreWater = true;
			Main.projFrames[projectile.type] = 9;
			projectile.damage = 200;
		}
		protected int shooterTimer = 0;
		public override void AI()
        {
			Lighting.AddLight(projectile.Center, 0.153f, 0.204f, 0.255f);
			Player player = Main.player[projectile.owner];

			Vector2 vector2_1 = player.RotatedRelativePoint(player.MountedCenter, true);
			num1 = 0.0f;
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
			int itemUseTime = increaseSpeed;
			int num4 = 0;
			--projectile.ai[1];
			bool flag = false;
			int num5 = -1;
			if ((double) projectile.ai[1] <= 0.0)
			{
			  projectile.ai[1] = (float) (itemUseTime - num4 * num2);
			  flag = true;
			  if ((int) projectile.ai[0] / (itemUseTime - num4 * num2) % 7 == 0)
				num5 = 0;
			}
			projectile.frameCounter += 1 + num2;
			if (projectile.frameCounter >= 4)
			{
			  projectile.frameCounter = 0;
			  ++projectile.frame;
			  if (projectile.frame >= Main.projFrames[projectile.type])
				projectile.frame = 0;
			}
			if (projectile.soundDelay <= 0)
			{
			  projectile.soundDelay = itemUseTime - num4 * num2;
			  if ((double) projectile.ai[0] != 1.0)
				Main.PlaySound(SoundID.Item36, projectile.position);
			}
			if (flag && Main.myPlayer == projectile.owner)
			{
				int weaponDamage = player.GetWeaponDamage(player.inventory[player.selectedItem]);
				bool canShoot = player.channel && player.HasAmmo(player.inventory[player.selectedItem], true) && !player.noItems && !player.CCed;
			  int shoot = 14;
			  float speed = 18f;
			  
			  float knockBack = player.inventory[player.selectedItem].knockBack;
			  if (canShoot)
			  {
				shootTimer++;
				player.PickAmmo(player.inventory[player.selectedItem], ref shoot, ref speed, ref canShoot, ref weaponDamage, ref knockBack, false);
				float weaponKnockback = player.GetWeaponKnockback(player.inventory[player.selectedItem], knockBack);
				float num6 = player.inventory[player.selectedItem].shootSpeed * projectile.scale;
				if (player.direction == -1)
				{
					num6 = player.inventory[player.selectedItem].shootSpeed * 1.2f * projectile.scale;
				}
				else
				{
					num6 = player.inventory[player.selectedItem].shootSpeed * projectile.scale;
				}
				Vector2 vector2_2 = vector2_1;
				Vector2 vector2_3 = Main.screenPosition + new Vector2((float) Main.mouseX, (float) Main.mouseY) - vector2_2;
				if ((double) player.gravDir == -1.0)
				  vector2_3.Y = (float) (Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - vector2_2.Y;
				Vector2 spinningpoint1 = Vector2.Normalize(vector2_3);
				if (float.IsNaN(spinningpoint1.X) || float.IsNaN(spinningpoint1.Y))
				  spinningpoint1 = -Vector2.UnitY;
				spinningpoint1 *= num6;
				spinningpoint1 = spinningpoint1.RotatedBy(Main.rand.NextDouble() * 0, new Vector2());
				if ((double) spinningpoint1.X != (double) projectile.velocity.X || (double) spinningpoint1.Y != (double) projectile.velocity.Y)
				  projectile.netUpdate = true;
				projectile.velocity = spinningpoint1;
				for (int index = 0; index < 1; ++index)
				{
				  Vector2 spinningpoint2 = Vector2.Normalize(projectile.velocity) * speed;
				  spinningpoint2 = spinningpoint2.RotatedBy(Main.rand.NextDouble() * 0.05f, new Vector2());
				  if (float.IsNaN(spinningpoint2.X) || float.IsNaN(spinningpoint2.Y))
					spinningpoint2 = -Vector2.UnitY;
				Projectile.NewProjectile(vector2_2.X, vector2_2.Y, spinningpoint2.X, spinningpoint2.Y, 638, weaponDamage + 200/increaseSpeed, weaponKnockback, projectile.owner, 0.0f, 0.0f);
				Projectile.NewProjectile(vector2_2.X, vector2_2.Y, spinningpoint2.X, spinningpoint2.Y, mod.ProjectileType("Hadron_Projectile"), weaponDamage, weaponKnockback, projectile.owner, 0.0f, 0.0f);
				}
			  }
			  else
				projectile.Kill();
			}
			projectile.position.Y += player.gravDir * 2f;
			
			accelerationCalc();
        }
		protected int shootTimer = 0;
		public void accelerationCalc()
		{
			Player player = Main.player[projectile.owner];
			bool onShoot = player.channel && player.HasAmmo(player.inventory[player.selectedItem], true) && !player.noItems && !player.CCed;
			
			if (onShoot)
			{
				shootTimer++;
				if (shootTimer >= 60 && increaseSpeed > 5)
				{
					Vector2 vector2_2 = player.RotatedRelativePoint(player.MountedCenter, true);
					Vector2 spinningpoint2 = Vector2.Normalize(projectile.velocity) * 18f;
					  spinningpoint2 = spinningpoint2.RotatedBy(Main.rand.NextDouble() * 0.05f, new Vector2());
					  if (float.IsNaN(spinningpoint2.X) || float.IsNaN(spinningpoint2.Y))
						spinningpoint2 = -Vector2.UnitY;
					Projectile.NewProjectile(vector2_2.X, vector2_2.Y, spinningpoint2.X, spinningpoint2.Y, mod.ProjectileType("Hadron_Missile"), 400/increaseSpeed, 10, projectile.owner, 0.0f, 0.0f);
					shootTimer = 0;
					increaseSpeed--;
				}
			}
			else
			{
				increaseSpeed = 10;
				shootTimer = 0;
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Player player = Main.player[projectile.owner];
			if (player.direction == 1)
			{
				SpriteEffects effects1 = SpriteEffects.None;
				Texture2D texture = Main.projectileTexture[projectile.type];
				int height = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
				int y2 = height * projectile.frame;
				Vector2 position = (projectile.position - (0.5f * projectile.velocity) + new Vector2((float) projectile.width, (float) projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition).Floor();
				float num1 = 1f;
				Main.spriteBatch.Draw(mod.GetTexture("Projectiles/Hadron/Hadron_Held"), position, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y2, texture.Width, height)), lightColor, projectile.rotation, new Vector2((float) texture.Width / 2f, (float) height / 2f), projectile.scale, effects1, 0.0f);
				Main.spriteBatch.Draw(mod.GetTexture("Projectiles/Hadron/Hadron_Held_Glow"), position, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y2, texture.Width, height)), Color.White, projectile.rotation, new Vector2((float) texture.Width / 2f, (float) height / 2f), projectile.scale, effects1, 0.0f);
			}
			else if (player.direction != 1)
			{
				SpriteEffects effects1 = SpriteEffects.FlipHorizontally;
				Texture2D texture = Main.projectileTexture[projectile.type];
				int height = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
				int y2 = height * projectile.frame;
				Vector2 position = (projectile.position - (0.5f * projectile.velocity) + new Vector2((float) projectile.width, (float) projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition).Floor();
				float num1 = 1f;
				Main.spriteBatch.Draw(mod.GetTexture("Projectiles/Hadron/Hadron_Held"), position, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y2, texture.Width, height)), lightColor, projectile.rotation, new Vector2((float) texture.Width / 2f, (float) height / 2f), projectile.scale, effects1, 0.0f);
				Main.spriteBatch.Draw(mod.GetTexture("Projectiles/Hadron/Hadron_Held_Glow"), position, new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y2, texture.Width, height)), Color.White, projectile.rotation, new Vector2((float) texture.Width / 2f, (float) height / 2f), projectile.scale, effects1, 0.0f);
			}
			return false;
		}
	}
}