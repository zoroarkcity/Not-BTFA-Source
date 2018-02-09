using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory 
{
	public class SapNecklace : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 28;


			item.value = 50000;
			item.rare = 8;
			item.accessory = true;
			item.expert = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Sap Necklace");
      Tooltip.SetDefault("Summon attacks have a chance to create balls of sap\nIncreased Max Minions");
    }


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).sapBall = true;
			player.maxMinions += 1;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AmberCrystal", 1);
			recipe.AddIngredient(ItemID.PygmyNecklace, 1);
			recipe.AddTile(114);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
