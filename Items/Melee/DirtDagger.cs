using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class DirtDagger : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 45;
			item.crit = -104;
			item.melee = true;
			item.width = 19;
			item.height = 25;
			item.useTime = 5;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.rare = -1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dirt Dagger");
			Tooltip.SetDefault("Critical strike and knockback are replaced by high damage output");
		}
	}
}
