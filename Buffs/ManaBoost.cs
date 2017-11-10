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
	public class ManaBoost : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Magic Boost");
			Description.SetDefault("15% increased magic damage");
			//Main.buffNoTimeDisplay[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.magicDamage += 0.15f;
		}
	}
}