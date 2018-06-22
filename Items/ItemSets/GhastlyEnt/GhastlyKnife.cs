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
			item.damage = 28;
			item.thrown = true;
			item.shoot = mod.ProjectileType("GhastlyKnife");
			item.shootSpeed = 10f;
			item.useTime = 17;
			item.useAnimation = 17;
			item.maxStack = 1;
			item.useStyle = 5;
			item.noMelee = true;
			item.autoReuse = true;
            item.noUseGraphic = true;
			item.value = 38;
			item.rare = 3;
			item.shootSpeed = 15f;
			item.autoReuse = true;
			item.UseSound = SoundID.Item19;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Leaf Plumed Knives");
		  Tooltip.SetDefault("Ejects timber kunais that split into damaging woodchips on impact \nSometimes sprouts into a toxic seed on impact");
		}
	}
}
