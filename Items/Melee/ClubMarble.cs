using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee 
{
	public class ClubMarble : ModItem
	{
		public override void SetDefaults()
		{


			item.damage = 32; 
			item.crit = 12;
			item.melee = true;
			item.knockBack = 8; 
			item.autoReuse = true; 
			item.useTurn = true; 

			item.width = 32;       
			item.height = 32;

			item.useTime = 38;
			item.useAnimation = 38;
			item.useStyle = 1;
			item.UseSound = SoundID.Item1;

			item.value = 1000;
			item.rare = 2;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Marble Mace");
			Tooltip.SetDefault("'Coated with a gorgon's blood'");
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MarbleBlock, 25);
			recipe.AddIngredient(null, "Citrine", 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
