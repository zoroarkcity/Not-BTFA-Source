using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Tool
{
	public class GooRattle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bone Crusher");
		}

		public override void SetDefaults()
		{
			item.damage = 8;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 21;
			item.useAnimation = 27;
			item.hammer = 52;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = Item.sellPrice(0, 0, 75, 0);
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}
	}
}
