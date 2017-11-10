using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class DevilFlame : ModItem
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
      DisplayName.SetDefault("Devil's Flame");
      Tooltip.SetDefault("'Contains unholy powers'");
    }
	
		public override void Update(ref float gravity, ref float maxFallSpeed)
		{
			maxFallSpeed = 0f;
		}
	}
}
