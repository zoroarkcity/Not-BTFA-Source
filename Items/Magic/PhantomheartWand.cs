using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories.Projectiles.InfoA;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Magic
{
	public class PhantomheartWand : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 110;
			item.magic = true;
			item.mana = 7;
			item.width = 25;
			item.height = 26;
			item.useTime = 7;
			item.UseSound = SoundID.Item43;

			item.useAnimation = 7;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = 650000;
			item.rare = 11;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Soul");
			item.shootSpeed = 9f;
		}
		
		public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(246, 0, 255);
                }
            }
        }

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Phantomheart Wand");
		  Tooltip.SetDefault("Unleashes a torrent of homing souls that phase through walls");
		  BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/PhantomheartWand");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/PhantomheartWand"),
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
			 Vector2 vector2_1 = player.RotatedRelativePoint(player.MountedCenter, true);
			int num3 = 1 + Main.rand.Next(2);
            for (int index = 0; index < num3; ++index)
            {
                float num4 = speedX;
                float num8 = speedY;
                float num9 = 0.025f * (1 + Main.rand.Next(2));
                float num10 = num4 + (float) Main.rand.Next(-35, 36) * num9;
                float num11 = num8 + (float) Main.rand.Next(-35, 36) * num9;
                float num12 = (float) Math.Sqrt((double) num10 * (double) num10 + (double) num11 * (double) num11);
                float num13 = item.shootSpeed / num12;
                float SpeedX2 = num10 * num13;
                float SpeedY2 = num11 * num13;
                int p = Projectile.NewProjectile((float) (vector2_1.X + (double) speedX * (double) (num3 - index) * 1.75), (float) (vector2_1.Y + (double) speedY * (double) (num3 - index) * 1.75), SpeedX2, SpeedY2, type, damage, knockBack, player.whoAmI, 0.0f, 0.0f);
				Main.projectile[p].tileCollide = false;
			}
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpectreStaff, 1);
			recipe.AddIngredient(ItemID.Razorpine, 1);
			recipe.AddIngredient(null,"CosmodiumBar", 12);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
