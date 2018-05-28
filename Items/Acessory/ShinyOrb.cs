using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory {
public class ShinyOrb : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 22;
			item.consumable = true;
			item.createTile = mod.TileType("OrbTile");
			item.value = 100000;
			item.expert = true;
			item.rare = 9;
			item.accessory = true;
			item.useTime = 10;
			item.useStyle = 1;
			item.useTurn = true;
			item.autoReuse = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Shiny Orb");
      Tooltip.SetDefault("Standing still increases life regen, summons homing energy over time");
    }


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).ShinyOrbSpawn();
			player.shinyStone = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SporeSac, 1);
			recipe.AddIngredient(ItemID.ShinyStone, 1);
			recipe.AddTile(114);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
