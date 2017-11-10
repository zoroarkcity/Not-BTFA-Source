using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Titan
{
	public class TitanSpin : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.width = 24;
			item.height = 24;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;

			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 3.75f;
			item.damage = 43;
			item.value = Item.sellPrice(0, 1, 30, 0);
			item.rare = 5;
			item.shoot = mod.ProjectileType("TitanSpin");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titan's Spin");
			Tooltip.SetDefault("Leaves a damaging trail");
		}
	}
}
