using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory {
public class LifeTwig : ModItem
{
    public override void SetDefaults()
    {

        item.width = 24;
        item.height = 28;

        item.value = 60000;
        item.rare = 1;
        item.accessory = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Twig of Life");
      Tooltip.SetDefault("Increases health by 40");
    }


    public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.statLifeMax2 += 40;
	}

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "LivingTwig");
        recipe.AddIngredient(ItemID.BandofRegeneration, 1);
        recipe.AddTile(114);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}
