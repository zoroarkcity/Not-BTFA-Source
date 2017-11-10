using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Melee
{
	public class TrueEbony : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 116;
			item.melee = true;
			item.width = 88;
			item.height = 88;

			item.useTime = 28;
			item.crit = 12;
			item.useAnimation = 14;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 2500000;
			item.rare = 9;
			item.shoot = mod.ProjectileType("CosmirockMeteor");
			item.shootSpeed = 15f;
			item.useTurn = true;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("True Ebony");
      Tooltip.SetDefault("Rains down blighted meteors \nTrue melee strikes reduce enemy defense and summon blighted meteor heads");
    }

		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 15);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity *= 0.75f;
				Main.dust[dust].fadeIn = 1.3f;
				Main.dust[dust].scale = 0.7f;
			}
			
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 65);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity *= 0.75f;
				Main.dust[dust].fadeIn = 1.3f;
				Main.dust[dust].scale = 0.7f;
			}
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Main.PlaySound(2, (int)position.X, (int)position.Y, 88);
			int num8 = 3;
			for (int index = 0; index < num8; ++index)
			{
				Vector2 vector2_1 = new Vector2((float) ((double) player.position.X + (double) player.width * 0.5 + (double) (Main.rand.Next(201) * -player.direction) + ((double) Main.mouseX + (double) Main.screenPosition.X - (double) player.position.X)), player.MountedCenter.Y - 600f);
				vector2_1.X = (float) (((double) vector2_1.X + (double) player.Center.X) / 2.0) + (float) Main.rand.Next(-200, 201);
				vector2_1.Y -= (float) (100 * index);
				float num9 = (float) ((double) Main.mouseX + (double) Main.screenPosition.X - (double) vector2_1.X + (double) Main.rand.Next(-40, 41) * 0.0299999993294477);
				float num10 = (float) Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
				if ((double) num10 < 0.0)
				num10 *= -1f;
				if ((double) num10 < 20.0)
				num10 = 20f;
				float num11 = (float) Math.Sqrt((double) num9 * (double) num9 + (double) num10 * (double) num10);
				float num12 = item.shootSpeed / num11;
				float num13 = num9 * num12;
				float num14 = num10 * num12;
				float num15 = num13;
				float num16 = num14 + (float) Main.rand.Next(-40, 41) * 0.02f;
				int p = Projectile.NewProjectile(vector2_1.X, vector2_1.Y, num15 * 0.75f, num16 * 0.75f, mod.ProjectileType("BlightedMeteor"), damage, knockBack, player.whoAmI, 0.0f, (float) (0.5 + Main.rand.NextDouble() * 0.300000011920929));
				Main.projectile[p].ai[1] = position.Y;
			}
			return false;
        }
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(mod.BuffType("CosmicCurse"), 180, false);
			target.AddBuff(mod.BuffType("BlightFlame"), 180, false);
			if (crit == true)
			{
				target.defense -= 10;
				Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("BlightedBoom"), damage, 5f, player.whoAmI, 0f, 0f);
			}
			
			if (!target.immortal && !target.friendly)
				this.BlightSword(target, damage, knockback);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Ebony", 1);
			recipe.AddIngredient(1826, 1); //Horseman's Blade
			recipe.AddIngredient(ItemID.FragmentSolar, 5);
			recipe.AddIngredient(ItemID.FragmentNebula, 5);
			recipe.AddIngredient(ItemID.FragmentVortex, 5);
			recipe.AddIngredient(ItemID.FragmentStardust, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		private void BlightSword(NPC target, int dmg, float kb)
		{
			int checkScreenHeight = Main.screenHeight;
			int checkScreenWidth = Main.screenWidth;
			int num1 = Main.rand.Next(100, 300);
			int num2 = Main.rand.Next(100, 300);
			int num3 = Main.rand.Next(2) != 0 ? num1 + (checkScreenWidth / 2 - num1) : num1 - (checkScreenWidth / 2 + num1);
			int num4 = Main.rand.Next(2) != 0 ? num2 + (checkScreenHeight / 2 - num2) : num2 - (checkScreenHeight / 2 + num2);
			int num5 = num3 + (int) Main.player[item.owner].position.X;
			int num6 = num4 + (int) Main.player[item.owner].position.Y;
			double num7 = 4.0;
			Vector2 vector2;
			vector2 = new Vector2 (num5, num6);
			float num8 = (float) (target.position.X - vector2.X);
			float num9 = (float) (target.position.Y - vector2.Y);
			double num10 = Math.Sqrt((double) num8 * (double) num8 + (double) num9 * (double) num9);
			float num11 = (float) (num7 / num10);
			float SpeedX = num8 * num11;
			float SpeedY = num9 * num11;
			int p = Projectile.NewProjectile((float) num5, (float) num6, SpeedX, SpeedY, mod.ProjectileType("BlightHead"), dmg, kb, Main.player[item.owner].whoAmI, 0.0f, 0.0f);
			Main.projectile[p].ai[0] = target.whoAmI;
		}
	}
}
