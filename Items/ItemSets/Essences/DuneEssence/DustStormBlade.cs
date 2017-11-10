using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.DuneEssence 
{
	public class DustStormBlade : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 23;
			item.melee = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 5000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Sandstorm Blade");
      Tooltip.SetDefault("");
    }

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BossEnergy", 7);
			recipe.AddIngredient(ItemID.Cactus, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
