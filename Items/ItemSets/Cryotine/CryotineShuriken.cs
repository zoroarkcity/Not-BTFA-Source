using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Cryotine
 {
public class CryotineShuriken : ModItem
{
	
    public override void SetDefaults()
    {

        item.damage = 16;
        item.thrown = true;
		item.noMelee = true;
		item.noUseGraphic = true;
        item.width = 22;
        item.height = 22;
        item.useTime = 13;
        item.useAnimation = 13;
        item.useStyle = 1;
		item.shootSpeed = 12f;
		item.shoot = mod.ProjectileType("CryotineShuriken");
        item.knockBack = 1;
		item.UseSound = SoundID.Item1;
        item.value = 280;
        item.rare = 2;
        item.autoReuse = true;
		item.consumable = true;
		item.maxStack = 999;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cryotine Razorblade");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "CryotineBar", 1);
        recipe.AddTile(TileID.Anvils);
        recipe.SetResult(this, 50);
        recipe.AddRecipe();
    }
}
}
