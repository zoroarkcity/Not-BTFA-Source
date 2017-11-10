using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Cryotine
{
	[AutoloadEquip(EquipType.Body)]
	public class CryotineChestplate : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;

			item.value = 18000;
			item.rare = 2;
			item.defense = 5;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Cryotine Chestplate");
		  Tooltip.SetDefault("Increases your max number of minions");
		}


		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 1;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CryotineBar", 16);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
