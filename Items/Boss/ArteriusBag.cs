using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Boss
{
	public class ArteriusBag : ModItem
	{
		public override void SetDefaults()
		{

			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;

			item.expert = true;
			item.rare = 4;
			bossBagNPC = mod.NPCType("FaceOfInsanity");
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
			player.TryGettingDevArmor();
            player.QuickSpawnItem(mod.ItemType("BloodHeart"), 1);
			
			switch (Main.rand.Next(4))
			{
				case 0: 
					player.QuickSpawnItem(mod.ItemType("SeveredTongue"), 1);
					break;
				case 1: 
					player.QuickSpawnItem(mod.ItemType("HemorrhageStaff"), 1);
					break;
				case 2:
					player.QuickSpawnItem(mod.ItemType("BloodLeech"), Main.rand.Next(270, 300));
					break;
				case 3:
					player.QuickSpawnItem(mod.ItemType("GoredLung"), 1);
					break;
				default:
					break;
			}
			if (Main.rand.Next(7) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("ArteryMask"), 1);
			}
		}
	}
}
