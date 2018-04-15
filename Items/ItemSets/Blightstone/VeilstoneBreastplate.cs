using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Blightstone
{
	[AutoloadEquip(EquipType.Body)]
	public class VeilstoneBreastplate : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 300000;
			item.rare = 5;
			item.defense = 19;
			item.lifeRegen = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blightstone Chestplate");
			Tooltip.SetDefault("Increased life regen\n8% increased damage\n10% increased damage resistance");
		}

		public override void UpdateEquip(Player player)
		{
			player.endurance += 0.1f;
			player.meleeDamage += 0.08f;
			player.rangedDamage += 0.08f;
			player.magicDamage += 0.08f;
			player.thrownDamage += 0.08f;
			player.minionDamage += 0.08f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "blight_bar", 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
