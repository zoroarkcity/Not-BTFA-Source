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
    public class CosmodiumDisk : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 120;            
            item.melee = true;
            item.width = 30;
            item.height = 30;
			item.noMelee = true;
            item.useTime = 10;
            item.useAnimation = 10;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.knockBack = 7;
            item.value = Terraria.Item.sellPrice(0, 15, 0, 0);
            item.rare = 11;
            item.shootSpeed = 16f;
            item.shoot = mod.ProjectileType ("CosmodiumDisk");
            item.UseSound = SoundID.Item37;
            item.autoReuse = true;
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
      DisplayName.SetDefault("Ultra Tech Disc");
      Tooltip.SetDefault("Up to 20 disks can be thrown at once, explodes on collision");
    }

		
        public override bool CanUseItem(Player player)
        {
            int disksOut = 0;
            for (int l = 0; l < 1000; l++)
            {
                if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == item.shoot)
                {
                    disksOut++;
                }
            }
            if (disksOut > 19)
            {
                return false;
            }
            return true;
        }
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CosmodiumBar", 9);
            recipe.AddTile(412);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
