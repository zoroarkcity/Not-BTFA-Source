using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.Ammo 
{
	public class LightningArrow : ModItem
	{	
		public override void SetDefaults()
		{

			item.damage = 10;
			item.ranged = true;
			item.width = 22;
			item.height = 22;

			item.shootSpeed = 3f;
			item.shoot = mod.ProjectileType("LightningArrow");
			item.knockBack = 1.2f;
			item.UseSound = SoundID.Item1;
			item.value = 35;
			item.rare = 2;
			item.ammo = AmmoID.Arrow;
			item.maxStack = 999;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lightning Arrow");
			Tooltip.SetDefault("Moves somewhat randomly, but has insane velocity");
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(40, 333);
			recipe.AddIngredient(null, "DivineBolt", 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 333);
			recipe.AddRecipe();
		}
	}
}
