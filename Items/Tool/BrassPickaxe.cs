using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.Tool {
public class BrassPickaxe : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 15;
        item.melee = true;
        item.width = 22;
        item.height = 24;
        item.useTime = 15;
        item.useAnimation = 23;
        item.useStyle = 1;
        item.knockBack = 1;
        item.value = 10000;
        item.rare = 4;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
		item.pick = 105;
		item.useTurn = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Brass Pickaxe");
      Tooltip.SetDefault("");
    }

	
	
	public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BrassAlloy", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
}}
