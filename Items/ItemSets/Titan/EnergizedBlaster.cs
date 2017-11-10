using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Titan
{
    public class EnergizedBlaster : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 90;
            item.ranged = true;
            item.width = 31;
            item.height = 32;
            item.crit = 15;

            item.useTime = 45;
            item.useAnimation = 45;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 50000;
            item.rare = 5;
            item.UseSound = SoundID.Item75;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("EnergyOrb");
            item.shootSpeed = 18f;
            item.mana = 20;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Energized Blaster");
      Tooltip.SetDefault("Fires an explosive orb of energy");
    }

		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-28, 0);
		}
    }
}
