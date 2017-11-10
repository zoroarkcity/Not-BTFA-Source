using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Tiles
{
    public class GourdDrop : GlobalTile
    {
        public override bool Drop(int i, int j, int type)
        {
            if (type == 254)
            {
                if (Main.rand.Next(200) == 0)
                {
                    Item.NewItem(i * 16, j * 16, 16, 16, mod.ItemType("Gourd"));
                    return false;
                }
            }
            return true;
        }
    }
}