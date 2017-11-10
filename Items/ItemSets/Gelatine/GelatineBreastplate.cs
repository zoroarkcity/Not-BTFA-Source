using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Gelatine
{
	[AutoloadEquip(EquipType.Body)]
	public class GelatineBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;

			item.value = 30000;
			item.rare = 1;
			item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gelatine Breastplate");
			Tooltip.SetDefault("Increases your maxiumum minions by 1");
		}
		
		public override bool DrawBody ()
		{
			return false;
		}


		public override void UpdateEquip(Player player)
		{
			player.maxMinions+= 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GelatineBar", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
