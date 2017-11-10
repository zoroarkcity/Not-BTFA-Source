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
	public class DivineBlessing : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Divine Blessing");
			Description.SetDefault("Attacks have a chance to create chain lightning");
			//Main.buffNoTimeDisplay[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).DivineBlessing = true;
		}
	}
}