using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Gelatine
{
    public class GelatineBow : ModItem
    {

        public override void SetDefaults()
        {

            item.damage = 10;
            item.noMelee = true;
            item.ranged = true;
            item.width = 27;
            item.height = 11;

            item.useTime = 23;
            item.useAnimation = 23;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 40;
            item.knockBack = 1;
            item.value = 138000;
			item.rare = 1;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 6f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Gelatine Bow");
      Tooltip.SetDefault("Has a chance to fire gel arrows");
    }
	
	public override Vector2? HoldoutOffset()
		{
			return new Vector2(-3, 0);
		}


		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Main.rand.Next(4) == 0)
			{
				for (int i = 0; i < 2; ++i)
				{
					float sX = speedX;
					float sY = speedY;
					sX += (float)Main.rand.Next(-30, 30) * 0.02f;
					sY += (float)Main.rand.Next(-30, 30) * 0.02f;
					int p = Projectile.NewProjectile(position.X, position.Y, sX, sY, mod.ProjectileType("gelarrow"), damage, knockBack, player.whoAmI);
				}
				return false;
			}
			return true;
		}
		
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GelatineBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
