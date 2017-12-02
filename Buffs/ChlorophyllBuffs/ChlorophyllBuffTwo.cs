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
    public class ChlorophyllBuffTwo : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Chlorophyll II");
			Description.SetDefault("Increased life regeneration and movement speed by 10%");
        }
        public override void Update(Player player, ref int buffIndex)
        {                                           
			player.lifeRegen += (player.lifeRegen/100)*10;
            player.moveSpeed += 0.1f;				
        }
    }
}