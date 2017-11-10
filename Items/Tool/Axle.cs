using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Tool
{
	public class Axle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Axle");
		}

		public override void SetDefaults()
		{
			item.damage = 7;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 16;
			item.useAnimation = 19;
			item.pick = 52;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}
	}
}
