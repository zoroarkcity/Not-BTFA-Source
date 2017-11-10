using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.ItemSets.Cryotine
{
	public class SnowfallTome : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 13;
			item.mana = 8;
			item.magic = true;
			item.width = 88;
			item.height = 88;
			item.useTime = 11;
			item.useAnimation = 11;

			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 16800;
			item.rare = 2;
			item.shoot = mod.ProjectileType("IceBolt");
			item.noMelee = true;
			item.shootSpeed = 18f;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Snowfall Tome");
		  Tooltip.SetDefault("Creates a storm of ice energy");
		}

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"CryotineBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int num8 = Main.rand.Next(3) + 1;
			for (int index = 0; index < num8; ++index)
			{
				Vector2 vector2_1 = new Vector2((float) ((double) player.position.X + (double) player.width * 0.5 + (double) (Main.rand.Next(201) * -player.direction) + ((double) Main.mouseX + (double) Main.screenPosition.X - (double) player.position.X)), player.MountedCenter.Y - 600f);
				vector2_1.X = (float) (((double) vector2_1.X + (double) player.Center.X) / 2.0) + (float) Main.rand.Next(-300, 301);
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
				int mememaster = Projectile.NewProjectile(vector2_1.X, vector2_1.Y, num15 * 0.75f, num16 * 0.75f, type, damage, knockBack, player.whoAmI, 0.0f, player.position.Y);
			}
			return false;
		}
	}
}
