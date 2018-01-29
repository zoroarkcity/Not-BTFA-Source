using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using ForgottenMemories.Projectiles.InfoA;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.ItemSets.Spiritflame
 {
	public class GhastlyShotbow : ModItem
	{
		
		public override void SetDefaults()
		{

			item.damage = 32;
			item.ranged = true;
			item.noMelee = true;
			item.noUseGraphic = false;
			item.width = 22;
			item.height = 22;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 5;
			item.shootSpeed = 10f;
			item.shoot = mod.ProjectileType("SpiritfireArrow");
			item.useAmmo = 40;
			item.knockBack = 1;
			item.UseSound = SoundID.Item102;
			item.value = 80000;
			item.rare = 4;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Ghastly Longbow");
		  Tooltip.SetDefault("Turns arrows into spiritfire arrows");
		  BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/GhastlyShotbow");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/GhastlyShotbow"),
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
			return new Vector2(-3, 0);
		}
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SpiritflameChunk", 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			if (type == 1)
            {
                type = mod.ProjectileType("SpiritfireArrow");
            }
			Projectile.NewProjectile(player.Center.X, player.Center.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0, 0);
				
            return false;
        }
	}
}
