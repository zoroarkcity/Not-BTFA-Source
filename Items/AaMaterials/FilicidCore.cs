using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ForgottenMemories.Items.AaMaterials
{
	public class FilicidCore : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 10;
			item.height = 10;
			item.noMelee = true; 
			item.value = 100;
			item.rare = 1;
			item.maxStack = 999;
		}
		
		public override void Update(ref float gravity, ref float maxFallSpeed)
		{
			maxFallSpeed = 0f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Filicid Core");
      Tooltip.SetDefault("'Tainted by the Red Moon'");
	  Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 4));
    }

	}
}
