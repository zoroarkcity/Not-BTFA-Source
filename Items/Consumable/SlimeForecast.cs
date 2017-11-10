using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Consumable
{
    public class SlimeForecast : ModItem
    {
		public override void SetStaticDefaults()
		{
		    DisplayName.SetDefault("Goocloud Rune");
			Tooltip.SetDefault("Summons the slime rain");
		}
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.scale = 1;
            item.maxStack = 1;
            item.useTime = 30;
            item.useAnimation = 30;
            item.UseSound = SoundID.Item1;
            item.useStyle = 1;
            item.consumable = true;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.rare = 1;
        }
   
        public override bool UseItem(Player player)
        {
            if(!Main.slimeRain)
            {
                Main.NewText("An ancient alchemy has been cast!", 175, 75, 255, false);
                Main.StartSlimeRain(true);
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
            recipe.AddIngredient(ItemID.Gel, 66);
	    recipe.AddIngredient(null, "GelatineBar", 8);
            recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
