using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories.Projectiles.InfoA;

namespace ForgottenMemories.Items.ItemSets.Cosmodium
{
	public class CosmodiumOre : ModItem
	{
		public override void SetDefaults()
		{	

            item.width = 24;
            item.height = 28;
            item.value = 10000;
            item.rare = 11;

            item.maxStack = 999;
            item.useStyle = 1;
            item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

            item.createTile = mod.TileType("Cosmodium");
        }
		
		public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(246, 0, 255);
                }
            }
        }
		
		

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cosmodium Ore");
      Tooltip.SetDefault("'Pulsing with energy from another realm'");
    }


		
	}
}
