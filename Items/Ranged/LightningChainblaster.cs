using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Ranged 
{
	public class LightningChainblaster : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 35;
			item.ranged = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 3;
			item.useAnimation = 3;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 500000;
			item.rare = 9;
			item.UseSound = SoundID.Item41;
			item.autoReuse = true;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 15f;
			item.noMelee = true;
			item.useAmmo =  AmmoID.Bullet;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Lightning Chainblaster");
      Tooltip.SetDefault("");
      BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/LightningChainblaster");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/LightningChainblaster"),
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

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "LaserCannon", 1);
			recipe.AddIngredient(ItemID.ChainGun, 1);
			recipe.AddIngredient(3456, 18);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-7, 0);
		}
		
		public override bool ConsumeAmmo(Player player)
		{
			if (Main.rand.Next(5) == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
			
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Main.rand.Next(5) == 0)
			{
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-60, 61) * 0.03f;
				sY += (float)Main.rand.Next(-60, 61) * 0.03f;
				Projectile.NewProjectile(position.X, position.Y, sX, sY, mod.ProjectileType("LightningChain"), damage, knockBack, player.whoAmI);
			}
			
			float spX = speedX;
			float spY = speedY;
			spX += (float)Main.rand.Next(-60, 61) * 0.03f;
			spY += (float)Main.rand.Next(-60, 61) * 0.03f;
			Projectile.NewProjectile(position.X, position.Y, spX, spY, type, damage, knockBack, player.whoAmI);
			
			return false;
		}
	}
}
