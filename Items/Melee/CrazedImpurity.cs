using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Melee
{
	public class CrazedImpurity : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 125;
			item.melee = true;
			item.width = 88;
			item.height = 88;

			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 1000000;
			item.rare = 10;
			item.UseSound = SoundID.Item18;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("DarkWave");
			item.shootSpeed = 10;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Crazed Impurity");
      Tooltip.SetDefault("Tortures the enemy with agonizing lightning");
      BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/CrazedImpurity");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/CrazedImpurity"),
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
			recipe.AddIngredient(null, "impurity", 1);
			recipe.AddIngredient(ItemID.StarWrath, 1);
			recipe.AddIngredient(ItemID.DarkShard, 1);
			recipe.AddIngredient(ItemID.LunarBar, 8);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Main.PlaySound(2, (int)position.X, (int)position.Y, 15);
			
			Vector2 vector13 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			float num119 = vector13.Y;
			if (num119 > player.Center.Y - 200f)
			{
				num119 = player.Center.Y - 200f;
			}
			int num2;
			int Type = type;
			int num76 = (int)item.shootSpeed;
			Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
			float num82 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
			float num83 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
			for (int num120 = 0; num120 < 3; num120 = num2 + 1)
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
				switch (Main.rand.Next(3))
				{
					case 0:
						Type = mod.ProjectileType("lightning");
						break;
					case 1:
						Type = mod.ProjectileType("IchorLightning");
						break;
					case 2:
						Type = mod.ProjectileType("CurseLightning");
						break;
				}
				vector14.Normalize();
				vector14 *= num76;
				num82 = vector14.X;
				num83 = vector14.Y;
				Vector2[] array5 = new Vector2[5];
				float speedX5 = num82;
				float speedY6 = num83 + (float)Main.rand.Next(-40, 41) * 0.02f;
				Vector2 vector93 = array5[num120] - new Vector2(vector2.X, vector2.Y);
				int p = Projectile.NewProjectile(vector2.X, vector2.Y, speedX5, speedY6, Type, damage, knockBack, player.whoAmI, 0f, 0f);
				Main.projectile[p].ai[1] = player.position.Y;
				num2 = num120;
			}
			
			return false;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(4) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 173);
				Main.dust[dust].scale = 1.5f;
			}
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

	}
}
