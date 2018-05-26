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


            item.value = 1000;
            item.rare = 3;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 6;
            item.consumable = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Alluring Bud");
      Tooltip.SetDefault("Summons Magnoliac \n'Has a strong connection with nature...'");
    }

        public override bool CanUseItem(Player player)
        {           
            return !NPC.AnyNPCs(mod.NPCType("Magnoliac"));
        }
        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)(player.position.X), (int)(player.position.Y - 900), (mod.NPCType("Magnoliac")));
            Main.PlaySound(15, (int)player.position.X - (int)player.position.Y, 0);
			Main.NewText("A beast flaps its wings and descends from a faraway canopy!", 175, 75, 255);

            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ForestEnergy", 16);
			recipe.AddIngredient(null, "DevilFlame", 8);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
