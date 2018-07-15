using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Barksteel_Set.Quagmire
{
    public class Quagmire : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 24;
            item.height = 24;
            item.value = 12000;
            item.rare = 2;
            item.accessory = true;
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quagmire");
			Tooltip.SetDefault("-10 defense\nPressing 'Quagmire Hotkey' when your cursor is on an enemy targets that enemy for 20 seconds\nMultiple enemies can be targetted if they are close\nTargetted enemy has lowered defense and takes double damage\nIf a mob without a target gets killed, you can't use this effect for 30 seconds\nIf an enemy with a target gets killed, timer resets");
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.GetModPlayer<WhirlingWorldsPlayer>().Quagmire = true;
			player.statDefense -= 10;
        }
		
		public override void AddRecipes()
		{
		    ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Barksteel", 10);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}
