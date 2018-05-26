using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.Ammo {
public class FleshDart : ModItem
{
	
    public override void SetDefaults()
    {

        item.damage = 6;
        item.ranged = true;
        item.width = 22;
        item.height = 22;

		item.shootSpeed = 2f;
		item.shoot = mod.ProjectileType("FleshDartProj");
        item.knockBack = 1;
		item.UseSound = SoundID.Item1;
		item.scale = 1f;
        item.value = 3;
        item.rare = 1;
        item.ammo = AmmoID.Dart;
		item.maxStack = 999;
		item.consumable = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Flesh Dart");
      Tooltip.SetDefault("Ammo for blowpipes \nCreates a large amount of blood");
    }

	
	        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TissueSample, 1);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
}}
