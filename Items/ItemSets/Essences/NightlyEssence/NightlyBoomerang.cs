using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.ItemSets.Essences.NightlyEssence
{
	public class NightlyBoomerang : ModItem
	{
		public override void SetDefaults()
		{

            item.damage = 13;            
            item.melee = true;
            item.width = 22;
            item.height = 26;
			item.useTime = 30;
			item.useAnimation = 10;
            item.noUseGraphic = true;
            item.useStyle = 1;
			item.knockBack = 0.5f;
			item.value = 30000;
			item.rare = 1;
			item.shootSpeed = 5f;
			item.shoot = mod.ProjectileType("NightlyBoomerangProj");
			item.UseSound = SoundID.Item1;
		}
		public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terrestrial Boomerang");
            Tooltip.SetDefault("");
			BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/NightlyBoomerang");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/NightlyBoomerang"),
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