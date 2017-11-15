using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Essences.SoaringEssence
{
	[AutoloadEquip(EquipType.Legs)]
	public class SoaringGreaves : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 38000;
			item.rare = 2;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Soaring Leggings");
		  Tooltip.SetDefault("7% increased magic damage and critical strike chance");
		}


		public override void UpdateEquip(Player player)
		{
            player.magicDamage += 0.07f;
			player.magicCrit += 7;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SoaringEnergy", 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
