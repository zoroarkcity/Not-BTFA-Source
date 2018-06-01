using System.Collections.Generic;
using Terraria;
using System.Collections.Generic;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.InGameWiki.Buffs
{
    public class Educating : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
			DisplayName.SetDefault("Educating");
			Description.SetDefault("You can learn more on our discord server!");
        }
        public override void Update(Player player, ref int buffIndex)
        {
        }
    }
}