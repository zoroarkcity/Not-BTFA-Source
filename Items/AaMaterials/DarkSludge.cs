using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class DarkSludge : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 8;
			item.height = 8;
			item.maxStack = 999;

			item.value = 18000;
			item.rare = 1;

        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Dark Sludge");
      Tooltip.SetDefault("'Smells and looks disgusting'");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DarkEnergy", 2);
			recipe.AddIngredient(null, "GelatineBar", 2);
			recipe.AddIngredient(ItemID.TissueSample, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 3);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DarkEnergy", 2);
			recipe.AddIngredient(null, "GelatineBar", 2);
			recipe.AddIngredient(ItemID.ShadowScale, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 3);
            recipe.AddRecipe();
        }
    }
}
