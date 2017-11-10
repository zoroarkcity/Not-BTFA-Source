using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory {
public class CosmicTwig : ModItem
{
    public override void SetDefaults()
    {

        item.width = 24;
        item.height = 28;

        item.value = 120000;
        item.rare = 1;
        item.accessory = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cosmic Twig");
      Tooltip.SetDefault("Increases health and mana by 40");
	  Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 6));
    }


    public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.statLifeMax2 += 40;
        player.statManaMax2 += 40;
	}
	

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "LifeTwig");
        recipe.AddIngredient(null, "ManaStar");
        recipe.AddTile(114);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}
