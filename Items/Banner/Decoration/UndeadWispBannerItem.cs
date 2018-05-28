using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Banner.Decoration
{
	public class UndeadWispBannerItem : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 10;
			item.height = 24;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.rare = 1;
			item.value = Item.buyPrice(0, 0, 10, 0);
			item.createTile = mod.TileType("UndeadWispBannerTile");
			item.placeStyle = 1;		//Place style means which frame(Horizontally, starting from 0) of the tile should be placed
		}
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Undead Wisp Banner");
            Tooltip.SetDefault("Doesn't serve any purpose other than vanity");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarkEnergy", 5);
			recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddTile(86);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}