using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.DuneEssence
{
	[AutoloadEquip(EquipType.Head)]
	public class DuneHelmet : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 35000;
			item.rare = 1;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dune Helmet");
			Tooltip.SetDefault("5% increased melee critical strike chance and max life increased by 15");
		}


		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("DuneBreastplate") && legs.type == mod.ItemType("DuneGreaves");
		}
		
                public override void ArmorSetShadows(Player player)
        	{
            		player.armorEffectDrawShadow = true;
        	}
	
		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 5;
			player.statLifeMax2 += 15;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Your melee stats and movement speed are increased when you are damaged";
			((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).duneBonus = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BossEnergy", 6);
			recipe.AddIngredient(ItemID.Cactus, 14);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
