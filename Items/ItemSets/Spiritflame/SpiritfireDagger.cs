using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.ItemSets.Spiritflame
 {
	public class SpiritfireDagger : ModItem
	{
		
		public override void SetDefaults()
		{

			item.damage = 51;
			item.thrown = true;
			item.noMelee = true;
			item.noUseGraphic = true;

			item.width = 22;
			item.height = 22;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.shootSpeed = 13f;
			item.shoot = mod.ProjectileType("SpiritfireDagger");
			item.knockBack = 1;
			item.UseSound = SoundID.Item1;
			item.value = 500;
			item.rare = 4;
			item.consumable = true;
			item.maxStack = 999;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Spiritfire Dagger");
		  Tooltip.SetDefault("Ricochets off of tiles, exploding into ghastly fire");
		  BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/SpiritfireDagger");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/SpiritfireDagger"),
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
		}////////////
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SpiritflameChunk", 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 75);
            recipe.AddRecipe();
        }

	}
}
