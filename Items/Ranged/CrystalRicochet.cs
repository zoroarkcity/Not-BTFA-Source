using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Ranged
{
    public class CrystalRicochet : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 23;
            item.ranged = true;
            item.width = 31;
            item.height = 32;
            item.useTime = 4;
            item.useAnimation = 12;
            item.useStyle = 5;
			item.reuseDelay = 16;
            item.noMelee = true;
            item.knockBack = 1;
            item.value = 200000;
			item.rare = 5;
            item.UseSound = SoundID.Item31;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 12f;
            item.useAmmo = AmmoID.Bullet;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Crystal Ricochet");
      Tooltip.SetDefault("Converts musket balls into crystal bullets \nConverts crystal bullets into bouncing prism bullets");
    }
	
	
	public override bool ConsumeAmmo(Player player)
		{
			if (Main.rand.Next(3) == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
			
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == 89)
            {
                type = mod.ProjectileType("CrystalBullet");
            }
			if (type == ProjectileID.Bullet)
            {
                type = 89;
            }
            return true;
        }
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-20, 0);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ClockworkAssaultRifle, 1);
			recipe.AddIngredient(ItemID.HallowedBar, 7);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.CrystalShard, 30);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
