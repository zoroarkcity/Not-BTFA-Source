using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Throwing
{
	public class ChlorophyteKunai : ModItem
	{

		public override void SetDefaults()
		{
			item.damage = 60;
			item.thrown = true;
			item.shoot = mod.ProjectileType("ChlorophyteKunai");


			item.consumable = true;
			item.shootSpeed = 15f;
			item.useTime = 14;
			item.useAnimation = 14;
			item.consumable = true;
			item.maxStack = 999;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.value = 100;
			item.rare = 7;
			item.shootSpeed = 15f;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Chlorophyte Kunai");
      Tooltip.SetDefault("Explodes into spore clouds on hit");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 150);
			recipe.AddRecipe();
		}
	}
}
