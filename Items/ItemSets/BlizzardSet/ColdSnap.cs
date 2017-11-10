using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.BlizzardSet
{
	public class ColdSnap : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 6;
			item.magic = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 10;
			item.useAnimation = 10;
			item.reuseDelay = 12;
			item.channel = true;
			item.useStyle = 5;
			item.knockBack = 0f;
			item.value = 5000;
			item.rare = 1;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;

			item.useTurn = true;
			item.shoot = mod.ProjectileType("ColdSnap");
			item.shootSpeed = 0f;
			item.mana = 3;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cold Snap");
      Tooltip.SetDefault("Creates an expanding area of ice around you");
    }

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Galeshard", 14);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
