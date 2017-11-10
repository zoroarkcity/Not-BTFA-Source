using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.ItemSets.Essences.SoaringEssence 
{
	public class SoaringPistol : ModItem
	{
		int bullets = 0;
		int reloadtimer = 0;
		public override void SetDefaults()
		{

			item.damage = 10;
			item.ranged = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 10000;
			item.rare = 1;
			item.UseSound = SoundID.Item11;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.useAmmo =  AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soaring Pistol");
			Tooltip.SetDefault("Fires 6 bullets before reloading");
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			bullets++;
			if (bullets >= 6)
			{
				reloadtimer = 40;
				bullets = 0;
			}
			return true;
		}
		
		public override void HoldItem(Player player)
        {
			
			if (reloadtimer >= 0)
			{
				reloadtimer--;
			}
		}
		
		public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (reloadtimer >= 0)
                {
                    return false;
                }
            }
            return true;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SoaringEnergy", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(2, 0);
		}
	}
}
