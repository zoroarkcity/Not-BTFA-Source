using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

 
namespace ForgottenMemories.Items.FishingRod
{
	public class TrashRod : ModItem
    {
	  public override void SetStaticDefaults() 
	  {
      DisplayName.SetDefault("Garbage Reeler");
      Tooltip.SetDefault("Unfinished and unobtainable");
      }
      public override void SetDefaults()
	  {
        item.useStyle = 1;
        item.useAnimation = 8;
        item.useTime = 8;
        item.width = 24;
        item.height = 28;
        item.UseSound = SoundID.Item1;
        item.shoot = 361;
        item.fishingPole = 40;
        item.shootSpeed = 9f;
        item.shoot = 360;
       }
    }
}