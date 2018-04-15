using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Blightstone
{
	[AutoloadEquip(EquipType.Legs)]
	public class VeilstoneGreaves : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 200000;
			item.rare = 5;
			item.defense = 14;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blightstone Greaves");
			Tooltip.SetDefault("15% increased movement speed \n5% increased max movement speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.15f;
			player.maxRunSpeed  *= 1.05f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "blight_bar", 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
