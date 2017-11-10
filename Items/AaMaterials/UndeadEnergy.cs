using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ForgottenMemories.Items.AaMaterials
{
	public class UndeadEnergy : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 10;
			item.height = 10;
			item.noMelee = true; 
			item.value = 100;
			item.rare = 3;
			item.scale = 0.75f;
			item.maxStack = 999;
		}
		
		public override void Update(ref float gravity, ref float maxFallSpeed)
		{
			maxFallSpeed = 0f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Undead Essence");
      Tooltip.SetDefault("'A key element in ressurection'");
	  Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 4));
    }

	}
}
