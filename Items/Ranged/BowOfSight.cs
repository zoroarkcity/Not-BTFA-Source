using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Ranged
{
	public class BowOfSight : ModItem
	{

		public override void SetDefaults()
		{

			item.damage = 37;
			item.noMelee = true;
			item.ranged = true;
			item.width = 27;
			item.height = 11;

			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.shoot = 3;
			item.useAmmo = 40;
			item.knockBack = 1;
			item.value = 500000;
			item.rare = 5;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shootSpeed = 10f;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Bow of Sight");
		  Tooltip.SetDefault("Fires high velocity energy bolts that hit enemies twice");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("sightarrow"), damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("sightarrow"), damage, knockBack, player.whoAmI);
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofSight, 10);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
