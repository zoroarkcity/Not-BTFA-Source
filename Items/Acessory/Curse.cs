using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory 
{
	public class Curse : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 10000;
			item.expert = true;
			item.rare = 4;
			item.lifeRegen = 2;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Curse of Tartarus");
		  Tooltip.SetDefault("Creates a lost soul that follows you and drains the life force of enemies \nThe lost soul causes you to take more damage as a payment");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.endurance -= 0.3f;
			TgemPlayer modPlayer = player.GetModPlayer<TgemPlayer>(mod);
			modPlayer.Tartarus = true;
			
		}
	}
}
