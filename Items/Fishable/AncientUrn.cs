using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
 
namespace ForgottenMemories.Items.Fishable
{
	public class AncientUrn : ModItem
    {
	  public override void SetStaticDefaults()
	  
	  {
      DisplayName.SetDefault("Ancient Urn");
      Tooltip.SetDefault("Right Click To Open");
      }
        public override void SetDefaults()
        {
            item.maxStack = 999;  
            item.consumable = true; 
            item.width = 34;  
            item.height = 34;   
            item.rare = 4;
            item.createTile = mod.TileType("AncientUrnTile"); 
            item.placeStyle = 0;
            item.useAnimation = 10; 
            item.useTime = 10;  
            item.useStyle = 1;
 
 
        }
        public override bool CanRightClick() 
        {
            return true;
        }
 
		public override void OpenBossBag(Player player)
		{
			switch (Main.rand.Next(3))
			{
				case 0: 
					player.QuickSpawnItem(ItemID.FlyingCarpet, 1);
					break;				
				case 1:
					player.QuickSpawnItem(ItemID.PharaohsMask, 1);
					player.QuickSpawnItem(ItemID.PharaohsRobe, 1);
					break;
				case 2:
					player.QuickSpawnItem(ItemID.SandstorminaBottle, 1);
					break;
				default:
					break;
			}
		}
    }
}