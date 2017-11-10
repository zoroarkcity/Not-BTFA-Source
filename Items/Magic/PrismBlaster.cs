using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
	public class PrismBlaster : ModItem
	{

		public override void SetDefaults()
		{

			item.damage = 49;
			item.noMelee = true;
			item.magic = true;
			item.width = 27;
			item.height = 11;

			item.useTime = 39;
			item.useAnimation = 39;
			item.useStyle = 5;
			item.shoot = 3;
			item.knockBack = 1;
			item.value = 500000;
			item.rare = 5;
			item.UseSound = SoundID.Item91;
			item.autoReuse = true;
			item.shootSpeed = 10f;
			item.mana = 9;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Prism Blaster");
		  Tooltip.SetDefault("Fires a concentrated prism blast that can hit 3 times");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-7, 0);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("prismblast"), damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("prismblast"), damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("prismblast"), damage, knockBack, player.whoAmI);
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LaserRifle, 1);
			recipe.AddIngredient(ItemID.CrystalShard, 15);
			recipe.AddIngredient(ItemID.SoulofLight, 15);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
