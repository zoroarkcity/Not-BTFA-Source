using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Ranged
{
public class NightGelStabilizer : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 20;
        item.ranged = true;
        item.width = 50;
        item.height = 50;
        item.useTime = 13;
        item.useAnimation = 13;
        item.useStyle = 5;
        item.knockBack = 5;
        item.value = 20000;
        item.rare = 2;
        item.UseSound = SoundID.Item13;
        item.autoReuse = true;
		item.shoot = mod.ProjectileType("DarkGelShot");
		item.shootSpeed = 15f;
		item.noMelee = true;
        item.scale = 0.9f;
		item.useAmmo = AmmoID.Gel;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Night Gel Stabilizer");
      Tooltip.SetDefault("Uses gel as ammo");
    }

	
	public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DarkSludge", 10);
			recipe.AddTile(16);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	
	public override Vector2? HoldoutOffset()
		{
			return new Vector2(2, 0);
		}
}
}
