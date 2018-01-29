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
    public class EnergizedBlaster : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 90;
            item.ranged = true;
            item.width = 31;
            item.height = 32;
            item.crit = 15;

            item.useTime = 45;
            item.useAnimation = 45;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 50000;
            item.rare = 5;
            item.UseSound = SoundID.Item75;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("EnergyOrb");
            item.shootSpeed = 18f;
            item.mana = 20;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Energized Blaster");
      Tooltip.SetDefault("Fires an explosive orb of energy");
      BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/EnergizedBlaster");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/EnergizedBlaster"),
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

		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-28, 0);
		}
    }
}
