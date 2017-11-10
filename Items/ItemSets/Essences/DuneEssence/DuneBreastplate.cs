using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.DuneEssence
{
	[AutoloadEquip(EquipType.Body)]
	public class DuneBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;

			item.value = 25000;
			item.rare = 1;
			item.defense = 6;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dune Breastplate");
			Tooltip.SetDefault("5% increased melee damage and max life is increased by 20");
		}
		
		public override bool DrawBody ()
		{
			return false;
		}


		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.05f;
			player.statLifeMax2 += 25;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BossEnergy", 10);
			recipe.AddIngredient(ItemID.Cactus, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
