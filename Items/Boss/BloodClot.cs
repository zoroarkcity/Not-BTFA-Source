using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Boss 
{
	public class BloodClot : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 32;
			item.maxStack = 20;

			item.rare = 3;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.consumable = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Bleeding Residue");
      Tooltip.SetDefault("'Has a strong enough stench to attract a horrific being...' \nOnly usable during night");
    }

		
		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(mod.NPCType("FaceOfInsanity")) && !Main.dayTime;
		}
		
		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("FaceOfInsanity"));
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 2);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddIngredient(2887, 5);
			recipe.AddIngredient(ItemID.Vertebrae, 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddIngredient(60, 5);
			recipe.AddIngredient(ItemID.RottenChunk, 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
