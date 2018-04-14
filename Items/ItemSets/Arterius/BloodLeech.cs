using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Arterius
{
	public class BloodLeech : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 44;
			item.thrown = true;
			item.width = 44;
			item.height = 20;

			item.useStyle = 1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.knockBack = 2.4f;
			item.useTime = 12;
			item.useAnimation = 12;
			item.value = 7500;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("BloodLeech");
			item.shootSpeed = 14f;
			item.consumable = true;
			item.maxStack = 999;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood Leech");
			Tooltip.SetDefault("Sticks to enemies, dealing damage over time\nCreates an explosion of blood when killing an enemy");
		}

	}
}
