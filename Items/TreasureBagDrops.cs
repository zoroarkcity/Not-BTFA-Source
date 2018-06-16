using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items
{
	public class TreasureBagDrops : GlobalItem
	{
		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (context == "bossBag" && arg == 3318 && Main.rand.Next(5) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("SlimeRod"), 1);
			}
			
			if (context == "bossBag" && arg == 3319)
			{
				switch (Main.rand.Next(2))
				{
					case 0: player.QuickSpawnItem(mod.ItemType("ServantStaff"), 1); 
						break;
					case 1: player.QuickSpawnItem(mod.ItemType("ThirdEye"), 1); 
						break;
				}
			}
			
			if (context == "bossBag" && arg == 3324 && Main.rand.Next(1) == 0)
			{
				int amountToDrop = Main.rand.Next(10,15);
				player.QuickSpawnItem(mod.ItemType("BrassAlloy"), amountToDrop);
				
				if (Main.rand.Next(4) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("MinerEmblem"), 1); 
				}
				
				if (Main.rand.Next(4) == 1)
				{
					player.QuickSpawnItem(mod.ItemType("ShinobiEmblem"), 1); 
				}
				
				if (Main.rand.Next(4) == 2)
				{
					player.QuickSpawnItem(mod.ItemType("BerserkerEmblem"), 1); 
				}
				
				if (Main.rand.Next(4) == 3)
				{
					player.QuickSpawnItem(mod.ItemType("PaladinEmblem"), 1); 
				}
			}
			
		    if (context == "bossBag" && arg == 3324 && Main.rand.Next(1) == 0)
			{
			
				if (Main.rand.Next(3) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("ClubMeat"), 1); 
				}
			}
		    if (context == "bossBag" && arg == 3326 && Main.rand.Next(1) == 0)
			{
			}
		}
	}
}