using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee 
{
	public class MarbleKatana : ModItem
	{
		public override void SetDefaults()
		{


			item.damage = 26; 
			item.crit = 8;
			item.melee = true;
			item.knockBack = 4; 
			item.autoReuse = true; 
			item.useTurn = true; 

			item.width = 32;       
			item.height = 32;

			item.useTime = 15;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.UseSound = SoundID.Item1;

			item.value = 1000;
			item.rare = 3;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Marble Katana");
			Tooltip.SetDefault("Hitting an enemy increases your defense by 8");
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			player.AddBuff(mod.BuffType("MarbleBlock"), 3 * 60);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MarbleBlock, 20);
			recipe.AddIngredient(null, "Citrine", 8);
			recipe.AddIngredient(null, "BossEnergy", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
