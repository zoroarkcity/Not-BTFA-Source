using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee 
{
	public class Gourd : ModItem
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
			item.damage = 16;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = 3;
			item.shoot = mod.ProjectileType("GourdProj");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cackle");
			Tooltip.SetDefault("");
		}
	}
}
