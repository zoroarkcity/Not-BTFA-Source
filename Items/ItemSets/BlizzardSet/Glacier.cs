using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.BlizzardSet 
{
	public class Glacier : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 11;
			item.melee = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 37;
			item.useAnimation = 37;
			item.useStyle = 1;
			item.knockBack = 3f;
			item.value = 5000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("IceCube");
			item.shootSpeed = 7f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Glacier");
      Tooltip.SetDefault("Launches a sliding ice cube");
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
