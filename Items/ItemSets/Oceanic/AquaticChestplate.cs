using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Oceanic
{
	[AutoloadEquip(EquipType.Body)]
	public class AquaticChestplate : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;

			item.value = 50000;
			item.rare = 3;
			item.defense = 8;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Aquatic Chestplate");
      Tooltip.SetDefault("6% increased melee damage and critical strike chance");
    }


		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 6;
			player.meleeDamage += 0.06f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "WaterShard", 10);
			recipe.AddIngredient(ItemID.SharkFin, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
