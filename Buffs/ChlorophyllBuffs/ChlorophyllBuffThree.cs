using System.Collections.Generic;
using Terraria;
using System.Collections.Generic;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Buffs.ChlorophyllBuffs
{
    public class ChlorophyllBuffThree : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Chlorophyll III");
			Description.SetDefault("Increased life regeneration and movement speed by 15%");
        }
        public override void Update(Player player, ref int buffIndex)
        {                                           
			player.lifeRegen += (player.lifeRegen/100)*15;
            player.moveSpeed += 0.15f;				
        }
    }
}