using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.UndeadEssence
{
	[AutoloadEquip(EquipType.Body)]
	public class UndeadBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;

			item.value = 40000;
			item.rare = 3;
			item.defense = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skeletal Chestplate");
			Tooltip.SetDefault("12% increased throwing velocity \n33% chance not to consume thrown weapons");
		}
		
		public override bool DrawBody ()
		{
			return false;
		}


		public override void UpdateEquip(Player player)
		{
			player.thrownVelocity += 0.12f;
			player.thrownCost33 = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"UndeadEnergy", 18);
			recipe.AddIngredient(ItemID.Bone, 30);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
