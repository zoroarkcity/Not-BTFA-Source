using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory
{
	public class ManaShard : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 20;
			item.accessory = true;
			item.maxStack = 1;
			item.value = 10000;
			item.rare = 8;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Arcane Shard");
		  Tooltip.SetDefault("Increases mana obtained from mana stars \nPicking up mana stars temporarily increases magic damage \n'A fragment of concentrated magic'");
		  Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 8));
		}
	
		public override void Update(ref float gravity, ref float maxFallSpeed)
		{
			maxFallSpeed = 0f;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).ManaShard = true;
        }
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ManaCrystal, 3);
			recipe.AddIngredient(ItemID.CrystalShard, 10);
            recipe.AddIngredient(ItemID.Ectoplasm, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
