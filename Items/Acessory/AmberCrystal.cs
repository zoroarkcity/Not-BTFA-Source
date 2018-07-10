using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory 
{
	public class AmberCrystal : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 28;


			item.value = 50000;
			item.rare = 2;
			item.accessory = true;
			item.expert = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amber Crystal");
			Tooltip.SetDefault("Summon attacks have a chance to create balls of sap");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).sapBall = true;
		}
	}
}
