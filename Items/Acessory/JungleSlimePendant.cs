using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory
 {
public class JungleSlimePendant : ModItem
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
      DisplayName.SetDefault("Jungle Pendant");
      Tooltip.SetDefault("Has a chance to summon a jungle slime when you get hit");
    }


    public override void UpdateAccessory(Player player, bool hideVisual)
	{
        ((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).jungard = true;
	}
}
}
