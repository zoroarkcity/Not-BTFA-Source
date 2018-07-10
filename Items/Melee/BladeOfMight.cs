using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Melee
{
	public class BladeOfMight : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 85;
			item.melee = true;
			item.width = 62;
			item.height = 70;
			item.useTime = 36;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.sellPrice(0, 12, 50, 0);
			item.rare = 5;
			item.shoot = mod.ProjectileType("MightBeam");
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 13f;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Champion's Claymore");
		  Tooltip.SetDefault("Fires an explosive sword beam");
		  BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/BladeOfMight");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/BladeOfMight"),
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
		}/////////////////////////////////////////////////////////WORLD GLOWMASK///////////////////////////


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofMight, 20);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(6) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 29);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].scale = 1.2f;
			}
		}
	}
}
