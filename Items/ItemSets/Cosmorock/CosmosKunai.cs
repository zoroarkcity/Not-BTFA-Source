using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Cosmorock
{
	public class CosmosKunai : ModItem
	{

		public override void SetDefaults()
		{
			item.damage = 42;
			item.thrown = true;
			item.shoot = mod.ProjectileType("CosmosKunai");

			item.consumable = true;
			item.shootSpeed = 12f;
			item.useTime = 12;
			item.useAnimation = 12;
			item.consumable = true;
			item.maxStack = 999;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.value = 208;
			item.rare = 6;
			item.shootSpeed = 11f;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cosmos Kunai");
      Tooltip.SetDefault("");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SpaceRockFragment", 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 80);
			recipe.AddRecipe();
		}
	}
}
