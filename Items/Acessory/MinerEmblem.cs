using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ForgottenMemories.Items.Acessory
{
    public class MinerEmblem : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 14;
            item.height = 14;

            item.value = 100000;
            item.rare = 3;
            item.accessory = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Miner Emblem");
      Tooltip.SetDefault("Increases mining speed by 25%");
    }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.pickSpeed *= 0.75f;
        }
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BrassAlloy", 10);
            recipe.AddTile(16);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BrassAlloy", 10);
            recipe.AddTile(16);
            recipe.SetResult(ItemID.WarriorEmblem, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BrassAlloy", 10);
            recipe.AddTile(16);
            recipe.SetResult(ItemID.SorcererEmblem, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BrassAlloy", 10);
            recipe.AddTile(16);
            recipe.SetResult(ItemID.SummonerEmblem, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BrassAlloy", 10);
            recipe.AddTile(16);
            recipe.SetResult(ItemID.RangerEmblem, 1);
            recipe.AddRecipe();
        }
    }
}
