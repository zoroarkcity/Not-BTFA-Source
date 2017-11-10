using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class HeartKatana : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 24;
			item.crit = 26;
			item.melee = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 30000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;

			item.autoReuse = true;
			item.useTurn = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Heart Katana");
      Tooltip.SetDefault("Critical strikes restore health");
    }

		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (crit)
			{
				player.HealEffect((int)(damage * 0.05));
				player.statLife += (int)(damage * 0.05);
			}
		}	
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 10);
			recipe.AddIngredient(ItemID.TissueSample, 7);
			recipe.AddIngredient(ItemID.Katana, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 10);
			recipe.AddIngredient(ItemID.ShadowScale, 7);
			recipe.AddIngredient(ItemID.Katana, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
