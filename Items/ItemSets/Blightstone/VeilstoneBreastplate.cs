using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Blightstone
{
	[AutoloadEquip(EquipType.Body)]
	public class VeilstoneBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 300000;
			item.rare = 5;
			item.defense = 13;
			item.lifeRegen = 2;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Blightstone Chestplate");
      Tooltip.SetDefault("Increased life regen \n10% increased damage resistance");
    }


		public override void UpdateEquip(Player player)
		{
			player.endurance += 0.1f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "blight_bar", 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
