using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Boss 
{
	public class Unstable_Wisp : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 36;
			item.maxStack = 20;

			item.rare = 3;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Unstable Wisp");
		  Tooltip.SetDefault("Summons Acheron \nOnly useable in the underworld");
		}

		
		public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(mod.NPCType("Acheron")) && player.ZoneUnderworldHeight;
        }
		
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/Unstable_Wisp"),
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width * 0.5f,
					item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale, 
				SpriteEffects.None, 
				0f
			);
		}
		
		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Acheron"));
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarkSludge", 5);
			recipe.AddIngredient(null, "DarkEnergy", 3);
			recipe.AddIngredient(null, "BossEnergy", 3);
			recipe.AddIngredient(null, "SoaringEnergy", 3);
			recipe.AddIngredient(null, "UndeadEnergy", 3);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
