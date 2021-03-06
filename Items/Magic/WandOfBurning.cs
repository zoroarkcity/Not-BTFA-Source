using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
	public class WandOfBurning : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 21;
			item.magic = true;
			item.mana = 9;
			item.width = 25;
			item.height = 26;
			item.useTime = 28;
			item.UseSound = SoundID.Item20;

			item.useAnimation = 28;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 50000;
			item.rare = 3;
			item.autoReuse = true;
			item.shoot = 504;
			item.shootSpeed = 11f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Wand Of Burning");
      Tooltip.SetDefault("Has a chance to fire a splitting spark");
    }

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3069, 1);
			recipe.AddIngredient(ItemID.Bone, 5);
			recipe.AddIngredient(null, "DevilFlame", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i <= 3; i++)
			{
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-60, 61) * 0.05f;
				sY += (float)Main.rand.Next(-60, 61) * 0.05f;
				Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
			}
			
			if (Main.rand.Next(2) == 0)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BigSpark"), damage, knockBack, player.whoAmI);
			}
			return false;
		}
	}
}