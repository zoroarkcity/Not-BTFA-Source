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

namespace ForgottenMemories.Items.ItemSets.Cosmorock
{
	public class CosmorockRevolver : ModItem
	{
		int counter = 3;
		public override void SetDefaults()
		{
			item.damage = 35;
			item.ranged = true;
			item.width = 23;
			item.height = 13;

			item.useTime = 3;
			item.useAnimation = 12;
			item.reuseDelay = 24;
			item.useStyle = 5;
			item.autoReuse = true;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 4, 80, 0);
			item.rare = 6;
			item.UseSound = SoundID.Item11;
			item.shoot = 10;
			item.shootSpeed = 8f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmorock Revolver");
			Tooltip.SetDefault("Fires a meteor and a salvo of three bullets");
			BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/CosmorockRevolver");
		}
	
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/CosmorockRevolver"),
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
			counter++;
			
			if (counter > 3)
			{
				int proj = Projectile.NewProjectile(player.Center.X, player.Center.Y, speedX, speedY, mod.ProjectileType("CosmirockMeteor"), (int) (damage * 1.2), knockBack, player.whoAmI);
				Main.projectile[proj].ranged = true;
				Main.projectile[proj].timeLeft *= 2;
				counter = 0;
			}
			else
			{
				float sX = speedX + (Main.rand.Next(-70, 71) * 0.02f);
				float sY = speedY + (Main.rand.Next(-70, 71) * 0.02f);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, sX, sY, type, damage, knockBack, player.whoAmI);
			}
			
			return false;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SpaceRockFragment", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
