using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory 
{
	public class BloodHeart : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 28;

			item.expert = true;
			item.value = 50000;
			item.rare = 4;
			item.accessory = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Blood Heart");
      Tooltip.SetDefault("Gives you a chance to steal life on enemy hit");
    }


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).lifesteal = true;
		}
	}
}
