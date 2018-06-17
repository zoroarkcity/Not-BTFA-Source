using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Magnoliac
{
	public class MagnoliacTreasureBag : ModItem
	{
		public override void SetDefaults()
		{

			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.expert = true;
			bossBagNPC = mod.NPCType("MagnoliacSecondStage");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Treasure Bag");
      Tooltip.SetDefault("Right click to open");
    }


		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
            player.QuickSpawnItem(mod.ItemType("ChlorophyllPod"), 1); 
			
			switch (Main.rand.Next(6))
			{
				case 0: 
					player.QuickSpawnItem(mod.ItemType("Beechorang"), 1);
					break;
				case 1: 
					player.QuickSpawnItem(mod.ItemType("Dandelion_Staff"), 1);
					break;
				case 2:
					player.QuickSpawnItem(mod.ItemType("SequoiaWaraxe"), 1);
					break;
				case 3:
					player.QuickSpawnItem(mod.ItemType("Acorn_Launcher"), 1);
					player.QuickSpawnItem(ItemID.Acorn, Main.rand.Next(30, 60));
					break;
				case 4:
					player.QuickSpawnItem(mod.ItemType("GhastlyKnife"), 1);
					break;
				case 5:
					player.QuickSpawnItem(mod.ItemType("FernlingCane"), 1);
					break;
				default:
					break;
			}
			if (Main.rand.Next(7) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("birdman"), 1);
			}
				
		}
	}
}
