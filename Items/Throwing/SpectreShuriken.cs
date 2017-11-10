using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.Throwing
 {
public class SpectreShuriken : ModItem
{
	
    public override void SetDefaults()
    {

        item.damage = 63;
        item.thrown = true;
		item.noMelee = true;
		item.noUseGraphic = true;

        item.width = 22;
        item.height = 22;
        item.useTime = 16;
        item.useAnimation = 16;
        item.useStyle = 1;
		item.shootSpeed = 12f;
		item.shoot = mod.ProjectileType("SpectreShuriken");
        item.knockBack = 1;
		item.UseSound = SoundID.Item1;
        item.value = 13;
        item.rare = 8;
        item.autoReuse = true;
		item.consumable = true;
		item.maxStack = 999;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Spectre Shuriken");
      Tooltip.SetDefault("Homes in on nearby enemies");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.Ectoplasm, 1);
        recipe.AddTile(TileID.MythrilAnvil);
        recipe.SetResult(this, 75);
        recipe.AddRecipe();
    }
}
}
