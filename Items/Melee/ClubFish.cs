using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Melee 
{
	public class ClubFish : ModItem
	{
		public override void SetDefaults()
		{


			item.damage = 28; 
			item.crit = 20;
			item.melee = true;
			item.knockBack = 7; 
			item.autoReuse = true; 
			item.useTurn = true; 

			item.width = 32;       
			item.height = 32;

			item.useTime = 41;
			item.useAnimation = 41;
			item.useStyle = 1;
			item.UseSound = SoundID.Item1;

			item.value = 30000;
			item.rare = 3;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crustacean Club");
			Tooltip.SetDefault("'You won't crack this shell'");
		}
	}
}
