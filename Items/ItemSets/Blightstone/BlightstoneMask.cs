using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Blightstone
{
	[AutoloadEquip(EquipType.Head)]
	public class BlightstoneMask : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 6, 0, 0);
			item.rare = 7;
			item.defense = 16;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blightstone Mask");
			Tooltip.SetDefault("14% increased ranged and thrown damage\n25% chance not to consume ammo or thrown weapons");
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
			player.rangedDamage += 0.14f;
			player.thrownDamage += 0.14f;
			((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).BlightConserve = true;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Thrown and Ranged attacks have a chance to explode into blighted fire";
			((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).BlightFlameProj = true;
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
