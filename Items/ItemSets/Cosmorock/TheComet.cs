using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Cosmorock
{
	public class TheComet : ModItem
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
			item.damage = 45;
			item.value = 200000;
			item.rare = 6;
			item.maxStack = 1;
			item.shoot = mod.ProjectileType("TheComet");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("The Comet");
      Tooltip.SetDefault("Explodes on hit, has high velocity");
    }

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SpaceRockFragment", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
