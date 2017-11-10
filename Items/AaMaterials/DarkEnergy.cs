using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ForgottenMemories.Items.AaMaterials
{
	public class DarkEnergy : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 10;
			item.height = 10;
			item.noMelee = true; 
			item.value = 20;
			item.rare = 1;
			item.scale = 0.75f;
			item.maxStack = 999;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Nightly Essence");
      Tooltip.SetDefault("'Embroidered with stars'");
	  Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 4));
    }
	
	public override void Update(ref float gravity, ref float maxFallSpeed)
		{
			maxFallSpeed = 0f;
		}

	}
}
