using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Titan
{
	public class LaserbeamStaff : ModItem
	{
		float memer = 0f;
		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.useAnimation = 20;
			item.useTime = 20;
			item.shootSpeed = 14f;
			item.knockBack = 2f;
			item.width = 16;
			item.height = 16;
			item.damage = 30;
			item.UseSound = SoundID.Item13;
			item.shoot = mod.ProjectileType("LaserbeamStaff");
			item.mana = 14;
			item.value = 50000;
            item.rare = 5;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.magic = true;
			item.channel = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Laserbeam Staff");
      Tooltip.SetDefault("");
    }
	}
}
