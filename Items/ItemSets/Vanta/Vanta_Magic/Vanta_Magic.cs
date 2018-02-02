using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
 
namespace ForgottenMemories.Items.ItemSets.Vanta.Vanta_Magic
{
    public class Vanta_Magic : ModItem
    {
		public override void SetDefaults()
		{
			//BALANCE THE WEAPON PLEASE, BE CAREFUL ABOUT RARITY AND VALUE
			item.damage = 12;
			item.holdStyle = 1;
			item.noMelee = true;
			item.noUseGraphic = false;
			item.magic = true;
			item.width = 30;
			item.height = 30;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.shoot = mod.ProjectileType("Vanta_Magic_Projectile");
			item.knockBack = 0f;
			Item.staff[item.type] = true;
			item.autoReuse = true;
			item.rare = 1;
			item.value = 12000;
			item.UseSound = SoundID.Item43;
			item.useTurn = false;
			item.mana = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vanta Magic Weapon");
			Tooltip.SetDefault("Someone deal with tooltips, names and balancement please -East");
			BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/Items/ItemSets/Vanta/Vanta_Magic/Vanta_Magic_Glow");
		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("Items/ItemSets/Vanta/Vanta_Magic/Vanta_Magic_Glow"),
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
		public override void HoldItem (Player player)	
		{
			int Type;
				switch (Main.rand.Next(4))
				{
					case 0:
						Type = 90;
						break;
					case 1:
						Type = 87;
						break;
					case 2:
						Type = 88;
						break;
					case 3:
						Type = 89;
						break;
					default:
						Type = 90;
						break;
				}
			if ((double) player.velocity.X != 0.0 && player.miscCounter % 2 == 0)
			{
				int index = Dust.NewDust(player.position, player.width, player.height, Type, 0.0f, 0.0f, 200, new Color(), 0.5f);
				Main.dust[index].noGravity = true;
				Main.dust[index].velocity *= 0.75f;
				Main.dust[index].fadeIn = 1.3f;
				Vector2 vector2_1 = new Vector2((float) Main.rand.Next(-100, 101), (float) Main.rand.Next(-100, 101));
				vector2_1.Normalize();
				Vector2 vector2_2 = vector2_1 * ((float) Main.rand.Next(50, 100) * 0.04f);
				Main.dust[index].velocity = vector2_2;
				vector2_2.Normalize();
				Vector2 vector2_3 = vector2_2 * 34f;
				Main.dust[index].position = player.Center - vector2_3;
			}
			Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y + player.velocity.Y), true);
		}
		public override Vector2? HoldoutOrigin()
		{
			Player player = Main.player[item.owner];
			return Vector2.Zero;
		}
		/*public override Vector2? HoldoutOffset()
		{
			Player player = Main.player[item.owner];
			return new Vector2(0, -20);
		}*/
		/*public override void AddRecipes()
		{
		    ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Aurora_Bowl", 7);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }*/
    }
}
