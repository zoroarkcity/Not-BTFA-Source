using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Forbidden
{
	public class ForbiddenStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 70;
			item.magic = true;
			item.width = 94;
			item.height = 94;
			item.useTime = 38;
			item.useAnimation = 38;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 200000;
			item.rare = 6;
			item.UseSound = SoundID.Item20;
			Item.staff[item.type] = true;
			item.autoReuse = true;
			item.mana = 15;
			item.shoot = mod.ProjectileType("ForbiddenStaffProj");
			item.noMelee = true;
			item.shootSpeed = 7f;
		}



    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Forbidden Staff");
      Tooltip.SetDefault("Fires an exploding forbidden bolt");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3783, 2);
			recipe.AddIngredient(ItemID.AdamantiteBar, 12);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(3783, 2);
			recipe.AddIngredient(ItemID.TitaniumBar, 12);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
