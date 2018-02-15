using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.ItemSets.Magnoliac
{
	public class Beechorang : ModItem
	{
		public override void SetDefaults()
		{

            item.damage = 23;            
            item.melee = true;
            item.width = 30;
            item.height = 30;
			item.useTime = 10;
			item.useAnimation = 10;
            item.noUseGraphic = true;
            item.useStyle = 1;
			item.knockBack = 2;
			item.value = 60000;
			item.rare = 3;
			item.shootSpeed = 9f;
			item.shoot = mod.ProjectileType("BeechorangProj");
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
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
            DisplayName.SetDefault("Beech-orang");
            Tooltip.SetDefault("Pierces enemies infinetly");
			BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/Beechorang");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/Beechorang"),
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