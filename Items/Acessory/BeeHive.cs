using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.Acessory 
{
	public class BeeHive : ModItem
	{
		
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.shootSpeed = 3f;
			item.shoot = 469;
			item.knockBack = 1;
			item.UseSound = SoundID.Item1;
			item.value = 1100000;
			item.rare = 8;
			item.maxStack = 1;
			item.consumable = false;
			item.expert = true;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Bee Hive");
		  Tooltip.SetDefault("Taking damage releases powerful bees and wasps, and temporarily increases life regen");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.strongBees = true;
			((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).BeeHive = true;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BeeWax, 20);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddIngredient(ItemID.HoneyComb, 1);
			recipe.AddIngredient(3333, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
