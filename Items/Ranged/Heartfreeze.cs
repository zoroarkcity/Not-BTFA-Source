using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Ranged
{
	public class Heartfreeze : ModItem
	{

		public override void SetDefaults()
		{

			item.damage = 42;
			item.noMelee = true;
			item.ranged = true;
			item.width = 13;
			item.height = 28;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 5;
			item.shoot = 3;
			item.useAmmo = 40;
			item.knockBack = 1;
			item.value = 200000;
			item.rare = 5;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shootSpeed = 10f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Heartfreeze");
      Tooltip.SetDefault("Turns arrows into freezing arrows");
    }
	
	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-1, 0);
	}


		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == 1)
            {
                type = mod.ProjectileType("icearrow");
            }
			int f = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IceBow, 1);
			recipe.AddIngredient(null, "CryotineBow", 1);
			recipe.AddIngredient(ItemID.FrostCore, 3);
			recipe.AddIngredient(null,"CryotineBar", 18);
			recipe.AddTile(TileID.IceMachine);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
