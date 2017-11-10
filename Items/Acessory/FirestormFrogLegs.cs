using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory
{
    public class FirestormFrogLegs : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 34;
            item.height = 34;

            item.value = 200000;
            item.rare = 2;
            item.accessory = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Firestorm Frog Legs");
      Tooltip.SetDefault("Enhances your jump, leaving behind fire, nullifying fall damage and fire block damage, and granting auto jump.");
    }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).firestorm = true;
            player.jumpSpeedBoost += 2.2f;
            player.noFallDmg = true;
            player.fireWalk = true;
            player.autoJump = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(396, 1);
            recipe.AddIngredient(ItemID.FrogLeg, 1);
            recipe.AddIngredient(null, "FirestormBottle", 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
