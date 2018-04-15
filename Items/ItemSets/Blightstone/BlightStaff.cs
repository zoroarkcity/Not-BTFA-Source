using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;
namespace ForgottenMemories.Items.ItemSets.Blightstone
{
	public class BlightStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 82;
			item.magic = true;

			item.width = 25;
			item.height = 25;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.knockBack = 1;
			item.value = 250000;
			item.rare = 5;
			item.UseSound = SoundID.Item20;
			item.shoot = mod.ProjectileType("BlightedEmber2");
			item.shootSpeed = 10f;
			item.autoReuse = true;
			item.mana = 8;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Blighted Inferno Scepter");
      Tooltip.SetDefault("Creates an inferno of malevolent fire");
      BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/BlightStaff");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/BlightStaff"),
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
			for (int i = 0; i < 2; i++)
			{
				Vector2 vel = new Vector2(speedX, speedY).RotatedBy(MathHelper.ToRadians(Main.rand.Next(-30, 30)));
				Projectile.NewProjectile(position, vel, type, damage, knockBack, player.whoAmI, vel.X, vel.Y);
			}
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "blight_bar", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
