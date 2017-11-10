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
	public class MarbleBlock : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Marble Skin");
			Description.SetDefault("Increases defense by 8");
			//Main.buffNoTimeDisplay[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.statDefense += 8;
		}
	}
}