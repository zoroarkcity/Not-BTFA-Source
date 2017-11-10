using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ForgottenMemories.Items.AaMaterials
{
	public class SoaringEnergy : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 10;
			item.height = 10;
			item.noMelee = true; 
			item.value = 100;
			item.rare = 2;
			item.scale = 0.75f;
			item.maxStack = 999;
		}
		
		public override void Update(ref float gravity, ref float maxFallSpeed)
		{
			maxFallSpeed = 0f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Soaring Essence");
      Tooltip.SetDefault("'Sourced from a deadly altitude'");
	  Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 4));
    }

}
}
