using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class Tourmaline : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.value = 10000;
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tourmaline");
			Tooltip.SetDefault("");
		}
    }
}
