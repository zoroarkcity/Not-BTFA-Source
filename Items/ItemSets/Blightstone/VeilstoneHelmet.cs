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
			item.value = Item.sellPrice(0, 6, 0, 0);
			item.rare = 7;
			item.defense = 27;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blightstone Helmet");
			Tooltip.SetDefault("15% increased melee damage and 12% increased melee crit chance");
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
			player.meleeDamage += 0.15f;
			player.meleeCrit += 12;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Creates a ring of malevolent fire around you\nYou deal increased damage to enemies inside the ring";
			((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).BlightFlameRing = true;
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
