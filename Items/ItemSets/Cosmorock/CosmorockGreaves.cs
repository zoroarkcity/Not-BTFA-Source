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

			item.value = Item.sellPrice(0, 3, 80, 0);
			item.rare = 6;
			item.defense = 10;
			item.lifeRegen = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmic Greaves");
			Tooltip.SetDefault("9% increased movement speed\nIncreased life regen");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.09f;
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
