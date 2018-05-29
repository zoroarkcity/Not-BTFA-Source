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
			item.rare = 6;
			item.ammo = AmmoID.Gel;
			item.maxStack = 999;
			item.consumable = true;
            item.createTile = mod.TileType("GelolineTile"); 
            item.placeStyle = 0;
            item.useAnimation = 10; 
            item.useTime = 10;  
            item.useStyle = 1;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Geloline");
      Tooltip.SetDefault("Serves as a more effective alternative to gel for flamethrowers \n'Probably not too nutritious'");
	}
	}
}
