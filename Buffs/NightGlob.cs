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
	public class NightGlob : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Globules");
			Description.SetDefault("Ranged and thrown attacks may explode into 2 globules");
		}
		public override void Update(Player player, ref int buffIndex)
		{
			((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).nightlyglobs = true;
		}
	}
}