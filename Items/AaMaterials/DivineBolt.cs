using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class DivineBolt : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 7;
			item.height = 8;
			item.maxStack = 999;
			item.value = 1000;
			item.rare = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Divine Bolt");
			Tooltip.SetDefault("'A fragment torn from pure thunder'");
		}
	}
}
