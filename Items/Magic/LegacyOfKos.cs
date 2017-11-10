using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
	public class LegacyOfKos : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 33;
			item.magic = true;
			item.mana = 8;
			item.width = 25;
			item.height = 26;

			item.useTime = 35;
			item.UseSound = SoundID.Item20;
			item.useAnimation = 35;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 7;
			Item.staff[item.type] = true;
			item.value = 200000;
			item.rare = 5;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SpiderEgg");
			item.shootSpeed = 16f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Legacy Of Kos");
			Tooltip.SetDefault("Fires exploding spider eggs");
		}


		
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float sX = speedX;
			float sY = speedY;
			sX += (float)Main.rand.Next(-60, 61) * 0.02f;
			sY += (float)Main.rand.Next(-60, 61) * 0.02f;
			Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Obsidian, 15);
			recipe.AddIngredient(1339, 10);
			recipe.AddIngredient(ItemID.SpiderFang, 15);
			recipe.AddIngredient(ItemID.VenomStaff);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

		}
	}
}
