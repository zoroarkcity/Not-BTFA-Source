using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class SubmergedAshes : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Submerged Ashes");
			Tooltip.SetDefault("'Brought back up from a haunted star'");
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 99;
			item.rare = 6;
			item.value = Item.sellPrice(0, 8, 0, 0);
		}
	}
}
