using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.SoaringEssence
{
	public class SoaringTome : ModItem
	{
		
		public override void SetDefaults()
		{

			item.damage = 17;
			item.magic = true;
			item.mana = 6;
			item.width = 25;
			item.height = 26;
			item.useTime = 34;
			item.UseSound = SoundID.Item43;
			item.useAnimation = 34;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SoaringStar");
			item.shootSpeed = 7f;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Soaring Tome");
		  Tooltip.SetDefault("Fires stars from the sky");
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
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SoaringEnergy", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
