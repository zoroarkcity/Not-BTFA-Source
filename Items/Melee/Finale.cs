using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Melee
{
	public class Finale : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 360;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			item.useTime = 10;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 200000000;
			item.rare = 11;
			item.expert = true;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("FinaleBoom");
			item.shootSpeed = 18;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Finale");
      Tooltip.SetDefault("Creates a ring of rainbow explosions around you \nRight-Clicking rains down explosive rainbow bolts \nCheat Item");
      BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/Finale");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/Finale"),
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

		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 63, 0f, 0f, 0, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 1f);
				Main.dust[dust].noGravity = true;
			}
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse != 2)
			{
				Main.PlaySound(2, (int)position.X, (int)position.Y, 62);
				for (int i = 0; i < 12; i++)
				{
					Vector2 pos = new Vector2(100, 0).RotatedBy(MathHelper.ToRadians(30 * i));
					int p = Projectile.NewProjectile(pos.X + player.Center.X, pos.Y + player.Center.Y, 0, 0, mod.ProjectileType("FinaleBoom"), damage, knockBack, player.whoAmI);
					Projectile projectile = Main.projectile[p];
				}
			}
			else
			{
				Main.PlaySound(2, (int)position.X, (int)position.Y, 9);
				Vector2 vector13 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
				float num119 = vector13.Y;
				if (num119 > player.Center.Y - 200f)
				{
					num119 = player.Center.Y - 200f;
				}
				int num2;
				int Type = mod.ProjectileType("RainbowBolt");
				int num76 = (int)item.shootSpeed;
				Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
				float num82 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
				float num83 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
				for (int num120 = 0; num120 < 2; num120 = num2 + 1)
				{
					vector2 = player.Center + new Vector2(-(float)Main.rand.Next(0, 401) * (float)player.direction, -600f);
					vector2.Y -= (float)(100 * num120);
					Vector2 vector14 = vector13 - vector2;
					if (vector14.Y < 0f)
					{
						vector14.Y *= -1f;
					}
					if (vector14.Y < 20f)
					{
						vector14.Y = 20f;
					}
					vector14.Normalize();
					vector14 *= num76;
					num82 = vector14.X;
					num83 = vector14.Y;
					Vector2[] array5 = new Vector2[5];
					float speedX5 = num82;
					float speedY6 = num83 + (float)Main.rand.Next(-40, 41) * 0.02f;
					Vector2 vector93 = array5[num120] - new Vector2(vector2.X, vector2.Y);
					int p = Projectile.NewProjectile(vector2.X, vector2.Y, speedX5, speedY6, Type, (int)damage/2, knockBack, player.whoAmI, 0f, 0f);
					Main.projectile[p].ai[1] = player.position.Y;
					num2 = num120;
				}
			}
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"Climax", 1);
			recipe.AddIngredient(ItemID.LunarBar, 18);
			recipe.AddIngredient(null,"CrazedImpurity", 1);
			recipe.AddIngredient(null,"perfectpurity", 1);
			recipe.AddIngredient(ItemID.GravityGlobe, 1);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
