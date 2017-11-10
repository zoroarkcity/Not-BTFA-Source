using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Gelatine 
{
public class GelatineBlade : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 15;
        item.melee = true;
        item.width = 28;
        item.height = 28;
        item.useTime = 20;
        item.useAnimation = 20;
        item.useStyle = 1;
        item.knockBack = 1;
        item.value = 40000;
        item.rare = 1;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
		item.useTurn = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Gelatine Blade");
      Tooltip.SetDefault("");
    }

	
	
	public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GelatineBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Gelled"), 120, false);
		}
}
}
