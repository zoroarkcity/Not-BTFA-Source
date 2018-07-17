using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Energazer_Set
{
	public class Energy_Remnant : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 14;
			item.height = 18;
			item.maxStack = 999;
			item.value = 500;
			item.rare = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Energy Remnant");
			Tooltip.SetDefault("'This shard acquired a useable form after years of shaping'");
		}
	}
}
