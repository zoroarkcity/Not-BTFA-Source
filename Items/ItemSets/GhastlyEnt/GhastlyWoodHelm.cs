using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.GhastlyEnt
{
	[AutoloadEquip(EquipType.Head)]
	public class GhastlyWoodHelm : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;

			item.value = 15000;
			item.rare = 2;
			item.defense = 5;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Ghastly Wood Helm");
		  Tooltip.SetDefault("Increases magic damage and critical strike chance by 10%");
		}


		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("GhastlyWoodBreastplate") && legs.type == mod.ItemType("GhastlyWoodGreaves");
		}

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.1f;
			player.magicCrit += 10;
        }

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Magic critical strikes fire leaves at the enemy hit";
			((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).ghastlywood = true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ForestEnergy", 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
