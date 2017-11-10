using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Gelatine 
{
public class SlimyNecklace : ModItem
{
    public override void SetDefaults()
    {

        item.width = 24;
        item.height = 28;

        item.value = 40000;
        item.rare = 1;
        item.accessory = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Slimy Necklace");
      Tooltip.SetDefault("Minions have a chance to slow down enemies");
    }


    public override void UpdateAccessory(Player player, bool hideVisual)
	{
        ((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).SlimyNeck = true;
	}
	
	public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GelatineBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
}
}
