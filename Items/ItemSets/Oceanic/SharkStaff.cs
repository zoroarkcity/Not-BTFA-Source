using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Oceanic
{
	public class SharkStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 22;
			item.magic = true;
			item.width = 19;
			item.height = 19;
			item.mana = 8;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.noMelee = true;
			Item.staff[item.type] = true;
			item.knockBack = 1;
			item.value = 50000;
			item.rare = 3;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("OceanBolt");
			item.shootSpeed = 10f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ocean Staff");
      Tooltip.SetDefault("");
    }

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "WaterShard", 5);
			recipe.AddIngredient(ItemID.SharkFin, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
