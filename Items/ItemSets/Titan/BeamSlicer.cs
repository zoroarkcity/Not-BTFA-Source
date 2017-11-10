using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ForgottenMemories.Items.ItemSets.Titan
 {
	public class BeamSlicer : ModItem
	{
		
		public override void SetDefaults()
		{

			item.damage = 43;
			item.thrown = true;
			item.noMelee = true;
			item.noUseGraphic = true;

			item.width = 22;
			item.height = 22;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.shootSpeed = 12f;
			item.shoot = mod.ProjectileType("BeamSlicer");
			item.knockBack = 1;
			item.UseSound = SoundID.Item1;
			item.value = 900;
			item.rare = 5;
			item.consumable = true;
			item.maxStack = 999;
			item.autoReuse = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Beam Slicer");
      Tooltip.SetDefault("Stops midair, firing lasers at nearby enemies");
    }

	}
}
