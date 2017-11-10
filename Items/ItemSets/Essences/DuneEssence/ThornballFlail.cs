using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.DuneEssence 
{
	public class ThornballFlail : ModItem
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
			item.useAnimation = 44;
			item.useTime = 44;
			item.shootSpeed = 8f;
			item.knockBack = 3.75f;
			item.damage = 16;
			item.value = 5000;
			item.rare = 1;
			item.shoot = mod.ProjectileType("ThornballFlail");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Thornball Flail");
      Tooltip.SetDefault("");
    }
	
	public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BossEnergy", 7);
			recipe.AddIngredient(ItemID.Cactus, 30);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}
