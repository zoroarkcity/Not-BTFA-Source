using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class WaterShard : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 10;
			item.height = 10;
			item.noMelee = true; 
			item.value = 6000;
			item.rare = 2;
			item.maxStack = 999;
			item.consumable = true;
			item.autoReuse = true;
            item.createTile = mod.TileType("WaterShard");
			item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Water Shard");
			Tooltip.SetDefault("");
		}
	}
}
