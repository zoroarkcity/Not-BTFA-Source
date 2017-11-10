using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Gelatine 
{
public class GelatineSceptre : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 13;
        item.magic = true;

        item.width = 38;
        item.height = 38;
        item.useTime = 25;
        item.useAnimation = 25;
        item.useStyle = 5;
		Item.staff[item.type] = true;
        item.knockBack = 1;
        item.value = 40000;
        item.rare = 1;
        item.UseSound = SoundID.Item20;
		item.shoot = mod.ProjectileType("gelchunk");
		item.shootSpeed = 5f;
        item.autoReuse = true;
		item.mana = 10;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Gelatine Staff");
      Tooltip.SetDefault("Fires splitting chunks of gel");
    }

	
	
	public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GelatineBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
