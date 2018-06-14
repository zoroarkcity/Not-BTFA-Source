using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.ItemSets.Essences.NightlyEssence
{
public class NightlyHammer : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 10;
        item.melee = true;
        item.width = 22;
        item.height = 24;
        item.useTime = 17;
        item.useAnimation = 29;
        item.useStyle = 1;
        item.knockBack = 1.5f;
        item.value = 14000;
        item.rare = 1;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
		item.hammer = 45;
		item.useTurn = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Nightly Hammer");
      Tooltip.SetDefault("");
    }

	
	
	public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"DarkEnergy", 8);
			recipe.AddIngredient(ItemID.Silk, 3);
			recipe.AddRecipeGroup("AnyCopper", 4);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 65);
			}
		}
}
}
