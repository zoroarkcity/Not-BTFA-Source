using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Cosmorock
{
	[AutoloadEquip(EquipType.Legs)]
	public class CosmorockGreaves : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;

			item.value = 180000;
			item.rare = 6;
			item.defense = 12;
			item.lifeRegen = 2;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cosmic Greaves");
      Tooltip.SetDefault("Increased Life Regen");
    }

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SpaceRockFragment", 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
