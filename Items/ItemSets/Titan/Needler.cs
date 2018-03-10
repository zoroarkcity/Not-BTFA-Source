using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;
using ForgottenMemories.Projectiles.InfoA;

namespace ForgottenMemories.Items.ItemSets.Titan
{
	public class Needler : ModItem
	{

		public override void SetDefaults()
		{

			item.damage = 42;
			item.noMelee = true;
			item.ranged = true;
			item.width = 27;
			item.height = 11;
			item.useTime = 16;

			item.useAnimation = 16;
			item.useStyle = 5;
			item.shoot = 3;
			item.useAmmo = 40;
			item.knockBack = 1;
			item.value = 50000;
			item.rare = 5;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shootSpeed = 10f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Needle Bow");
      Tooltip.SetDefault("Has a chance to fire homing lasers on hit");
      BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/Needler");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/Needler"),
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
			/*if (Main.rand.Next(3) == 0)
			{
				for (int i = 0; i < 2; i++)
				{
					float sX = speedX;
					float sY = speedY;
					sX += (float)Main.rand.Next(-60, 61) * 0.03f;
					sY += (float)Main.rand.Next(-60, 61) * 0.03f;
					Projectile.NewProjectile(position.X, position.Y, sX, sY, mod.ProjectileType("laserbeamNeedle"), damage / 2, knockBack, player.whoAmI);
				}
			}*/
			int id = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Main.projectile[id].GetGlobalProjectile<Info>(mod).firedFromNeedler = true;

			return false;
		}
	}
}
