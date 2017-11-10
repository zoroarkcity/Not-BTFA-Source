using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.UndeadEssence
{
	public class BloodslashWand : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 20;
			item.magic = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.knockBack = 1;
			item.value = 30000;
			item.rare = 3;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("RedSlash");
			item.shootSpeed = 10f;
			item.mana = 7;
			item.noMelee = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Bloodneedler");
      Tooltip.SetDefault("Fires lifestealing needles");
    }

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "UndeadEnergy", 10);
			recipe.AddIngredient(ItemID.Bone, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
