using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
	public class StaffOfHephaestus : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 50;
			item.magic = true;
			item.crit = 26;
			item.mana = 18;
			item.width = 25;
			item.height = 26;

			item.useTime = 7;
			item.UseSound = SoundID.Item20;
			item.useAnimation = 14;
			item.reuseDelay = 20;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 7;
			Item.staff[item.type] = true;
			item.value = 12000;
			item.rare = 8;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("MoltenBlade");
			item.shootSpeed = 14f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Staff of Hephaestus");
      Tooltip.SetDefault("Fires a barrage of molten blades");
    }

		
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i <= 2; i++)
			{
				Vector2 Mouse = Main.MouseWorld;
				float sX = position.X;
				float sY = position.Y;
				sX += (float)Main.rand.Next(-70, 71);
				sY += (float)Main.rand.Next(-70, 71);
				Projectile.NewProjectile(sX, sY, speedX, speedY, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		
		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SkyFracture, 1);
			recipe.AddIngredient(ItemID.BeetleHusk, 8);
			recipe.AddIngredient(ItemID.HellstoneBar, 16);
			recipe.AddIngredient(null, "DevilFlame", 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
		}
	}
}
