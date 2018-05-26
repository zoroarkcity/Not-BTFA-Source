using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.GhastlyEnt
{
    public class GhastlySummon : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 20;
            item.height = 20;
            item.maxStack = 999;


            item.value = 1000;
            item.rare = 5;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 6;
            item.consumable = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Sinful Orchid");
      Tooltip.SetDefault("Summons the Ghastly Ent");
    }

        public override bool CanUseItem(Player player)
        {           
            return !NPC.AnyNPCs(mod.NPCType("GhastlyEnt"));
        }
        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)(player.position.X), (int)(player.position.Y - 900), (mod.NPCType("GhastlyEnt")));
            Main.PlaySound(15, (int)player.position.X - (int)player.position.Y, 0);
			Main.NewText("The wretched father of nature awakens!", 175, 75, 255);

            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CherryBranch", 16);
			recipe.AddIngredient(null, "ForestEnergy", 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
