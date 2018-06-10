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
	public class ForgottenCrate : ModItem
    {
	  public override void SetStaticDefaults()
	  
	  {
      DisplayName.SetDefault("Forgotten Crate");
      Tooltip.SetDefault("Right Click To Open");
      }
        public override void SetDefaults()
        {
            item.maxStack = 999;  
            item.consumable = true; 
            item.width = 34;  
            item.height = 34;   
            item.rare = 4;
            item.createTile = mod.TileType("ForgottenCrateTile"); 
            item.placeStyle = 0;
            item.useAnimation = 10; 
            item.useTime = 10;  
            item.useStyle = 1;
 
 
        }
        public override bool CanRightClick() 
        {
            return true;
        }
 
        public override void RightClick(Player player)
        {
			List<int> Valuable = new List<int>();
			Valuable.Add(mod.ItemType("Tourmaline"));
			Valuable.Add(mod.ItemType("DarkEnergy"));
			Valuable.Add(mod.ItemType("Citrine"));
			Valuable.Add(mod.ItemType("Galeshard"));
 
            if (NPC.downedBoss1)
            {
                Valuable.Add(mod.ItemType("GelatineBar"));
				Valuable.Add(mod.ItemType("BossEnergy"));
            }				
            if (NPC.downedBoss2)
            {
                Valuable.Add(mod.ItemType("DarkSludge")); 
				Valuable.Add(mod.ItemType("CryotineBar"));
				Valuable.Add(mod.ItemType("SoaringEnergy"));
            }	
            if (NPC.downedBoss3)
            {
				Valuable.Add(mod.ItemType("UndeadEnergy"));
				Valuable.Add(mod.ItemType("DevilFlame"));
				Valuable.Add(mod.ItemType("WaterShard"));
				Valuable.Add(mod.ItemType("Spinel"));
            }	
			Valuable.ToArray();
			player.QuickSpawnItem(Valuable[Main.rand.Next(0, Valuable.Count)], Main.rand.Next(5, 17));
			player.QuickSpawnItem(Valuable[Main.rand.Next(0, Valuable.Count)], Main.rand.Next(5, 17));
			player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(3, 5));  
 
        }
 
    }
}