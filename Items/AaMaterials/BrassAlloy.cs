using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class BrassAlloy : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 10;
			item.height = 10;
			item.noMelee = true; 
			item.value = 25000;
			item.rare = 4;
			item.scale = 0.75f;
			item.maxStack = 999;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Brass Alloy");
      Tooltip.SetDefault("");
    }

		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WarriorEmblem, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SorcererEmblem, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RangerEmblem, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SummonerEmblem, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MinerEmblem", 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BerserkerEmblem", 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
			
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PaladinEmblem", 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }
	}
}
