using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.ItemSets.Cosmodium
{
	public class CosmodiumBar : ModItem
	{
		public override void SetDefaults()
		{	

            item.width = 24;
            item.height = 28;
            item.value = 50000;
            item.rare = 11;
            item.maxStack = 999;
            //item.createTile = mod.TileType("BarCosmodium");
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cosmodium Bar");
      Tooltip.SetDefault("");
    }
	
	
		
		public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(246, 0, 255);
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CosmodiumOre", 4);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
