using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using ForgottenMemories.Projectiles.InfoA;

namespace ForgottenMemories.Items.ItemSets.Cosmorock
{
    public class Galactica : ModItem
    {

        public override void SetDefaults()
        {

            item.damage = 32;
            item.noMelee = true;
            item.ranged = true;
            item.width = 14;
            item.height = 21;

            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 40;
            item.knockBack = 1;
            item.value = 250000;
            item.rare = 6;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 10f;

        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Galactica");
      Tooltip.SetDefault("Fires a bouncing comet shard in addition to 2 arrows");
    }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			for (int k = 0; k < 3; k++)
			{
				int spread = -5 + (5 * k);
				Vector2 velVect = new Vector2(speedX, speedY);
				Vector2 velVect2 = velVect.RotatedBy(MathHelper.ToRadians(spread));
				
				if (spread == 0)
				{
					Projectile.NewProjectile(player.Center.X, player.Center.Y, velVect2.X, velVect2.Y, mod.ProjectileType("CometShard"), (int)(damage* 0.8), knockBack, Main.myPlayer, 0, 0);
				}
				
				else
				{
					Projectile.NewProjectile(player.Center.X, player.Center.Y, velVect2.X, velVect2.Y, type, damage, knockBack, Main.myPlayer, 0, 0);
				}
			}
            return false;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SpaceRockFragment", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
