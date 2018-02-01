using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory
 {
public class IceSlimeNecklace : ModItem
{
    public override void SetDefaults()
    {

        item.width = 24;
        item.height = 28;

        item.value = 50000;
        item.rare = 2;
        item.accessory = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Frost Necklace");
      Tooltip.SetDefault("Has a chance to summon a frost slime when you get hit");
    }


    public override void UpdateAccessory(Player player, bool hideVisual)
	{
        ((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).frostguard = true;
	}
}
}
