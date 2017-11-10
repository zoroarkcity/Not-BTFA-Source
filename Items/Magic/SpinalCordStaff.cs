using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
	public class SpinalCordStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 19;
			item.magic = true;
			item.mana = 12;
			item.width = 25;
			item.height = 26;
			item.useTime = 39;
			item.UseSound = SoundID.Item20;

			item.useAnimation = 39;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 7;
			item.value = 50000;
			item.rare = 1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SpinalBolt");
			item.shootSpeed = 5f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Bloodbath Wand");
      Tooltip.SetDefault("Inflicts devils flame, creates blood fountains on hit");
    }
	
	public override void AddRecipes()
	{
		ModRecipe recipe = new ModRecipe(mod);
		recipe.AddIngredient(null,"DevilFlame", 15);
		recipe.AddIngredient(ItemID.CrimtaneBar, 10);
		recipe.AddTile(TileID.Anvils);
		recipe.SetResult(this);
		recipe.AddRecipe();
	}

	}
}
