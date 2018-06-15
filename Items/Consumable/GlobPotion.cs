using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Consumable
{
	public class GlobPotion: ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Globule Potion");
			Tooltip.SetDefault("Ranged attacks may explode into 2 nightly globules");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 10;
			item.useStyle = 2;
			item.noUseGraphic = true;
            item.buffType = mod.BuffType("NightGlob");
            item.buffTime = 15000;
			item.UseSound = SoundID.Item3;
			item.useTime = 10;
			item.useAnimation = 10;
			item.consumable = true;
			item.value = 1000;
			item.rare = 1;
			item.maxStack = 999;
		}
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(null, "DarkEnergy", 3);
			recipe.AddIngredient(ItemID.Mushroom, 3);
			recipe.AddIngredient(ItemID.Waterleaf, 2);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
