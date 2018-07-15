using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;

namespace ForgottenMemories.Items.ItemSets.Barksteel_Set.Rindblade_Spear
{
	public class Rindblade_Spear : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rindblade Spear");
			Tooltip.SetDefault("Left-click to thrust your pike\nRight Click to throw your pike\nUpon throwing your spear to a tile it gets stuck\nAfter getting near it, you and your allies will gain 8 defense bonus");
        }
		public override void SetDefaults()
		{
			item.consumable = false;
			item.maxStack = 1;
			item.noMelee = true;
            item.damage = 12;
			item.useStyle = 5;
			item.useAnimation = 28;
			item.useTime = 28;
			item.shootSpeed = 3.1f;
			item.width = 32;
			item.knockBack = 2f;
			item.value = 12000;
			item.height = 32;
			item.scale = 1f;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("PikeSpear");
			item.melee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = true;
		}
	
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.shoot = mod.ProjectileType("PikeThrown");
				item.shootSpeed = 16f;
				item.damage = 8;
				item.useStyle = 1;
				item.UseSound = SoundID.Item1;
				item.useAnimation = 28;
				item.useTime = 28;
				item.noMelee = true;
				item.width = 26;
				item.knockBack = 2f;
				item.height = 26;
				item.maxStack = 1;
				item.shootSpeed = 8f;
				item.consumable = true;
				item.noUseGraphic = true;
				item.melee = true;
				item.autoReuse = false;
				item.rare = 2;
			}
			else
			{
				item.consumable = false;
				item.damage = 12;
				item.useStyle = 5;
				item.useAnimation = 28;
				item.useTime = 28;
				item.shootSpeed = 3.1f;
				item.maxStack = 1;
				item.noMelee = true;
				item.width = 32;
				item.knockBack = 2f;
				item.height = 32;
				item.scale = 1f;
				item.rare = 2;
				item.UseSound = SoundID.Item1;
				item.shoot = mod.ProjectileType("PikeSpear");
				item.melee = true; 
				item.noUseGraphic = true; 
				item.autoReuse = true; 
				return player.ownedProjectileCounts[item.shoot] < 1; 
			}
			for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == mod.ProjectileType("PikeTotem"))
                {
                    return false;
                }
            }		
			return base.CanUseItem(player);
		}
		public override void AddRecipes()
		{
		    ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Barksteel", 7);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}
