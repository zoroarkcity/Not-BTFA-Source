using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.ItemSets.Essences.DuneEssence 
{
	public class DesertPistol : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 5;
			item.ranged = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 5000;
			item.rare = 1;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.useAmmo =  AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandstormer");
			Tooltip.SetDefault("Has a chance to fire a chunk of sand");
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Main.rand.Next(4) == 0)
			{
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-60, 61) * 0.03f;
				sY += (float)Main.rand.Next(-60, 61) * 0.03f;
				Projectile.NewProjectile(position.X, position.Y, sX, sY, mod.ProjectileType("SandChunk"), damage, knockBack, player.whoAmI);
			}
			
			return true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BossEnergy", 7);
			recipe.AddIngredient(ItemID.Cactus, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, 0);
		}
	}
}
