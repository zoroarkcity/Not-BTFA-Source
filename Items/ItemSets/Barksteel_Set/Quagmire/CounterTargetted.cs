using System.Collections.Generic;
using Terraria;
using System.Collections.Generic;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.ItemSets.Barksteel_Set.Quagmire 
{
    public class CounterTargetted : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = true; 
            Main.pvpBuff[Type] = false; 
            Main.buffNoSave[Type] = true;
			DisplayName.SetDefault("Counter Targetted");
			Description.SetDefault("You can't target anyone");
        }
    }
}