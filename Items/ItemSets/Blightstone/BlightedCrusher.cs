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

namespace ForgottenMemories.Items.ItemSets.Blightstone
{
	public class BlightedCrusher : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 61;
			item.melee = true;
			item.width = 60;
			item.height = 60;
			item.useTime = 18;
			item.useAnimation = 18;
			item.crit = 16;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.sellPrice(0, 8, 0, 0);
			item.rare = 7;
			item.useTurn = false;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("BlightedWave");
			item.shootSpeed = 14f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighted Crusher");
			Tooltip.SetDefault("Fires ominous waves that place temporary blight marks on enemies\nRight-click to dash on a three second cooldown\nDash through marked enemies to cleanse them in blighted fire");
			BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/BlightedCrusher");
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/BlightedCrusher"),
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

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.useStyle = 5;
				Item.staff[item.type] = true;
				item.useTime = 36;
				item.useAnimation = 36;
				item.shoot = 0;
				
				if (player.GetModPlayer<BTFAPlayer>(mod).blightDashCooldown != 0 || player.itemAnimation != 0)
					return false;
			}
			else
			{
				item.useStyle = 1;
				item.useTime = 18;
				item.useAnimation = 18;
				item.shoot = mod.ProjectileType("BlightedWave");
			}
			return base.CanUseItem(player);
		}

		public override bool AltFunctionUse(Player player)
		{
            { 
				if (player.direction == -1 && player.GetModPlayer<BTFAPlayer>(mod).blightDashCooldown == 0)
				{
					player.velocity.X = -15.25f;
					Point tileCoordinates1 = (player.Center + new Vector2((float) (-1 * player.width / 2 + 2), (float) ((double) player.gravDir * (double) -player.height / 2.0 + (double) player.gravDir * 2.0))).ToTileCoordinates();
					Point tileCoordinates2 = (player.Center + new Vector2((float) (-1 * player.width / 2 + 2), 0.0f)).ToTileCoordinates();
					if (WorldGen.SolidOrSlopedTile(tileCoordinates1.X, tileCoordinates1.Y) || WorldGen.SolidOrSlopedTile(tileCoordinates2.X, tileCoordinates2.Y))
					{
						player.velocity.X /= 2f;
					}
				}
				else if (player.direction == 1 && player.GetModPlayer<BTFAPlayer>(mod).blightDashCooldown == 0)
				{
					player.velocity.X = 15.25f;
					Point tileCoordinates1 = (player.Center + new Vector2((float) (1 * player.width / 2 + 2), (float) ((double) player.gravDir * (double) -player.height / 2.0 + (double) player.gravDir * 2.0))).ToTileCoordinates();
					Point tileCoordinates2 = (player.Center + new Vector2((float) (1 * player.width / 2 + 2), 0.0f)).ToTileCoordinates();
					if (WorldGen.SolidOrSlopedTile(tileCoordinates1.X, tileCoordinates1.Y) || WorldGen.SolidOrSlopedTile(tileCoordinates2.X, tileCoordinates2.Y))
					{
						player.velocity.X /= 2f;
					}
				}
				player.GetModPlayer<BTFAPlayer>(mod).hasBlightFlashed = false;
				//player.GetModPlayer<BTFAPlayer>(mod).blightDashCooldown = 180;
				return true;
            }
            return true;
		}

		public override void UseStyle(Player player)
        {
			Vector2 vector2_1 = Main.OffsetsPlayerOnhand[player.bodyFrame.Y / 56] * 2f;
			if (player.direction != 1)
				vector2_1.X = (float) player.bodyFrame.Width - vector2_1.X;
			if ((double) player.gravDir != 1.0)
				vector2_1.Y = (float) player.bodyFrame.Height - vector2_1.Y;
			vector2_1 -= new Vector2((float) (player.bodyFrame.Width - player.width), (float) (player.bodyFrame.Height - 42)) / 2f;
			Vector2 vector2_2 = player.RotatedRelativePoint(player.position + vector2_1, true) - player.velocity;
			if (player.altFunctionUse == 2)
			{
				int num;

				for (int index1 = 0; index1 < 10; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 173, 0.0f, 0.0f, 0, default(Color), 1.25f);
					Main.dust[index2].position.X += (float) Main.rand.Next(-5, 6);
					Main.dust[index2].position.Y += (float) Main.rand.Next(-5, 6);
					Main.dust[index2].velocity *= 0.2f;
					Main.dust[index2].scale *= (float) (1.0 + (double) Main.rand.Next(20) * 0.01);
					Main.dust[index2].noGravity = true;
				}
				
				player.GetModPlayer<BTFAPlayer>(mod).blightDashCooldown = 180;
			}
        }

		public override void UseItemHitbox (Player player, ref Rectangle hitbox, ref bool noHitbox)
		{
			if (player.altFunctionUse == 2)
			{
				noHitbox = true;

				if (player.ownedProjectileCounts[mod.ProjectileType("BlightedCrusherHitbox")] == 0)
				{
					Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("BlightedCrusherHitbox"), item.damage, item.knockBack, player.whoAmI);
				}
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			if (target.FindBuffIndex(mod.BuffType("BlightMark")) != -1 && player.GetModPlayer<BTFAPlayer>(mod).blightDashCooldown >= 160)
			{
				target.immune[player.whoAmI] = 0;

				int p = Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("BlightBoomRange"), damage, knockback, player.whoAmI);
				Main.projectile[p].ranged = false;
				Main.projectile[p].melee = true;
				Main.PlaySound(SoundID.Item14, player.position);
				
				if (!player.immune || player.immuneTime < 30)
				{
					player.immune = true;
					player.immuneTime = 30;
				}
			}

			int blightMark = mod.BuffType("BlightMark");
			if (target.buffImmune[blightMark])
				target.buffImmune[blightMark] = false;
			target.AddBuff(blightMark, 240);
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
