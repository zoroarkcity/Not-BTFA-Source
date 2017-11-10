using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.SoaringEssence
{
	public class SoaringTrident : ModItem
	{

		public override void SetDefaults()
		{
			item.damage = 19;
			item.thrown = true;
			item.shoot = mod.ProjectileType("SoaringTrident");
			item.consumable = true;
			item.shootSpeed = 10f;
			item.useTime = 19;
			item.useAnimation = 19;
			item.maxStack = 999;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.value = 20;
			item.rare = 1;
			item.shootSpeed = 19f;
			item.UseSound = SoundID.Item1;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Soaring Trident");
		  Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SoaringEnergy", 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}
