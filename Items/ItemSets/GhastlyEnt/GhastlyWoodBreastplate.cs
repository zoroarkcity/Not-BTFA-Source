using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.GhastlyEnt
{
	[AutoloadEquip(EquipType.Body)]
	public class GhastlyWoodBreastplate : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;

			item.value = 18000;
			item.rare = 2;
			item.defense = 5;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Ghastly Wood Breastplate");
		  Tooltip.SetDefault("5% increased magic damage and critical strike chance\nMaximum mana increased by 40");
		}


		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.05f;
			player.magicCrit += 5;
			player.statManaMax2 += 40;
		}
	}
}
