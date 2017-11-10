using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.Magic 
{
	public class NebulaBolt : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 85;
			item.magic = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 7;
			item.useAnimation = 7;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 500000;
			item.rare = 10;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;

			item.shoot = mod.ProjectileType("NebulaFlame");
			item.shootSpeed = 10f;
			item.mana = 6;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Nebula Bolt");
      Tooltip.SetDefault("Summons flames at your cursor");
    }


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 mouse = Main.MouseWorld;
			mouse.X += Main.rand.Next(-150, 151);
			mouse.Y += Main.rand.Next(-150, 151);
			Projectile.NewProjectile(mouse.X, mouse.Y, 0f, 0f, type, damage, knockBack, player.whoAmI);
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3457, 10);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
