using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;


namespace ForgottenMemories.Items.Ammo
{
    public class PlungerArrow : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Toilet Plunger");
			Tooltip.SetDefault("Has minimal damage, but insane knockback \nFunctions as an arrow");

        }
        public override void SetDefaults()
		{
			
			item.width = 10;
			item.height = 28;
            item.value = 50;
            item.rare = -1;

            item.maxStack = 999;

            item.damage = 6;
			item.knockBack = 9f;
            item.ammo = AmmoID.Arrow;

            item.ranged = true;
            item.consumable = true;

            item.shoot = mod.ProjectileType("PlungerProj");
            item.shootSpeed = 2.5f;
        }
    }
}
