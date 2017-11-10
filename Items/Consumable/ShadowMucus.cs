using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Consumable
{
	public class ShadowMucus: ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bottled Sludge");
			Tooltip.SetDefault("Lowers movement speed, but increases max life and defense \n'Smells and tastes awful'");
		}

		public override void SetDefaults()
		{
			item.buffType = mod.BuffType("MucusGuard");
			item.width = 20;
			item.height = 10;
			item.useStyle = 2;
			item.noUseGraphic = true;
			item.buffTime = 36000;
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
            recipe.AddIngredient(null, "DarkSludge", 1);
			recipe.AddIngredient(ItemID.Deathweed, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
