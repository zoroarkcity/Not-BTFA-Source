using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Gelatine
{
	[AutoloadEquip(EquipType.Legs)]
	public class GelatineGreaves : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;

			item.value = 25000;
			item.rare = 1;
			item.defense = 2;
            item.lifeRegen = 3;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Gelatine Greaves");
      Tooltip.SetDefault("7% increased summon damage");
    }


		public override void UpdateEquip(Player player)
		{
           player.minionDamage += 0.07f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GelatineBar", 9);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
