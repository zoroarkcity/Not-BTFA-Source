using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Tool
{
	public class WhackTree : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Whack-a-tree");
		}

		public override void SetDefaults()
		{
			item.damage = 9;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 17;
			item.useAnimation = 25;
			item.axe = 12;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = Item.sellPrice(0, 0, 48, 0);
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}
	}
}
