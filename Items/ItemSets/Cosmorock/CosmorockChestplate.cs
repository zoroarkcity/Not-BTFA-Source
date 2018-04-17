using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Cosmorock
{
	[AutoloadEquip(EquipType.Body)]
	public class CosmorockChestplate : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;

			item.value = Item.sellPrice(0, 5, 20, 0);
			item.rare = 6;
			item.defense = 20;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmic Chestplate");
			Tooltip.SetDefault("6% increased critical strike chance\nIncreases max life by 50");
		}

		public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += 50;
			player.meleeCrit += 6;
			player.rangedCrit += 6;
			player.magicCrit += 6;
			player.thrownCrit += 6;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SpaceRockFragment", 18);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
