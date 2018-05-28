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

namespace ForgottenMemories.Items.ItemSets.Essences.UndeadEssence
{
	public class UndeadScythe : ModItem //this is a rare drop and is not part of the undead set, do NOT make it craftable
	{
		
		public override void SetDefaults()
		{

			item.damage = 35;
			item.summon = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.width = 22;
			item.height = 22;
            item.mana = 15;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 1;
			item.shootSpeed = 9f;
			item.shoot = mod.ProjectileType("UndeadScythe");
			item.knockBack = 3;
			item.UseSound = SoundID.Item1;
			item.scale = 1f;
			item.value = 30000;
			item.rare = 4;
			item.autoReuse = true;
			item.maxStack = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sickle of Animation");
			Tooltip.SetDefault("Turns into an Underling on impact with an enemy \nThe Underling will act as a summoned minion for a short time before vanishing \nUnderlings do not take up minion slots");
		    BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/UndeadScythe");
		}
	    public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/UndeadScythe"),
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
