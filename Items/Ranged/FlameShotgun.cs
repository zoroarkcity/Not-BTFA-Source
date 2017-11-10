using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Ranged 
{
	public class FlameShotgun : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 20;
			item.ranged = true;
			item.width = 40;
			item.height = 14;
			item.useTime = 44;
			item.useAnimation = 44;
			item.useStyle = 5;

			item.knockBack = 6;
			item.value = 250000;
			item.rare = 5;
			item.UseSound = SoundID.Item36;
			item.autoReuse = true;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 19f;
			item.noMelee = true;
			item.useAmmo =  AmmoID.Bullet;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Flame Shotgun");
      Tooltip.SetDefault("Fires flaming bullets");
    }

		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, 0);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Shotgun, 1);
			recipe.AddIngredient(ItemID.HellstoneBar, 15);
			recipe.AddIngredient(null,"DevilFlame", 15);
			recipe.AddIngredient(521, 12); //Soul of Night
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 5; i++)
			{
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-60, 61) * 0.04f;
				sY += (float)Main.rand.Next(-60, 61) * 0.04f;
				int p = Projectile.NewProjectile(position.X, position.Y, sX, sY, mod.ProjectileType("Flambullet"), damage, knockBack, player.whoAmI); 
			}
			return false;
		}
	}
}
