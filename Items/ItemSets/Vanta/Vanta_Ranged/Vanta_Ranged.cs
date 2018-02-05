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

namespace ForgottenMemories.Items.ItemSets.Vanta.Vanta_Ranged
{
	public class Vanta_Ranged : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Galactic Machine-Shotgun");
			Tooltip.SetDefault("'Purges your foes with absorbed rainbow light'");
			BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/Items/ItemSets/Vanta/Vanta_Ranged/Vanta_Ranged_Glow");
		}

		public override void SetDefaults()
		{
			item.damage = 120;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 34;
			item.useAnimation = 34;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 4;
			item.value = 1000000;
			item.rare = 10;
			item.UseSound = SoundID.Item36;
			item.autoReuse = true;
			item.shoot = 10; 
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .33f; // 33% chance to not consume ammo
		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				mod.GetTexture("Items/ItemSets/Vanta/Vanta_Ranged/Vanta_Ranged_Glow"),
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
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, -4);
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (item.useTime >= 10 && item.useAnimation >= 10)
			{
				item.useTime -= 2;
				item.useAnimation -= 2;
			}
			else
			{
				item.useTime = 34;
				item.useAnimation = 34;
			}
			int numberProjectiles = 2;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3)); // 7 degree spread.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			if (Main.rand.Next(2) == 0)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("Vanta_Ranged_Projectile"), damage, knockBack, player.whoAmI);
			}
			return false;
		}
	}
}
