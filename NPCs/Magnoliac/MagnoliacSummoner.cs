using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Magnoliac
{
    public class MagnoliacSummoner : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 20;
            item.height = 20;
            item.maxStack = 999;


            item.value = 100;
            item.rare = 6;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 6;
            item.consumable = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Magnoliac Summoner");
      Tooltip.SetDefault("For testing purposes");
    }

        public override bool CanUseItem(Player player)
        {           
            return !NPC.AnyNPCs(mod.NPCType("Magnoliac"));
        }
        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)(player.position.X), (int)(player.position.Y - 900), (mod.NPCType("Magnoliac")));
            Main.PlaySound(15, (int)player.position.X - (int)player.position.Y, 0);
			Main.NewText("A bird, descends from above!", 175, 75, 255);

            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofLight, 6);
            recipe.AddIngredient(ItemID.Vine, 10);
            recipe.AddIngredient(ItemID.StoneBlock, 100);
            recipe.AddIngredient(ItemID.DirtBlock, 100);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
