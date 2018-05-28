using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.ItemSets.Cryotine {
public class CryotinePickaxe : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 18;
        item.melee = true;
        item.width = 28;
        item.height = 28;
        item.useTime = 13;
        item.useAnimation = 13;
        item.useStyle = 1;
        item.knockBack = 1;
        item.value = 16800;
        item.rare = 2;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
		item.pick = 90;
		item.useTurn = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cryotine Pickaxe");
      Tooltip.SetDefault("");
    }

	
	public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 67);
			}
		}
	
	
	public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CryotineBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
}}
