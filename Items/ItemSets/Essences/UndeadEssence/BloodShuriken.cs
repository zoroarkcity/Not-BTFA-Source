using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Essences.UndeadEssence
 {
public class BloodShuriken : ModItem
{
	
    public override void SetDefaults()
    {

        item.damage = 19;
        item.thrown = true;
		item.noMelee = true;
		item.noUseGraphic = true;
        item.width = 22;
        item.height = 22;

        item.useTime = 14;
        item.useAnimation = 14;
        item.useStyle = 1;
		item.shootSpeed = 10f;
		item.shoot = mod.ProjectileType("BloodShurikenProj");
        item.knockBack = 1;
		item.UseSound = SoundID.Item1;
		item.scale = 1f;
        item.value = 30000;
        item.rare = 3;
        item.autoReuse = true;
		item.consumable = true;
		item.maxStack = 999;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Blood Shuriken");
      Tooltip.SetDefault("Ingores gravity \nSteals small amounts of life on hit");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "UndeadEnergy", 1);
        recipe.AddIngredient(ItemID.Bone, 2);
        recipe.AddTile(TileID.Anvils);
        recipe.SetResult(this, 111);
        recipe.AddRecipe();
    }
}
}
