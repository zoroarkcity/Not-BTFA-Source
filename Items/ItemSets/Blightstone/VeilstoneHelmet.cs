using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Blightstone
{
	[AutoloadEquip(EquipType.Head)]
	public class VeilstoneHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;

			item.value = 250000;
			item.rare = 5;
			item.defense = 20;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Blightstone Helmet");
      Tooltip.SetDefault("14% increased melee damage and 7% increased melee crit chance");
    }


		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("VeilstoneBreastplate") && legs.type == mod.ItemType("VeilstoneGreaves");
		}
		
		public override bool DrawHead()
		{
			return false;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.14f;
			player.meleeCrit += 7;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Creates a ring of malevolent fire around you";
			((TgemPlayer)player.GetModPlayer(mod, "TgemPlayer")).BlightFlameRing = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "blight_bar", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
