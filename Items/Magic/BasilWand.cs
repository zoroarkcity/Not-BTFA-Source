using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
	public class BasilWand : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 18;
			item.magic = true;
			item.mana = 10;
			item.width = 25;
			item.height = 26;
			item.useTime = 36;
			item.UseSound = SoundID.Item43;

			item.useAnimation = 36;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = 50000;
			item.rare = 1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("JungleBolt");
			item.shootSpeed = 7f;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Basil Wand");
		  Tooltip.SetDefault("Fires a bolt that creates damaging spores");
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RichMahogany, 18);
			recipe.AddIngredient(ItemID.JungleSpores, 8);
			recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
