using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Ranged
{
	public class NightmareWrath : ModItem
	{
		int counter = 0;
		public override void SetDefaults()
		{

			item.damage = 42;
			item.ranged = true;
			item.width = 27;
			item.height = 54;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 500000;
			item.rare = 6;
			item.useAmmo = 40;
			item.UseSound = SoundID.Item5;

			item.shoot = 3;
			item.shootSpeed = 8f;
			item.noMelee = true;
			item.autoReuse = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Nightmare Wrath");
      Tooltip.SetDefault("Fires exploding arrows, fires faster when below half life");
    }
	
	public override bool CanUseItem(Player player)
		{
			if (player.statLife >= player.statLifeMax2/2)
			{
				item.useTime = 28;
				item.useAnimation = 28;
			}
			else
			{
				item.useTime = 19;
				item.useAnimation = 19;
			}
			return base.CanUseItem(player);
		}

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == 1)
            {
                type = mod.ProjectileType("WrathArrow");
            }
			Vector2 origVect = new Vector2(speedX, speedY);
			Vector2 thing1 = position;
			Vector2 thing2 = position;
			thing1 += origVect.RotatedBy(-1.57079637050629, new Vector2()) * 0.9f;
            thing2 += origVect.RotatedBy(1.57079637050629, new Vector2()) * 0.9f;
			int f = Projectile.NewProjectile(position.X + speedX, position.Y + speedY, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Main.projectile[f].noDropItem = true;
			int a = Projectile.NewProjectile(thing1.X, thing1.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Main.projectile[a].noDropItem = true;
			int g = Projectile.NewProjectile(thing2.X, thing2.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Main.projectile[g].noDropItem = true;
			
			return false;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Galactica", 1);
			recipe.AddIngredient(null, "BlightedBow", 1);
			recipe.AddIngredient(null, "SubmergedAshes", 1);
			recipe.AddIngredient(547, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
