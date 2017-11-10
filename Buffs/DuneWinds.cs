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
	public class DuneWinds : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Dune Winds");
			Description.SetDefault("Increased movement speed and melee stats");
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.meleeCrit += 10;
			player.meleeSpeed += 0.1f;
			player.meleeDamage += 0.1f;
			player.moveSpeed += 0.15f;
		}
	}
}