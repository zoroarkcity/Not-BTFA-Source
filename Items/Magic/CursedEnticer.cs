using System;
using Microsoft.Xna.Framework;
using Terraria;
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
	public class CursedEnticer : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 22;
			item.magic = true;
			item.mana = 10;
			item.width = 25;
			item.height = 26;
			item.useTime = 22;
			item.UseSound = SoundID.Item20;

			item.useAnimation = 22;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = 50000;
			item.rare = 1;
			item.autoReuse = true;
			item.shoot = 307;
			item.shootSpeed = 4f;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Cursed Enticer");
		  Tooltip.SetDefault("Creates a miniature eater that infests killed enemies, spawning more eaters");
		  BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/CursedEnticer");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/CursedEnticer"),
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
			int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 307, damage, knockBack, player.whoAmI);
			Projectile projectile = Main.projectile[proj];
			projectile.magic = true;
			projectile.melee = false;
			projectile.GetGlobalProjectile<Info>(mod).Curse = true;
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"DevilFlame", 15);
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}
