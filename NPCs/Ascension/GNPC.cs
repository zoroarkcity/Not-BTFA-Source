using System;
using System;
using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace ForgottenMemories.NPCs.Ascension
{
    public class GNPC : GlobalNPC
    {
        
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == 124)
            {
                    shop.item[nextSlot].SetDefaults(mod.ItemType("MechanicsHammer"));
                    nextSlot++;
            }
        }

    }
}
