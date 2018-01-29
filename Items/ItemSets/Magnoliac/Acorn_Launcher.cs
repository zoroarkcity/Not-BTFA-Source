using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Magnoliac
{
    public class Acorn_Launcher : ModItem
    {

        public override void SetDefaults()
        {
            item.damage = 30;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("acornlauncherprojectile"); //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 1f;     // DONT CHANGE ME . JPG // YOU CAN IF YOU WANT TO THOUGH
			item.useAmmo = ItemID.Acorn;
		}
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acorn Cannon");
            Tooltip.SetDefault("Uses acorns as ammo. \n Fires accelerating pinecones.");
        }
    }
}
