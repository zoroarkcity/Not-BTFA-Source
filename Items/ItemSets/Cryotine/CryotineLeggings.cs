using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Cryotine
{
	[AutoloadEquip(EquipType.Legs)]
	public class CryotineLeggings : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;

			item.value = 16800;
			item.rare = 2;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Cryotine Greaves");
		  Tooltip.SetDefault("15% increased movement speed \nIncreases minion damage by 5%");
		}
		
		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.15f;
			player.minionDamage += 0.05f;
		}

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CryotineBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
