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
	public class CosmodiumDestabilizer : ModItem
	{
		public override void SetDefaults()
		{	


            item.damage = 143;
            item.magic = true;
            item.mana = 15;
            item.width = 40;
            item.height = 40;
            item.useTime = item.useAnimation = 60;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = Terraria.Item.sellPrice(0, 15, 0, 0);
            item.rare = 11;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CosmodiumBolt");
            item.shootSpeed = 17f;
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
      DisplayName.SetDefault("Cosmodium Destabilizer");
      Tooltip.SetDefault("Launches an unstable beam of chaos");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CosmodiumBar", 8);
            recipe.AddTile(412);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
		}
	}
}
