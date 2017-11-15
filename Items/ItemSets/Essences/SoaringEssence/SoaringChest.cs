using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.SoaringEssence
{
	[AutoloadEquip(EquipType.Body)]
	public class SoaringChest : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;

			item.value = 40000;
			item.rare = 2;
			item.defense = 6;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soaring Jacket");
			Tooltip.SetDefault("Decreases mana cost and increases magic damage by 5% \nIncreases maximum mana by 20");
		}
		
		public override bool DrawBody ()
		{
			return true;
		}


		public override void UpdateEquip(Player player)
		{
            player.magicDamage += 0.05f;
            player.statManaMax2 += 20;
            player.manaCost -= 0.05f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"SoaringEnergy", 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
