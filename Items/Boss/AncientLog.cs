using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories;

namespace ForgottenMemories.Items.Boss 
{
	public class AncientLog : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 32;
			item.maxStack = 20;

			item.rare = 0;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Ancient Log");
		  Tooltip.SetDefault("Summons the forest's army");
		}

		
		public override bool UseItem(Player player)
        {
            if(!TGEMWorld.forestInvasionUp)
            {
                Main.NewText("The forests rumble...", 175, 75, 255, false);
                CustomInvasion.StartCustomInvasion();
				player.GetModPlayer<TgemPlayer>().MagnoliacBool = true;
				player.GetModPlayer<TgemPlayer>().GentBool = true;
                return true;
            }
            else
            {
                return false;
            }
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DevilFlame", 6);
			recipe.AddIngredient(null, "DarkEnergy", 4);
			recipe.AddIngredient(null, "BossEnergy", 4);
			recipe.AddIngredient(null, "SoaringEnergy", 4);
			recipe.AddIngredient(null, "UndeadEnergy", 4);
			recipe.AddRecipeGroup("AnyWood", 15);
			recipe.AddTile(18);
			recipe.SetResult(this);
			recipe.AddRecipe();	
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ForestEnergy", 8);
			recipe.AddRecipeGroup("AnyWood", 15);
			recipe.AddTile(18);
			recipe.SetResult(this);
			recipe.AddRecipe();	
		}
	}
}
