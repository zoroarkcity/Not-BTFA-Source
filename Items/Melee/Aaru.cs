using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee 
{
	public class Aaru : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
			Tooltip.SetDefault("'Forged in Ra's crypt'");
		}

		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.width = 24;
			item.height = 24;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("AaruProj");
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 8f;
			item.knockBack = 4f;
			item.damage = 33;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = 4;
		}
			
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Olympus", 1);
			recipe.AddIngredient(null, "Valhalla", 1);
			recipe.AddIngredient(null, "Atlantean", 1);
		    recipe.AddIngredient(null, "DevilFlame", 8);
			recipe.AddIngredient(ItemID.Amber, 3);
		    recipe.AddIngredient(null, "Spinel", 3);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
