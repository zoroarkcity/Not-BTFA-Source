using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Magic
{
	public class StaffOfHephaestus : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 50;
			item.magic = true;
			item.crit = 26;
			item.mana = 18;
			item.width = 25;
			item.height = 26;

			item.useTime = 6;
			item.UseSound = SoundID.Item73;
			item.useAnimation = 30;
			item.reuseDelay = 20;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 7;
			Item.staff[item.type] = true;
			item.value = 12000;
			item.rare = 8;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("MoltenBlade");
			item.shootSpeed = 14f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Staff of Hephaestus");
      Tooltip.SetDefault("Fires a barrage of molten blades");
	  BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/StaffOfHephaestus");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/StaffOfHephaestus"),
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
			Projectile.NewProjectile(vector26, vector27 * 1.2f, type, damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
		
		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SkyFracture, 1);
			recipe.AddIngredient(ItemID.BeetleHusk, 8);
			recipe.AddIngredient(ItemID.HellstoneBar, 16);
			recipe.AddIngredient(null, "DevilFlame", 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
		}
	}
}
