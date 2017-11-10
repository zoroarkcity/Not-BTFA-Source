using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class SpaceRockFragment : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.value = 16666;
			item.rare = 4;
			item.consumable = true;
			item.autoReuse = true;
            item.createTile = mod.TileType("CosmirockTile");
			item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cosmorock Fragment");
      Tooltip.SetDefault("");
    }

    }
}
