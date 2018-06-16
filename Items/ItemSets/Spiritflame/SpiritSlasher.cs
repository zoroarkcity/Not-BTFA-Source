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

namespace ForgottenMemories.Items.ItemSets.Spiritflame
{
	public class SpiritSlasher : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 86;
			item.melee = true;
			item.width = 58;
			item.height = 52;

			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 2.5f;
			item.value = 80000;
			item.rare = 8;
			item.UseSound = SoundID.Item71;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SpiritSlasher");
			item.shootSpeed = 7f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spirit Slasher");
			Tooltip.SetDefault("Fires a returning scythe blade");
			BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/SpiritSlasher");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/SpiritSlasher"),
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
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 origVect = new Vector2(speedX, speedY);
			Vector2 newVect = origVect.RotatedBy(System.Math.PI / 12);
			Vector2 newVect2 = origVect.RotatedBy(-System.Math.PI / 12);

			int p = Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, type, damage, knockBack, player.whoAmI, 0, 0);
			int p2 = Projectile.NewProjectile(position.X, position.Y, newVect2.X, newVect2.Y, type, damage, knockBack, player.whoAmI, 0, 0);
			return true;
		}

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SpiritflameChunk", 14);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
