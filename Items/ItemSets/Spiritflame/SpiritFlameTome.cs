using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Spiritflame
{
	public class SpiritFlameTome : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 35;
			item.magic = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 138000;
			item.rare = 4;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;

			item.shoot = mod.ProjectileType("SpiritThing");
			item.shootSpeed = 10f;
			item.mana = 4;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Haunting Tome");
      Tooltip.SetDefault("Damages enemies at your cursor");
    }


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int amountOfProjectiles = 2;
			for (int i = 0; i < amountOfProjectiles; ++i)
			{
				Vector2 mouse = Main.MouseWorld;
				mouse.X += Main.rand.Next(-60, 61);
				mouse.Y += Main.rand.Next(-60, 61);
				Projectile.NewProjectile(mouse.X, mouse.Y, 0f, 0f, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SpiritflameChunk", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
