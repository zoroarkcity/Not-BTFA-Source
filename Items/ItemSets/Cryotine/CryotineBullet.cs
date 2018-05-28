using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Cryotine {
public class CryotineBullet : ModItem
{
	
    public override void SetDefaults()
    {

        item.damage = 10;
        item.ranged = true;
        item.width = 22;
        item.height = 22;

		item.shootSpeed = 5f;
		item.shoot = mod.ProjectileType("CryotineBulletP");
        item.knockBack = 3.25f;
		item.UseSound = SoundID.Item1;
		item.scale = 1f;
        item.value = 140;
        item.rare = 2;
		item.consumable = true;
		item.maxStack = 999;
        item.ammo = AmmoID.Bullet;
	}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cryotine Bullet");
      Tooltip.SetDefault("Inflicts Frostburn");
    }

		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CryotineBar", 1);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}
