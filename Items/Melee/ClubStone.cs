using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee 
{
	public class ClubStone : ModItem
	{
		public override void SetDefaults()
		{


			item.damage = 19; 
			item.crit = 10;
			item.melee = true;
			item.knockBack = 5; 
			item.autoReuse = true; 
			item.useTurn = true; 

			item.width = 32;       
			item.height = 32;

			item.useTime = 65;
			item.useAnimation = 65;
			item.useStyle = 1;
			item.UseSound = SoundID.Item1;

			item.value = 1000;
			item.rare = 1;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stone Swing");
			Tooltip.SetDefault("'Reinforced with metal!'");
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 25);
			recipe.AddIngredient(ItemID.TinBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 25);
			recipe.AddIngredient(ItemID.CopperBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
