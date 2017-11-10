using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee {
public class MartianYoyo : ModItem
{
    public override void SetDefaults()
		{

			item.useStyle = 5;
			item.width = 24;
			item.height = 24;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;

			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 3.75f;
			item.damage = 100;
			item.value = 500000;
			item.rare = 8;
			item.shoot = mod.ProjectileType("MartianYoyoP");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Extraterrestrial");
      Tooltip.SetDefault("Has a chance to fire lasers on hit");
    }

	}
}
