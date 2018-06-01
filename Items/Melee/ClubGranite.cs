using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee 
{
	public class ClubGranite : ModItem
	{
		public override void SetDefaults()
		{


			item.damage = 28; 
			item.crit = 18;
			item.melee = true;
			item.knockBack = 11; 
			item.autoReuse = true; 
			item.useTurn = true; 

			item.width = 32;       
			item.height = 32;

			item.useTime = 42;
			item.useAnimation = 42;
			item.useStyle = 1;
			item.UseSound = SoundID.Item1;

			item.value = 1000;
			item.rare = 2;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Clobber");
			Tooltip.SetDefault("'Igneous energy seeps into you'");
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GraniteBlock, 25);
			recipe.AddIngredient(null, "Tourmaline", 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
