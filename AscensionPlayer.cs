using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameInput;


namespace ForgottenMemories
{
    public class AscensionPlayer : ModPlayer
    {
        public override void PreUpdate()
        {
           if (player.ZoneSnow && Main.raining && (player.position.Y / 16) <= Main.worldSurface)
            {
                if (Main.rand.Next(600) == 0)
                {
                    Item.NewItem((int)player.position.X + Main.rand.Next(-2000, 2000), (int)player.position.Y - Main.rand.Next(233), 1, 1, mod.ItemType("Galeshard"));
                }
            }
        }
    }
}
