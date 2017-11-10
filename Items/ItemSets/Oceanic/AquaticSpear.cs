using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace ForgottenMemories.Items.ItemSets.Oceanic
{
	public class AquaticSpear : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 26;
			item.melee = true;
			item.width = 52;
			item.height = 52;
			item.scale = 1.1f;
			item.maxStack = 1;
			item.useTime = 25;
			item.useAnimation = 25;
			item.knockBack = 5f;
			item.UseSound = SoundID.Item1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useStyle = 5;
			item.value = 50000;
			item.rare = 3;
			item.shoot = mod.ProjectileType("AquaticSpear"); 
			item.shootSpeed = 9f;
			item.autoReuse = true;

		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Aquatic Hunting Spear");
      Tooltip.SetDefault("Has a chance to fire a bolt of water");
    }

	
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "WaterShard", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
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
	}
}
