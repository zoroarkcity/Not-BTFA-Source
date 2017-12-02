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
    public class ChlorophyllBuffOne : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Chlorophyll I");
			Description.SetDefault("Increased life regeneration and movement speed by 5%");
        }
        public override void Update(Player player, ref int buffIndex)
        {                                           
			player.lifeRegen += (player.lifeRegen/100)*5;
            player.moveSpeed += 0.05f;				
        }
    }
}