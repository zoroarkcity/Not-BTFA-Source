using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Forbidden
{
	public class ForbiddenJavelin : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 38;
			item.thrown = true;
			item.width = 96;
			item.height = 88;

			item.useTime = 14;
			item.useAnimation = 14;
			item.consumable = true;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 666;
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ForbiddenJavelin");
			item.shootSpeed = 12f;
			item.noMelee = true;
            item.noUseGraphic = true;
			item.maxStack = 999;
		}



    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Forbidden Javelin");
      Tooltip.SetDefault("Throws an exploding javelin");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3783, 1);
			recipe.AddIngredient(ItemID.AdamantiteBar, 3);
			recipe.AddTile(134);
			recipe.SetResult(this, 150);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(3783, 1);
			recipe.AddIngredient(ItemID.TitaniumBar, 3);
			recipe.AddTile(134);
			recipe.SetResult(this, 150);
			recipe.AddRecipe();
		}
	}
}
