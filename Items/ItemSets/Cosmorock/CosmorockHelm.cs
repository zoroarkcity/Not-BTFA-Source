using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Cosmorock
{
	[AutoloadEquip(EquipType.Head)]
	public class CosmorockHelm : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;

			item.value = Item.sellPrice(0, 4, 20, 0);
			item.rare = 6;
			item.defense = 12;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmic Helmet");
			Tooltip.SetDefault("10% increased damage\n10% reduced damage taken");
		}
		
		public override bool DrawHead()	
		{
			return false;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("CosmorockChestplate") && legs.type == mod.ItemType("CosmorockGreaves");
		}

		public override void UpdateEquip(Player player)
		{
			player.endurance += 0.1f;
			player.meleeDamage += 0.1f;
			player.rangedDamage += 0.1f;
			player.thrownDamage += 0.1f;
			player.magicDamage += 0.1f;
			player.minionDamage += 0.1f;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Taking damage rains down meteors\nIncreased damage and decreased defense when above 50% life\nIncreased defense and decreased damage when below 50% life";
			((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).CosmicPowers = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SpaceRockFragment", 14);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
