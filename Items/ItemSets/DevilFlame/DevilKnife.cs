using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.DevilFlame
{
	public class DevilKnife : ModItem
	{

		public override void SetDefaults()
		{
			item.damage = 15;
			item.thrown = true;
			item.shoot = mod.ProjectileType("DevilKnife");

			item.consumable = true;
			item.shootSpeed = 10f;
			item.useTime = 22;
			item.useAnimation = 22;
			item.consumable = true;
			item.maxStack = 999;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.value = 20;
			item.rare = 1;
			item.shootSpeed = 15f;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Devil's Knife");
		  Tooltip.SetDefault("Has a chance to create a living flame when destroyed");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DevilFlame", 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}
