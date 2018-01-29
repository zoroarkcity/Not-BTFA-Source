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

namespace ForgottenMemories.Items.ItemSets.Titan
{
	public class TitanicCrusher : ModItem
	{
		public override void SetDefaults()
		{

			item.useStyle = 5;
			item.width = 24;
			item.height = 24;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.useAnimation = 44;
			item.useTime = 44;
			item.shootSpeed = 16f;
			item.knockBack = 3.75f;
			item.damage = 58;
			item.value = 140000;
			item.rare = 5;
			item.shoot = mod.ProjectileType("TitanicCrusher");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titanic Crusher");
			Tooltip.SetDefault("Rends enemy defense and deals some damage over time on hit \nHitting an enemy releases damaging spheres");
			BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/TitanicCrusher");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/TitanicCrusher"),
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
