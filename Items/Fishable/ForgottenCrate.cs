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
			List<int> Valuable = new List<int>(); //Valuable itemtype- These are fairly common and balanced around the current stage of the playthrough
			List<int> Treasure = new List<int>(); //Treasure itemtype- These are moderately rare, they are from the next stage in progression
			List<int> Essence = new List<int>(); //Essence itemtype- There will always be once essence drop from the current point in progression
			List<int> BossSummon = new List<int>(); //BossSummon itemtype- These are fairly rare, they are the summon item for a BTFA boss
			List<int> Fungus = new List<int>(); //Fungus itemtype- This is very rare and is purely to obtain the marrowbloom
			List<int> DivineBolt = new List<int>(); //DivineBolt itemtype- Common, purely to get divine bolts
			Valuable.Add(mod.ItemType("Tourmaline")); 
			Valuable.Add(mod.ItemType("Citrine"));
			Valuable.Add(mod.ItemType("Galeshard"));            
			Treasure.Add(mod.ItemType("GelatineBar"));
			Essence.Add(mod.ItemType("DarkEnergy"));
			BossSummon.Add(mod.ItemType("SlimeForecast"));
			Fungus.Add(mod.ItemType("BoneFungus"));
 
            if (NPC.downedBoss1)
            {
				Essence.Add(mod.ItemType("BossEnergy"));
			    Treasure.Add(mod.ItemType("Spinel"));				
            }				
            if (NPC.downedBoss2)
            {
                Valuable.Add(mod.ItemType("DarkSludge")); 
				Valuable.Add(mod.ItemType("CryotineBar"));
				Essence.Add(mod.ItemType("SoaringEnergy"));
			    DivineBolt.Add(mod.ItemType("DivineBolt"));
            }	
            if (NPC.downedBoss3)
            {
				Essence.Add(mod.ItemType("UndeadEnergy"));
				Valuable.Add(mod.ItemType("DevilFlame"));
				Valuable.Add(mod.ItemType("WaterShard")); 
			    BossSummon.Add(mod.ItemType("AncientLog"));			    
				BossSummon.Add(mod.ItemType("Unstable_Wisp"));
			}
            if (main.hardMode)
            {
				Valuable.Add(mod.ItemType("BrassAlloy"));
				BossSummon.Add(mod.ItemType("BloodClot"));
            }	
			if (TGEMWorld.downedForestInvasion)
            {
				BossSummon.Add(mod.ItemType("MagnoliacSummoner"));
				Valuable.Add(mod.ItemType("ForestEnergy"));
			}
			Valuable.ToArray();
			Treasure.ToArray();
			Essence.ToArray();
			BossSummon.ToArray();
			Fungus.ToArray();
			player.QuickSpawnItem(Essence[Main.rand.Next(0, Valuable.Count)], Main.rand.Next(3, 8));
		    player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(1, 11));
			if (Main.rand.Next(2) == 0)
			{
			player.QuickSpawnItem(Valuable[Main.rand.Next(0, Valuable.Count)], Main.rand.Next(3, 12));
			}  
			if (Main.rand.Next(12) == 0)
			{
			player.QuickSpawnItem(Treasure[Main.rand.Next(0, Valuable.Count)], Main.rand.Next(4, 10));
			}  
			if (Main.rand.Next(10) == 0)
			{
			player.QuickSpawnItem(BossSummon[Main.rand.Next(0, Valuable.Count)], Main.rand.Next(1, 1));
			}  
			if (Main.rand.Next(50) == 0)
			{
			player.QuickSpawnItem(Fungus[Main.rand.Next(0, Valuable.Count)], Main.rand.Next(1, 1));
			}  
 			if (Main.rand.Next(3) == 0)
			{
			player.QuickSpawnItem(DivineBolt[Main.rand.Next(0, Valuable.Count)], Main.rand.Next(1, 2));
			}  
        }
    }
}