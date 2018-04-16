using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.ItemSets.Titan
{
	public class LaserbeamStaff : ModItem
	{
		float memer = 0f;
		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.useAnimation = 20;
			item.useTime = 20;
			item.shootSpeed = 14f;
			item.knockBack = 2f;
			item.width = 16;
			item.height = 16;
			item.damage = 50;
			item.UseSound = SoundID.Item13;
			item.shoot = mod.ProjectileType("LaserbeamStaff");
			item.mana = 14;
			item.value = 50000;
            item.rare = 6;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.magic = true;
			item.channel = true;
		}

		public override void SetStaticDefaults()
		{	
			DisplayName.SetDefault("Laserbeam Staff");
			Tooltip.SetDefault("Holding the Left Click will charge the weapon");
			BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/LaserbeamStaff");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/LaserbeamStaff"),
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
	}
}
