using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory
{
    public class BerserkerEmblem : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 14;
            item.height = 14;

            item.value = 100000;
            item.rare = 4;
            item.accessory = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Berserker Emblem");
      Tooltip.SetDefault("Increases Crit Chance by 12%.");
    }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeCrit += 12;
			player.magicCrit += 12;
			player.rangedCrit += 12;
			player.thrownCrit += 12;
        }
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BrassAlloy", 10);
            recipe.AddTile(16);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
