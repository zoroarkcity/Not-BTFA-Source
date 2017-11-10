using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;
using ForgottenMemories.Projectiles.InfoA;

namespace ForgottenMemories.Items.Ranged 
{
	public class PlanetaryShotblaser : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 124;
			item.ranged = true;
			item.width = 40;
			item.height = 14;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = 5;

			item.knockBack = 6;
			item.value = 1000000;
			item.rare = 10;
			item.UseSound = SoundID.Item36;
			item.autoReuse = true;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 21f;
			item.noMelee = true;
			item.useAmmo =  AmmoID.Bullet;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Planetary Shotgun");
      Tooltip.SetDefault("Hit bullets fire more bullets at the enemy");
    }

		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, 0);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TacticalShotgun, 1);
			recipe.AddIngredient(null,"FlameShotgun", 1);
			recipe.AddIngredient(null, "CosmodiumBar", 8);
			recipe.AddIngredient(3459, 12);
			recipe.AddIngredient(3457, 12);
			recipe.AddIngredient(3467, 10);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int amountOfProjectiles = Main.rand.Next(7, 9);
			for (int i = 0; i < amountOfProjectiles; i++)
			{
				float spX = speedX;
				float spY = speedY;
				spX += (float)Main.rand.Next(-40, 41) * 0.1f;
				spY += (float)Main.rand.Next(-40, 41) * 0.1f;
				int p = Projectile.NewProjectile(position.X, position.Y, spX, spY, type, damage, knockBack, player.whoAmI);
				Main.projectile[p].GetGlobalProjectile<Info>(mod).Planetary = true;
			}
			
			return false;
		}
	}
}
