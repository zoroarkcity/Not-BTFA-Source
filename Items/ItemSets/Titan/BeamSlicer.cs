using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.ItemSets.Titan
 {
	public class BeamSlicer : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 47;
			item.thrown = true;
			item.noMelee = true;
			item.noUseGraphic = true;

			item.width = 22;
			item.height = 22;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.shootSpeed = 12f;
			item.shoot = mod.ProjectileType("BeamSlicer");
			item.knockBack = 1;
			item.UseSound = SoundID.Item1;
			item.value = 900;
			item.rare = 6;
			item.consumable = true;
			item.maxStack = 999;
			item.autoReuse = true;
		}

    public override void SetStaticDefaults()
    {
		DisplayName.SetDefault("Beam Slicer");
		Tooltip.SetDefault("Stops midair, firing lasers at nearby enemies");
		BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/BeamSlicer");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/BeamSlicer"),
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
	}
}
