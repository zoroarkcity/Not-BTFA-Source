using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Gelatine
{
	public class GelatineKunai : ModItem
	{

		public override void SetDefaults()
		{
			item.damage = 11;
			item.thrown = true;
			item.shoot = mod.ProjectileType("GelatineKunai");

			item.consumable = true;
			item.shootSpeed = 10f;
			item.useTime = 18;
			item.useAnimation = 18;
			item.consumable = true;
			item.maxStack = 999;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.value = 111;
			item.rare = 1;
			item.shootSpeed = 15f;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Gelatine Dagger");
      Tooltip.SetDefault("");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GelatineBar", 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 30);
			recipe.AddRecipe();
		}
	}
}
