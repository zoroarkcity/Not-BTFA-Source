using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Essences.DuneEssence
{
	[AutoloadEquip(EquipType.Legs)]
	public class DuneGreaves : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 25000;
			item.rare = 1;
			item.defense = 5;
		}

    public override void SetStaticDefaults()
    {
		DisplayName.SetDefault("Dune Greaves");
		Tooltip.SetDefault("5% increased melee speed and max life increased by 15");
    }


		public override void UpdateEquip(Player player)
		{
            player.meleeSpeed += 0.05f;
			player.statLifeMax2 += 15;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BossEnergy", 8);
			recipe.AddIngredient(ItemID.Cactus, 16);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
