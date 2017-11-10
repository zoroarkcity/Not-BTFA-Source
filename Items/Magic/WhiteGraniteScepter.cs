using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
	public class WhiteGraniteScepter : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 26;
			item.magic = true;
			item.mana = 14;
			item.width = 25;
			item.height = 26;
			item.useTime = 32;
			item.UseSound = SoundID.Item43;

			item.useAnimation = 32;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 7;
			item.value = 50000;
			item.rare = 2;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("GraniteCluster");
			item.shootSpeed = 14f;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("White Granite Scepter");
		  Tooltip.SetDefault("Left-clicking conjures golden arrows that stick into enemies \nRight-clicking fires a granite rock cluster that splits into homing energy");
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
			{
				return true;
			}
			
			else
			{
				Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
				float num82 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
				float num83 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
				float num76 = item.shootSpeed;
				float f = Main.rand.NextFloat() * 6.28318548f;
				float value8 = 20f;
				float value9 = 60f;
				Vector2 vector26 = vector2 + f.ToRotationVector2() * MathHelper.Lerp(value8, value9, Main.rand.NextFloat());
				int num2;
				for (int num209 = 0; num209 < 50; num209 = num2 + 1)
				{
					vector26 = vector2 + f.ToRotationVector2() * MathHelper.Lerp(value8, value9, Main.rand.NextFloat());
					if (Collision.CanHit(vector2, 0, 0, vector26 + (vector26 - vector2).SafeNormalize(Vector2.UnitX) * 8f, 0, 0))
					{
						break;
					}
					f = Main.rand.NextFloat() * 6.28318548f;
					num2 = num209;
				}
				Vector2 mouseWorld = Main.MouseWorld;
				Vector2 vector27 = mouseWorld - vector26;
				Vector2 vector28 = new Vector2(num82, num83).SafeNormalize(Vector2.UnitY) * num76;
				vector27 = vector27.SafeNormalize(vector28) * num76;
				vector27 = Vector2.Lerp(vector27, vector28, 0.25f);
				Projectile.NewProjectile(vector26, vector27 * 1.2f, mod.ProjectileType("MarbleArrow"), damage, knockBack, player.whoAmI, 0f, 0f);
				return false;
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MarbleBlock, 18);
			recipe.AddIngredient(ItemID.GraniteBlock, 18);
			recipe.AddIngredient(null, "Tourmaline", 5);
			recipe.AddIngredient(null, "Citrine", 5);
			recipe.AddIngredient(null, "WaterShard", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
