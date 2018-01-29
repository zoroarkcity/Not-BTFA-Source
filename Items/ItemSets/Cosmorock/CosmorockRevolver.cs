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
		int counter = 0;
		public override void SetDefaults()
		{

			item.damage = 35;
			item.ranged = true;
			item.width = 23;
			item.height = 13;

			item.useTime = 2;
			item.useAnimation = 6;
			item.reuseDelay = 20;
			item.useStyle = 5;
			item.autoReuse = true;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 200000;
			item.rare = 6;
			item.UseSound = SoundID.Item11;
			item.shoot = 10;
			item.shootSpeed = 8f;
			item.useAmmo = AmmoID.Bullet;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cosmorock Revolver");
      Tooltip.SetDefault("Fires bullets in bursts of 2 in addition to a meteor");
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
		}////////////

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			counter++;
			float sX = speedX + (Main.rand.Next(-60, 60) * 0.02f);
			float sY = speedY + (Main.rand.Next(-60, 60) * 0.02f);
			
			if (counter > 2)
			{
				int proj = Projectile.NewProjectile(player.Center.X, player.Center.Y, sX, sY, mod.ProjectileType("CosmirockMeteor"), damage, knockBack, player.whoAmI);
				Main.projectile[proj].melee = false;
				Main.projectile[proj].ranged = true;
				counter = 0;
			}
			
			else
			{
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
