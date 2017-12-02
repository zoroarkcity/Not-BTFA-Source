using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Magnoliac
{
	public class Beechorang : ModItem
	{
		public override void SetDefaults()
		{

            item.damage = 59;            
            item.melee = true;
            item.width = 30;
            item.height = 30;
			item.useTime = 10;
			item.useAnimation = 10;
            item.noUseGraphic = true;
            item.useStyle = 1;
			item.knockBack = 2;
			item.value = 60000;
			item.rare = 8;
			item.shootSpeed = 13f;
			item.shoot = mod.ProjectileType("BeechorangProj");
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beech-orang");
            Tooltip.SetDefault("Pierces enemies infinetly");
        }
    }
}