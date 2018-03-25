using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Ranged
{
	public class Hadron : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.useAnimation = 40;
			item.useTime = 40;
			item.shootSpeed = 40f;
			item.knockBack = 2f;
			item.width = 20;
			item.reuseDelay = 20;
			item.height = 12;
			item.damage = 50;
			//item.UseSound = SoundID.Item13;
			item.shoot = mod.ProjectileType("Hadron_Held");
			item.rare = 10;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.noMelee = true;
			item.noUseGraphic = true;
			item.ranged = true;
			item.channel = true;
			item.useAmmo = AmmoID.Bullet;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Hadron");
		  Tooltip.SetDefault("Fires a chain of luminite bullets and void missiles \nIncreases in firing speed, velocity, and damage over time \n'Infused with lunar and dark energies'");
		}
		
		public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
		protected int dustTimer = 0;
		public override void HoldItem (Player player)	
		{
			if (player.channel)
			{
				dustTimer++;
			}
			if (dustTimer >= 30)
			{
				dustTimer = 0;
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.OnyxBlaster, 1);
			recipe.AddIngredient(ItemID.VortexBeater, 1);
			recipe.AddIngredient(ItemID.LunarBar, 20);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("Hadron_Held"), damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("Hadron_Missile"), damage*3, knockBack, player.whoAmI);
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 70f;	
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return false;
		}
	}
}
