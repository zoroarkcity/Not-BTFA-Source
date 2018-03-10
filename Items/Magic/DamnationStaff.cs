using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
	public class DamnationStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 39;
			item.magic = true;
			item.mana = 9;
			item.width = 25;
			item.height = 26;

			item.useTime = 13;
			item.UseSound = SoundID.Item20;
			item.useAnimation = 13;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 7;
			Item.staff[item.type] = true;
			item.value = 200000;
			item.rare = 5;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("hellorb");
			item.shootSpeed = 16f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Damnation Staff");
      Tooltip.SetDefault("Fires a beam of magma that creates embers");
    }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MagmaGlobStaff", 1);
			recipe.AddIngredient(null,"SinFlower", 1);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

		}
	}
}
