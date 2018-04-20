using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Blightstone
{
	public class BlightstoneDragonStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 44;
			item.summon = true;
			item.mana = 15;
			item.width = 19;
			item.height = 19;

			item.useTime = 36;
			item.UseSound = SoundID.Item20;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
            item.knockBack = 2f;
            item.buffType = mod.BuffType("BlightstoneDragon");
            item.buffTime = 3600;
			item.value = Item.sellPrice(0, 8, 0, 0);
			item.rare = 7;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("BlightstoneDragon");
			item.shootSpeed = 10f;
			ProjectileID.Sets.MinionTargettingFeature[item.shoot] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blightstone Dragon Staff");
			Tooltip.SetDefault("Creates a blightstone dragon to fight for you");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 mouse = Main.MouseWorld;
			Projectile.NewProjectile(mouse.X, mouse.Y, 0f, 0f, type, damage, knockBack, player.whoAmI);
			return false;
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
