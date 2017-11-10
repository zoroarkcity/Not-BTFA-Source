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

			item.value = 210000;
			item.rare = 6;
			item.defense = 14;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmic Helmet");
			Tooltip.SetDefault("10% reduced damage taken");
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
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Taking damage rains down meteors \nWhen below 50% health defensive stats are increased at the cost of damage and movement speed";
			((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).CosmicPowers = true;
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
