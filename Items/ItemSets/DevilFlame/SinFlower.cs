using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.DevilFlame
{
	public class SinFlower : ModItem
	{
		float memer = 0f;
		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.useAnimation = 20;
			item.useTime = 20;
			item.shootSpeed = 14f;
			item.knockBack = 2f;
			item.width = 16;
			item.height = 16;
			item.damage = 15;
			item.UseSound = SoundID.Item13;
			item.shoot = mod.ProjectileType("SinFlower");
			item.mana = 7;
			item.value = 50000;
            item.rare = 1;
			item.noMelee = true;
			Item.staff[item.type] = true;
			item.noUseGraphic = true;
			item.magic = true;
			item.channel = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Staff of Sins");
		  Tooltip.SetDefault("Fires a chargeable flame geyser \nHolding left click will charge the weapon, release to shoot \nCharging will increase the geyser's power");
		}
	
	
	public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"DevilFlame", 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
