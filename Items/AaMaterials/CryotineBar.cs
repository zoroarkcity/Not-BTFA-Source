using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class CryotineBar : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.value = 14000;
			item.rare = 2;
//everything beyond this comment is the placing
            item.createTile = mod.TileType("BarCryo");
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cryotine Bar");
      Tooltip.SetDefault("");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CryotineOreItem", 3);
			recipe.AddIngredient(null, "Galeshard", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
