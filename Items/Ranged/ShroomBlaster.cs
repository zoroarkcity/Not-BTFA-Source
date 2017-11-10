using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories.Projectiles.InfoA;

namespace ForgottenMemories.Items.Ranged
{
	public class ShroomBlaster : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 26;
			item.ranged = true;
			item.width = 23;
			item.height = 13;

			item.useTime = 33;
			item.useAnimation = 33;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; 
			item.shootSpeed = 6f;
			item.useAmmo = AmmoID.Bullet;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Shroom Blaster");
      Tooltip.SetDefault("Bullets fired release spore gas clouds");
    }

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 4; ++i)
			{
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-50, 50) * 0.02f;
				sY += (float)Main.rand.Next(-50, 50) * 0.02f;
				int p = Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
				Main.projectile[p].GetGlobalProjectile<Info>(mod).Shroom = true;
			}
			return false;
		}


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1552, 18);
			recipe.AddIngredient(324, 2);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(4, 0);
		}
    }
}
