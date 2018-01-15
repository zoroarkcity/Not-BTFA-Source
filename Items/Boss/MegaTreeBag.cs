using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Boss
{
	public class MegaTreeBag : ModItem
	{
		public override void SetDefaults()
		{

			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;

			item.expert = true;
			item.rare = 3;
			bossBagNPC = mod.NPCType("GhastlyEnt");
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
			int amountToDrop = Main.rand.Next(20,30);
			player.QuickSpawnItem(mod.ItemType("ForestEnergy"), amountToDrop);
			player.QuickSpawnItem(ItemID.Wood,(amountToDrop * 3));
            player.QuickSpawnItem(mod.ItemType("AmberCrystal"), 1);
            player.QuickSpawnItem(mod.ItemType("Fist_of_the_Hallow_Ent"), 1);
		}
	}
}
