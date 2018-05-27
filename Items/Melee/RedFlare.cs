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
	public class RedFlare : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 125;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			item.useTime = 12;
			item.useAnimation = 12;
            item.consumable = true;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 250000;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("RedFlareBolt");
			item.shootSpeed = 15f;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Dragonfire Blade");
		  Tooltip.SetDefault("Launches a number of explosive fireballs inaccurately \nRight click the sword as you hold it to change its mode \nMay move a slot when changed \nCan also be crafted into its counterpart for free if necessary");
		  BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/RedFlare");
    }
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("GlowMasks/RedFlare"),
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
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(24, 1800, false);
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 18);
			recipe.AddIngredient(ItemID.FragmentSolar, 8);
			recipe.AddIngredient(ItemID.FragmentStardust, 8);
			recipe.AddIngredient(ItemID.Ectoplasm, 10);
			recipe.AddIngredient(ItemID.LunarBar, 8);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BlueFlare", 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 3; i++)
			{
				Vector2 vel = new Vector2 (speedX, speedY).RotatedBy((Main.rand.Next(-15, 15) * MathHelper.Pi)/180);
				Projectile.NewProjectile(position.X, position.Y, vel.X, vel.Y, type, damage, 0f, player.whoAmI, 0f, 0f);
			}
			return false;
	    }
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 6);
			}
		}
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
		       player.QuickSpawnItem(mod.ItemType("BlueFlare"), 1);
			   item.UseSound = SoundID.Item71;			
			   item.consumable = true;
			}
			else
			{
			   item.damage = 128;
			   item.melee = true;
			   item.width = 88;
			   item.height = 88;
			   item.useTime = 13;
			   item.useAnimation = 13;
			   item.useTurn = true;
			   item.useStyle = 1;
			   item.knockBack = 6;
			   item.value = 250000;
			   item.rare = 10;
			   item.UseSound = SoundID.Item71;	
			   item.autoReuse = true;
			   item.consumable = false;
			   item.shoot = mod.ProjectileType("RedFlareBolt");
			}
			return base.CanUseItem(player);
		}
	}
}