using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.BlizzardSet
 {
public class ColdShuriken : ModItem
{
	
    public override void SetDefaults()
    {

        item.damage = 10;
        item.thrown = true;
		item.noMelee = true;
		item.noUseGraphic = true;

        item.width = 22;
        item.height = 22;
        item.useTime = 16;
        item.useAnimation = 16;
        item.useStyle = 1;
		item.shootSpeed = 12f;
		item.shoot = mod.ProjectileType("ColdShuriken");
        item.knockBack = 1;
		item.UseSound = SoundID.Item1;
        item.value = 1;
        item.rare = 1;
        item.autoReuse = true;
		item.consumable = true;
		item.maxStack = 999;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Serrated Snowflake");
      Tooltip.SetDefault("Has a chance to inflict frostburn");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
		recipe.AddIngredient(null, "Galeshard", 1);
        recipe.AddTile(TileID.MythrilAnvil);
        recipe.SetResult(this, 99);
        recipe.AddRecipe();
    }
}
}
