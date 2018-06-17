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

namespace ForgottenMemories.Items.ItemSets.Blightstone
{
	public class BlightPistol : ModItem
	{
		public int counter = 3;

		public override void SetDefaults()
		{
			item.damage = 35;
			item.ranged = true;
			item.width = 32;
			item.height = 20;

			item.useTime = 3;
			item.useAnimation = 9;
			item.reuseDelay = 12;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 1;
			item.value = Item.sellPrice(0, 8, 0, 0);
			item.rare = 7;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 5.25f;
			item.useAmmo = AmmoID.Bullet;
			//item.crit = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blight Blaster");
			Tooltip.SetDefault("Fires a salvo of blighted energy");
			BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/BlightPistol");
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/BlightPistol"),
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
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("BlightBullet");
			Vector2 speed = new Vector2(speedX, speedY);
			if (counter == 3)
			{
				counter = 1;
			}
			else
			{
				counter++;
				double rotation = Main.rand.Next(-4, 5) * Math.PI / 180;
				speed = speed.RotatedBy(rotation);
			}
			Projectile.NewProjectile(position, speed, type, damage, knockBack, player.whoAmI);
			Main.PlaySound(2, (int) position.X, (int) position.Y, 11);
			return false;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, -4);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "OceanPistol", 1);
			recipe.AddIngredient(null, "blight_bar", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
