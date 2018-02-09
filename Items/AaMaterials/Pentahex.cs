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

namespace ForgottenMemories.Items.AaMaterials
{
	public class Pentahex : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 10;
			item.height = 10;
			item.noMelee = true; 
			item.value = 50000;
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			item.rare = 10;
			item.maxStack = 999;
		}
		
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/Pentahex_Glow"),
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

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Pentahex");
      Tooltip.SetDefault("'Overflowing with dark energy'");
    }

	}
}
