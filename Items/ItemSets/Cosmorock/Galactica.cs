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
    public class Galactica : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 50;
            item.noMelee = true;
            item.ranged = true;
            item.width = 14;
            item.height = 21;

            item.useTime = 31;
            item.useAnimation = 31;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 40;
            item.knockBack = 1;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 6;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 10f;
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Galactica");
			Tooltip.SetDefault("Conjures astral arrows in addition to firing arrows normally");
			BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/Galactica");
		}
		
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/Galactica"),
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
			for (int k = 0; k < Main.rand.Next(1, 4); k++)
			{
				float rotation = new Vector2(speedX, speedY).ToRotation();
				Vector2 offset = (Vector2.UnitY * Main.rand.Next(-5, 6) * 4).RotatedBy(rotation);
				Projectile arrow = Main.projectile[Projectile.NewProjectile(position + offset, new Vector2(speedX, speedY)/2, mod.ProjectileType("AstralArrow"), (int)(damage * 0.66), knockBack, player.whoAmI, 0f, 0f)];
				arrow.netUpdate = true;
			}
            return true;
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
