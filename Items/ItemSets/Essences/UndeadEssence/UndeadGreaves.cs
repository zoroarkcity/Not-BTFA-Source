using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Essences.UndeadEssence
{
	[AutoloadEquip(EquipType.Legs)]
	public class UndeadGreaves : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 38000;
			item.rare = 3;
			item.defense = 6;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Skeletal Greaves");
		  Tooltip.SetDefault("15% increased throwing critical strike chance");
		}


		public override void UpdateEquip(Player player)
		{
			player.thrownCrit += 15;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "UndeadEnergy", 15);
			recipe.AddIngredient(ItemID.Bone, 27);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
