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
	public class MucusGuard : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Sludge Skin");
			Description.SetDefault("Lowered movement speed, increased max life and defense");
			Main.buffNoTimeDisplay[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.moveSpeed -= 0.15f;
			player.statLifeMax2 += 15;
			player.statDefense += 7;
		}
	}
}