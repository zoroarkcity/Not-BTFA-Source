using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories.Projectiles.InfoA;

namespace ForgottenMemories.Items.ItemSets.Cosmodium
{
	public class CosmodiumRifle : ModItem
    {
        private Vector2 newVect;
        public override void SetDefaults()
        {

            item.damage = 86;
            item.ranged = true;
            item.width = 65;
            item.height = 21;
            item.useTime = 9;
            item.useAnimation = 9;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 6;
            item.value = Terraria.Item.sellPrice(0, 15, 0, 0);
            item.rare = 11;
            item.UseSound = SoundID.Item36;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 9f;
            item.useAmmo = AmmoID.Bullet;
        }
		
		public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(246, 0, 255);
                }
            }
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cosmodium Rifle");
      Tooltip.SetDefault("'The ammo is stored in an alternate dimension'\nMight not react well to plant-based ammo");
    }


        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
          
            Vector2 origVect = new Vector2(speedX, speedY);
            for (int X = 0; X <= 3; X++)
            {
                if (Main.rand.Next(2) == 1)
                {
                    newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(82, 1800) / 10));
                }
                else
                {
                    newVect = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(82, 1800) / 10));
                }
                if (type == 207)
                {
                    Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, type, 1, knockBack, player.whoAmI);
                }
                else
                {
                    int proj2 = Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, type, damage, knockBack, player.whoAmI);
                }
            }
            return false;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CosmodiumBar", 10);
            recipe.AddTile(412);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

    }
}
