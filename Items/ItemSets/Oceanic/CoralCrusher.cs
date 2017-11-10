using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Oceanic
{
	public class CoralCrusher : ModItem
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
			item.useAnimation = 16;
			item.useTime = 16;
			item.shootSpeed = 13f;
			item.knockBack = 3.75f;
			item.damage = 22;
			item.value = 50000;
			item.rare = 3;
			item.shoot = mod.ProjectileType("AquaBall");
			item.autoReuse = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Aqua Flail");
      Tooltip.SetDefault("");
    }
	
	public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "WaterShard", 6);
			recipe.AddIngredient(ItemID.SharkFin, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}
