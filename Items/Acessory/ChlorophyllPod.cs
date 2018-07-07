using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory 
{
	public class ChlorophyllPod : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 28;
			item.expert = true;
			item.value = 50000;
			item.rare = 3;
			item.accessory = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Chlorophyll Pod");
      Tooltip.SetDefault("Grants stacking buffs upon hitting an enemy \nThe buffs will increase life regen, movement speed and melee critical strike chance");
    }


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).chlorophyllPod = true;
		}
	}
}
