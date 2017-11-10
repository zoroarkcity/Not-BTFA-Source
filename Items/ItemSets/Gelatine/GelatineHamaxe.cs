using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Gelatine {
public class GelatineHamaxe : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 15;
        item.melee = true;
        item.width = 38;
        item.height = 36;
        item.useTime = 28;
        item.useAnimation = 28;
        item.useStyle = 1;
        item.knockBack = 7;
        item.value = 40000;
        item.rare = 1;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
		item.axe = 12;
		item.hammer = 80;
		item.useTurn = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Gelatine Hamaxe");
      Tooltip.SetDefault("");
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
