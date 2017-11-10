using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Spiritflame
 {
	public class SpiritfireDagger : ModItem
	{
		
		public override void SetDefaults()
		{

			item.damage = 41;
			item.thrown = true;
			item.noMelee = true;
			item.noUseGraphic = true;

			item.width = 22;
			item.height = 22;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.shootSpeed = 13f;
			item.shoot = mod.ProjectileType("SpiritfireDagger");
			item.knockBack = 1;
			item.UseSound = SoundID.Item1;
			item.value = 500;
			item.rare = 4;
			item.consumable = true;
			item.maxStack = 999;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Spiritfire Dagger");
		  Tooltip.SetDefault("Ricochets off of tiles, exploding into ghastly fire");
		}
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SpiritflameChunk", 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 75);
            recipe.AddRecipe();
        }

	}
}
