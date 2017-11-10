using Terraria.ModLoader;

namespace ForgottenMemories.Items.TileItems
{
	public class AcheronTrophy : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 50000;
			item.rare = 1;
			item.createTile = mod.TileType("AcheronTrophy");
			item.placeStyle = 0;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Acheron Trophy");
			Tooltip.SetDefault("");
		}
	}
}