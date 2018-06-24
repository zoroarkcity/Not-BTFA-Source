using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameInput;
 
namespace ForgottenMemories.Items.Fishing
{
    public class Fishing : ModPlayer
    {
       
        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            if (liquidType == 0 && Main.rand.Next(50) == 0) 
            {
                caughtType = mod.ItemType("ForgottenCrate");
            }
			if (liquidType == 0 && Main.rand.Next(50) == 0) 
            {
                caughtType = mod.ItemType("AmmoBag");
            }
			if (liquidType == 0 && player.ZoneJungle && Main.rand.Next(100) == 0) 
            {
                caughtType = mod.ItemType("Tadpole_Egg");
            }
        }
 
    }
}