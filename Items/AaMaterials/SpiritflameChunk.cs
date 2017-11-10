using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class SpiritflameChunk : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 7;
			item.height = 8;
			item.maxStack = 999;
			item.value = 1000;
			item.rare = 4;
		}
		
		public override void Update(ref float gravity, ref float maxFallSpeed)
		{
			maxFallSpeed = 0f;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Spiritflame Chunk");
		  Tooltip.SetDefault("'Contains the essence of a lost soul'");
		}
	}
}
