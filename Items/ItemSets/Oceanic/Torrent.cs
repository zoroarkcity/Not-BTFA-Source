using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Oceanic
{
    public class Torrent : ModItem
    {

        public override void SetDefaults()
        {

            item.damage = 16;
            item.noMelee = true;
            item.ranged = true;
            item.width = 27;
            item.height = 11;

            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 40;
            item.knockBack = 3;
			item.value = 50000;
			item.rare = 3;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 9f;
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torrent");
			Tooltip.SetDefault("Fires two arrows\nConverts wooden arrows into torrential arrows that ricochet off of tiles and enemies");
		}


		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == 1)
			{
				type = mod.ProjectileType("TorrentialArrow");
			}
			float num3 = 0.3141593f;
            int num4 = 2;
            Vector2 spinningpoint = new Vector2(speedX, speedY);
			spinningpoint.Normalize();
            spinningpoint *= 40f;
            //bool flag4 = Collision.CanHit(position, 0, 0, position + spinningpoint, 0, 0);
            for (int index1 = 0; index1 < num4; ++index1)
            {
				float num8 = (index1 == 0) ? -0.5f : 0.5f;
                Vector2 vector2_5 = spinningpoint.RotatedBy((double) num3 * (double) num8);
				//vector2_5 += spinningpoint;
                int index2 = Projectile.NewProjectile((float) (position.X + vector2_5.X), (float) (position.Y + vector2_5.Y), speedX, speedY, type, damage, knockBack, player.whoAmI, 0.0f, 0.0f);
                Main.projectile[index2].noDropItem = true;
            }
			return false;
		}
		
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "WaterShard", 5);
			recipe.AddIngredient(ItemID.SharkFin, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
