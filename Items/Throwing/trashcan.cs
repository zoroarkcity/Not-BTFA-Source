using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Throwing
{
	public class trashcan : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 36;
			item.thrown = true;
			item.width = 32;
			item.height = 36;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 2000;
			item.rare = -1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("trashcan");
			item.shootSpeed = 15;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.consumable = true;
			item.maxStack = 999;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Throwing Trashcan");
		  Tooltip.SetDefault("Bounces off of tiles, has a chance to make enemies bleed");
		}
	}
}
