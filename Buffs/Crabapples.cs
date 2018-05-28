using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class Crabapples : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Crabapples");
			Description.SetDefault("'Ok... this is epic'");
			Main.buffNoTimeDisplay[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
            player.statLifeMax2 = 9999999;
			player.lifeRegen = 999999;
		}
	}
}