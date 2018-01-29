using System;
using Microsoft.Xna.Framework;
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

namespace ForgottenMemories.Items.Magic 
{
	public class VortexSphere : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 126;
			item.magic = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 500000;
			item.rare = 10;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;

			item.shoot = mod.ProjectileType("LightningSphere");
			item.shootSpeed = 5f;
			item.mana = 45;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Lightning Sphere");
	  Tooltip.SetDefault("Summons an orb of electricity that shoots lightning at nearby enemies");
      BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/VortexSphere");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/VortexSphere"),
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
