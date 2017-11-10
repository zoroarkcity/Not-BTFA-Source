using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.GhastlyEnt
{
	[AutoloadEquip(EquipType.Legs)]
	public class GhastlyWoodGreaves : ModItem
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
		  DisplayName.SetDefault("Ghastly Wood Greaves");
		  Tooltip.SetDefault("7% increased magic damage\nMaximum mana increased by 20");
		}
		
		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.07f;
			player.statManaMax2 += 20;
		}

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ForestEnergy", 6);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
