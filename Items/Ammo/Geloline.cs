using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace ForgottenMemories.Items.Ammo 
{
	public class Geloline : ModItem
	{	
		public override void SetDefaults()
		{

			item.damage = 15;
			item.ranged = true;
			item.width = 22;
			item.height = 22;
			item.knockBack = 0.5f;
			item.UseSound = SoundID.Item1;
			item.value = 50;
			item.rare = 3;
			item.ammo = AmmoID.Gel;
			item.maxStack = 999;
			item.consumable = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Geloline");
      Tooltip.SetDefault("Serves as a more effective alternative to gel for flamethrowers \n'Probably not too nutritious'");
	}
	}
}
