using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class blight_bar : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.value = 20000;
			item.rare = 5;
            //item.createTile = mod.TileType("BarBlight");

        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Blightstone Bar");
      Tooltip.SetDefault("");
    }

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BlightOreItem", 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
