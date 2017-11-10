using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee 
{
	public class IchorLance : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 65;  
			item.damage = 59;  
			item.melee = true;  
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.useTime = 10;
			item.knockBack = 2.5f;  
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;  
			item.height = 96;  
			item.maxStack = 1;
			item.value = 300000;  
			item.rare = 7;  
			item.shoot = mod.ProjectileType("IchorLanceProjectile");
			item.shootSpeed = 7;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ichoric Impaler");
      Tooltip.SetDefault("Hitting enemies steals life and launches ichor streams");
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
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(1228, 1);
			recipe.AddIngredient(ItemID.Ichor, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
