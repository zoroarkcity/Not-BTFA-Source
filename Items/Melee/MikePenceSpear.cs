using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee 
{
	public class MikePenceSpear : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 41;  //The width of the .png file in pixels divided by 2.
			item.damage = 28;  //Any post BOC weapon doing 9 damage.
			item.melee = true;  //Dictates whether this is a melee-class weapon.
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useAnimation = 30;

			item.useStyle = 5;
			item.useTime = 30;
			item.knockBack = 9.5f;  //Ranges from 1 to 9.
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;  //Dictates whether the weapon can be "auto-fired".
			item.height = 41;  //The height of the .png file in pixels divided by 2.
			item.maxStack = 1;
			item.value = 60000;  //Value is calculated in copper coins.
			item.rare = 2;  //Ranges from 1 to 11.
			item.shoot = mod.ProjectileType("MikePenceSpear");
			item.shootSpeed = 7;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Electroshocker");
      Tooltip.SetDefault("Creates electricity on hit that chains from enemy to enemy");
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
			recipe.AddIngredient(null, "DivineBolt", 1);
			recipe.AddIngredient(ItemID.CopperBar, 10);
			recipe.AddIngredient(ItemID.MeteoriteBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DivineBolt", 1);
			recipe.AddIngredient(ItemID.TinBar, 10);
			recipe.AddIngredient(ItemID.MeteoriteBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
