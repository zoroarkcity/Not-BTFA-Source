using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory
{
    public class VolcanicBoots : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 34;
            item.height = 34;

            item.value = 400000;
            item.rare = 8;
            item.accessory = true;
        }

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Vulcanspark Boots");
		  Tooltip.SetDefault("Allows flight, super fast running, and extra mobility on ice \n10% increased movement speed \nProvides the ability to walk on water and lava \nGrants immunity to fire blocks, fall damage, and 14 seconds of immunity to lava \nEnhances your jump with fire, and grants auto jump \nYou leave behind a trail of sparks");
		}


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).firestorm = true;
            player.jumpSpeedBoost += 2.2f;
            player.noFallDmg = true;
            player.fireWalk = true;
            player.autoJump = true;
			player.waterWalk = true;
            player.fireWalk = true;
            player.lavaMax += 840;
			player.accRunSpeed = 6.75f;
            player.rocketBoots = 3;
            player.moveSpeed = player.moveSpeed + 0.1f;
            player.iceSkate = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FirestormFrogLegs", 1);
			recipe.AddIngredient(ItemID.FrostsparkBoots, 1);
			recipe.AddIngredient(ItemID.LavaWaders, 1);
			recipe.AddIngredient(ItemID.SoulofMight, 3);
			recipe.AddIngredient(ItemID.SoulofFright, 3);
			recipe.AddIngredient(ItemID.SoulofSight, 3);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
