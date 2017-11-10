using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.GhastlyEnt
{
	public class GhastlyKnife : ModItem
	{

		public override void SetDefaults()
		{
			item.damage = 37;
			item.thrown = true;
			item.shoot = mod.ProjectileType("GhastlyKnife");

			item.consumable = true;
			item.shootSpeed = 10f;
			item.useTime = 17;
			item.useAnimation = 17;

			item.consumable = true;
			item.maxStack = 999;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.value = 38;
			item.rare = 2;
			item.shootSpeed = 15f;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Timber Kunai");
		  Tooltip.SetDefault("Splits into woodchips when destroyed");
		}
	}
}
