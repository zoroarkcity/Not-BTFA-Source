using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.Tool 
{
	public class MeteorPickaxe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 12;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 19;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 15000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.pick = 55;
			item.useTurn = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Meteor Pickaxe");
      Tooltip.SetDefault("");
    }

		
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(117, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
