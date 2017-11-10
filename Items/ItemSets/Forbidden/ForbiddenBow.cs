using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Forbidden
{
	public class ForbiddenBow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 40;
			item.ranged = true;
			item.width = 40;
			item.height = 100;

			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 200000;
			item.rare = 6;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.useAmmo = 40;
			item.shoot = mod.ProjectileType("ForbiddenArrow");
			item.noMelee = true;
			item.shootSpeed = 8f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Forbidden Bow");
      Tooltip.SetDefault("Fires an exploding forbidden arrow");
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
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(1, 0);
		}


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			if (type == 1)
            {
                type = mod.ProjectileType("ForbiddenArrow");
            }
			Projectile.NewProjectile(player.Center.X, player.Center.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0, 0);
				
            return false;
        }
	}
}
