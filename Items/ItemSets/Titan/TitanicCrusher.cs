using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Titan
{
	public class TitanicCrusher : ModItem
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
			item.useAnimation = 44;
			item.useTime = 44;
			item.shootSpeed = 16f;
			item.knockBack = 3.75f;
			item.damage = 58;
			item.value = 140000;
			item.rare = 5;
			item.shoot = mod.ProjectileType("TitanicCrusher");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titanic Crusher");
			Tooltip.SetDefault("Rends enemy defense and deals some damage over time on hit \nHitting an enemy releases damaging spheres");
		}

	}
}
