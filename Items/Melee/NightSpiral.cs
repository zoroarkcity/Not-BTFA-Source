using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee
{
public class NightSpiral : ModItem
{
    public override void SetDefaults()
    {

        item.useStyle = 5;
        item.width = 24;
        item.height = 24;
        item.noUseGraphic = true;
        item.UseSound = SoundID.Item1;
        item.melee = true;
        item.channel = true;
        item.noMelee = true;
        item.useAnimation = 25;
        item.useTime = 25;
        item.shootSpeed = 16f;
        item.knockBack = 3.75f;
        item.damage = 25;
        item.value = 20000;
        item.rare = 2;
        item.shoot = mod.ProjectileType("BouncyProj");
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Night Spiral");
      Tooltip.SetDefault("");
    }

	
	public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DarkSludge", 10);
			recipe.AddTile(16);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
}
}
