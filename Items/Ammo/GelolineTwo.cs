using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace ForgottenMemories.Items.Ammo 
{
	public class GelolineTwo : ModItem
	{	
		public override void SetDefaults()
		{

			item.damage = 18;
			item.ranged = true;
			item.width = 22;
			item.height = 22;
			item.knockBack = 0.5f;
			item.UseSound = SoundID.Item1;
			item.value = 150;
			item.rare = 6;
			item.ammo = AmmoID.Gel;
			item.noMelee = true;
			item.maxStack = 999;
			item.consumable = true;
            item.createTile = mod.TileType("GelolineTwoTile"); 
            item.placeStyle = 0;
            item.useAnimation = 10; 
            item.useTime = 10;  
            item.useStyle = 1;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ghastly Oil");
      Tooltip.SetDefault("Serves as a more effective alternative to gel for flamethrowers \n'See, forest fires can be sustainable...'");
	}
	}
}
