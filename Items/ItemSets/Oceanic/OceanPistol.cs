using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using ForgottenMemories.Projectiles.InfoA;

namespace ForgottenMemories.Items.ItemSets.Oceanic
{
	public class OceanPistol : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 15;
			item.ranged = true;
			item.width = 32;
			item.height = 20;

			item.useTime = 13;
			item.useAnimation = 13;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 1;
			item.value = 50000;
			item.rare = 3;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = 10;
			item.shootSpeed = 5.25f;
			item.useAmmo = AmmoID.Bullet;
			item.crit = 11;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Ocean Pistol");
		  Tooltip.SetDefault("Critical hits cause you to fire a beam of high-pressure water");
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, -4);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile projectile = Main.projectile[Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, knockBack, player.whoAmI, 0f, 0f)];
			projectile.GetGlobalProjectile<Info>(mod).Water = true;
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "WaterShard", 4);
			recipe.AddIngredient(ItemID.SharkFin, 2);
			recipe.AddIngredient(ItemID.FlintlockPistol, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
