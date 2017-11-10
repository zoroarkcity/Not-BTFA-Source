using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.DuneEssence
{
	public class NomadsPartisan : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 16;
			item.melee = true;
			item.width = 52;
			item.height = 52;
			item.scale = 1.1f;
			item.maxStack = 1;
			item.useTime = 30;
			item.useAnimation = 30;
			item.knockBack = 5f;
			item.UseSound = SoundID.Item1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useStyle = 5;
			item.value = 5000;
			item.rare = 1;
			item.shoot = mod.ProjectileType("NomadsPartisan"); 
			item.shootSpeed = 9f;
			item.autoReuse = true;

		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Nomad's Partisan");
      Tooltip.SetDefault("");
    }

	
	public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BossEnergy", 6);
			recipe.AddIngredient(ItemID.Cactus, 25);
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
