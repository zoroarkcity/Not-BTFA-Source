using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Ranged
{
    public class GraniteRifle : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 32;
            item.ranged = true;
            item.width = 31;
            item.height = 32;
            item.crit = 17;

            item.useTime = 45;
            item.useAnimation = 45;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 12f;
            item.useAmmo = AmmoID.Bullet;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Granite Decimator");
      Tooltip.SetDefault("Destroys your enemies with ease");
    }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            // Convert Musket Balls into Granite Shots
            if (type == ProjectileID.Bullet)
            {
                type = mod.ProjectileType("GraniteBullet");
            }
            return true;
        }
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GraniteBlock, 20);
			recipe.AddIngredient(null, "Tourmaline", 8);
			recipe.AddIngredient(null, "SoaringEnergy", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
