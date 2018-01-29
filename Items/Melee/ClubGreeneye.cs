using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Melee 
{
	public class ClubGreeneye : ModItem
	{
		Vector2 gayvector = new Vector2(0f, -5f);
		Vector2 homovector = new Vector2(0f, 5f);
		Vector2 bivector = new Vector2(-5f, 0f);
		Vector2 lesvector = new Vector2(5f, 0f);
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spazmatic Swing");
			Tooltip.SetDefault("'Contains the heart of the twins'\nFires a circle of cursed fireballs");
			BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/Items/Melee/ClubGreeneye_Glow");
		}
		public override void SetDefaults()
		{
			item.damage = 68; 
			item.crit = 2;
			item.melee = true;
			item.knockBack = 10; 
			item.autoReuse = true; 
			item.useTurn = true; 

			item.width = 32;       
			item.height = 32;

			item.useTime = 42;
			item.useAnimation = 42;
			item.useStyle = 1;
			item.UseSound = SoundID.Item1;

			item.value = 100000;
			item.rare = 7;
			item.expert = true;
			item.shoot = 1;
			item.shootSpeed = 10;
		}
			
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 89);
			}
		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("Items/Melee/ClubGreeneye_Glow"),
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
		}/////////////////////////////////////////////////////////WORLD GLOWMASK///////////////////////////
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 newVect = gayvector.RotatedBy(System.Math.PI / 35);
			gayvector = newVect;
			homovector = gayvector.RotatedBy(System.Math.PI);
			bivector = gayvector.RotatedBy(System.Math.PI / 2);
			lesvector = gayvector.RotatedBy(System.Math.PI / -2);
			Projectile.NewProjectile(player.Center.X, player.Center.Y, gayvector.X, gayvector.Y, mod.ProjectileType("CursedFire"), damage, 1, Main.myPlayer, 0, 0);
			Projectile.NewProjectile(player.Center.X, player.Center.Y, homovector.X, homovector.Y, mod.ProjectileType("CursedFire"), damage, 1, Main.myPlayer, 0, 0);
			Projectile.NewProjectile(player.Center.X, player.Center.Y, bivector.X, bivector.Y, mod.ProjectileType("CursedFire"), damage, 1, Main.myPlayer, 0, 0);
			Projectile.NewProjectile(player.Center.X, player.Center.Y, lesvector.X, lesvector.Y, mod.ProjectileType("CursedFire"), damage, 1, Main.myPlayer, 0, 0);
			Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 20);
			return false;
		}
	}
}
