using System;
using System.Collections.Generic;
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
namespace ForgottenMemories.Items.ItemSets.Cosmorock
{
	public class CosmosKunai : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 49;
			item.thrown = true;
			item.shoot = mod.ProjectileType("CosmosKunai");

			item.consumable = true;
			item.knockBack = 3f;
			item.shootSpeed = 12f;
			item.useTime = 9;
			item.useAnimation = 9;
			item.consumable = true;
			item.maxStack = 999;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.value = Item.sellPrice(0, 0, 0, 42);
			item.rare = 6;
			item.shootSpeed = 11f;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmos Kunai");
			Tooltip.SetDefault("Throw an endless slew of rebounding explosive kunai");
			BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/CosmosKunai");
		}
		
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/CosmosKunai"),
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

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 speed = new Vector2(speedX, speedY).RotatedBy(MathHelper.ToRadians(Main.rand.Next(-8, 9)));
			speedX = speed.X;
			speedY = speed.Y;
			
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SpaceRockFragment", 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 99);
			recipe.AddRecipe();
		}
	}
}
