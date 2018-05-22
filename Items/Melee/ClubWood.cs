using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee 
{
	public class ClubWood : ModItem
	{
		public override void SetDefaults()
		{


			item.damage = 9; 
			item.crit = 13;
			item.melee = true;
			item.knockBack = 8; 
			item.autoReuse = true; 
			item.useTurn = true; 

			item.width = 32;       
			item.height = 32;

			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.UseSound = SoundID.Item1;

			item.value = 1000;
			item.rare = 0;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wooden Club");
			Tooltip.SetDefault("'Great for ball games and slaughtering slimes!'");
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 40);
			recipe.AddIngredient(ItemID.Cobweb, 15);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
