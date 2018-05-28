using Terraria.ModLoader;
using Terraria;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
 
namespace ForgottenMemories.Mounts.AcheronMount
{
    public class Obolos_Buff : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
			DisplayName.SetDefault("Obolos");
			Description.SetDefault("'Pretty grimacing...'");
        }
 
        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(mod.MountType("Obolos_Mount"), player);
            player.buffTime[buffIndex] = 10;
        }
    }
}