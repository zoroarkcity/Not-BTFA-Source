using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.Items.Melee
{
    public class trashlid : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 19;            
            item.melee = true;
            item.width = 30;
            item.height = 30;

            item.useTime = 16;
            item.useAnimation = 16;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.knockBack = 4;
			item.value = Item.sellPrice(0, 2, 50, 0);
            item.rare = -1;
            item.shootSpeed = 13f;
			item.maxStack = 1;
            item.shoot = mod.ProjectileType ("trashlidP");
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Trashcan Lid");
		  Tooltip.SetDefault("Has a chance to make enemies bleed on hit");
		}

		
        public override bool CanUseItem(Player player)
        {
            int boomOut = 0;
            for (int l = 0; l < 1000; l++)
            {
                if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == item.shoot)
                {
                    boomOut++;
                }
            }
            if (boomOut > item.stack - 1)
            {
                return false;
            }
            return true;
        }
    }
}
