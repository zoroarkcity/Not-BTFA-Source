using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.AaMaterials
{
	public class Pentahex : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 10;
			item.height = 10;
			item.noMelee = true; 
			item.value = 50000;
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			item.rare = 10;
			item.maxStack = 999;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Pentahex");
      Tooltip.SetDefault("'Overflowing with dark energy'");
	   BTFAGlowmask.AddGlowMask(item.type, "ForgottenMemories/GlowMasks/Pentahex_Glow");
    }

	}
}
