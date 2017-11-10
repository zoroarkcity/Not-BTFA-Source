using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Consumable
{
	public class BoneFungus : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Marrowbloom");
			Tooltip.SetDefault("'Skeletons enjoy this death smelling fungus' \n Summons the skeleton merchant");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 8;
			item.rare = 4;
			item.useAnimation = 30;
			item.useTime = 56;
			item.useStyle = 4;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(NPCID.SkeletonMerchant);
		}
		
		public override bool UseItem(Player player)
		{
			NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y, NPCID.SkeletonMerchant);
			Main.NewText("A skeletal figure has been allured", 175, 75, 255);
			Main.PlaySound(SoundID.Frog, player.position, 0);
			return true;
		}
	}
}