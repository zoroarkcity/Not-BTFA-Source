using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Boss
{
	public class AcheronBag : ModItem
	{
		public override void SetDefaults()
		{

			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;

			item.expert = true;
			item.rare = 4;
			bossBagNPC = mod.NPCType("Acheron");
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
            player.QuickSpawnItem(mod.ItemType("Curse"), 1); 
			
			switch (Main.rand.Next(6))
			{
				case 0: 
					player.QuickSpawnItem(mod.ItemType("Thanatos"), 1);
					break;
				case 1: 
					player.QuickSpawnItem(mod.ItemType("Styx"), 1);
					break;
				case 2:
					player.QuickSpawnItem(mod.ItemType("AcheronStaff"), 1);
					break;
				case 3:
					player.QuickSpawnItem(mod.ItemType("MacabreGrimoire"), 1);
					break;
				case 4:
					player.QuickSpawnItem(mod.ItemType("Cerberus"), 1);
					break;
				case 5:
					player.QuickSpawnItem(mod.ItemType("HadesHand"), 1);
					player.QuickSpawnItem(mod.ItemType("LostSoul"), Main.rand.Next(150, 201));
					break;
				default:
					break;
			}
			
			if (Main.rand.Next(5) == 0)
				player.QuickSpawnItem(mod.ItemType("BansheeLure"), 1);
				
		}
	}
}
