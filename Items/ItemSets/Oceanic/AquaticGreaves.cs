using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Oceanic
{
	[AutoloadEquip(EquipType.Legs)]
	public class AquaticGreaves : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;

			item.value = 50000;
			item.rare = 3;
			item.defense = 6;
			item.lifeRegen = 1;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Aquatic Greaves");
      Tooltip.SetDefault("7% increased melee speed and damage");
    }


		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.07f;
			player.meleeSpeed  += 0.07f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "WaterShard", 7);
			recipe.AddIngredient(ItemID.SharkFin, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
