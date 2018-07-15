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
    public class Targetted : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = true; 
            Main.pvpBuff[Type] = false; 
            Main.buffNoSave[Type] = false;
			DisplayName.SetDefault("Targetted");
			Description.SetDefault("You will take double the damage and your defense is lowered");
        }
		
        public override void Update(NPC npc, ref int buffIndex)
        {
			npc.defense -= 5;
        }
    }
}