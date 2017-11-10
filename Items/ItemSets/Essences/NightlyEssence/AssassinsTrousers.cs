using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Essences.NightlyEssence
{
	[AutoloadEquip(EquipType.Legs)]
	public class AssassinsTrousers : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 25000;
			item.rare = 1;
			item.defense = 3;
		}

    public override void SetStaticDefaults()
    {
		DisplayName.SetDefault("Assassin's Trousers");
		Tooltip.SetDefault("5% increased ranged critical strike chance");
    }


		public override void UpdateEquip(Player player)
		{
           player.rangedCrit += 5;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"DarkEnergy", 7);
			recipe.AddIngredient(ItemID.Silk, 15);
			recipe.AddRecipeGroup("AnyIron", 4);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
