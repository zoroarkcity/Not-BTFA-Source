using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.NightlyEssence
{
	[AutoloadEquip(EquipType.Body)]
	public class AssassinsRobes : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;

			item.value = 25000;
			item.rare = 1;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Assassin's Robes");
			Tooltip.SetDefault("5% increased ranged critical strike chance");
		}
		
		public override bool DrawBody ()
		{
			return false;
		}


		public override void UpdateEquip(Player player)
		{
			player.rangedCrit += 5;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"DarkEnergy", 9);
			recipe.AddIngredient(ItemID.Silk, 7);
			recipe.AddRecipeGroup("AnyCopper", 4);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
