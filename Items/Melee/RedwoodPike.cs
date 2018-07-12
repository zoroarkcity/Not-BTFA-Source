using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace ForgottenMemories.Items.Melee
{
	public class RedwoodPike : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 51;
			item.height = 52;
			item.scale = 1.1f;
			item.maxStack = 1;
			item.useTime = 20;
			item.useAnimation = 20;
			item.knockBack = 5f;
			item.UseSound = SoundID.Item1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useStyle = 5;
			item.value = Item.sellPrice(0, 7, 50, 0);
			item.rare = 3;
			item.shoot = mod.ProjectileType("RedwoodPike"); 
			item.shootSpeed = 7;
			item.autoReuse = true;

		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Sequoia Stab");
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
	}
}
