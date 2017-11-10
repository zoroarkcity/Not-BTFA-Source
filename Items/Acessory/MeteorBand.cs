using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory
{
    public class MeteorBand : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 28;
            item.height = 20;

            item.value = 60000;
            item.rare = 1;
            item.accessory = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Meteor Band");
      Tooltip.SetDefault("Enhances your resistance to attacks by 5%, and you are immune to on fire!");
    }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance += 0.05f;
			player.buffImmune[24] = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(117, 6);
            recipe.AddTile(16);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
