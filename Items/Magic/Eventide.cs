using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Magic
{
	public class Eventide : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 44;
			item.magic = true;
			item.mana = 18;
			item.width = 25;
			item.height = 26;
			item.useTime = 24;
			item.UseSound = SoundID.Item117;

			item.useAnimation = 24;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = 650000;
			item.rare = 4;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("VoidBolt");
			item.shootSpeed = 9f;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Eventide");
		  Tooltip.SetDefault("Fires a bolt of void energy that creates a singularity on impact");
		  BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/Eventide");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/Eventide"),
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
			recipe.AddIngredient(null, "BasilWand", 1);
			recipe.AddIngredient(null, "WhiteGraniteScepter", 1);
			recipe.AddIngredient(null, "MagmaGlobStaff", 1);
			recipe.AddIngredient(null, "CursedEnticer", 1);
			recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BasilWand", 1);
			recipe.AddIngredient(null, "WhiteGraniteScepter", 1);
			recipe.AddIngredient(null, "MagmaGlobStaff", 1);
			recipe.AddIngredient(null, "SpinalCordStaff", 1);
			recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
