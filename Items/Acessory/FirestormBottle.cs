using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory {
public class FirestormBottle : ModItem
{
    public override void SetDefaults()
    {

        item.width = 24;
        item.height = 28;

        item.value = 150000;
        item.rare = 2;
        item.accessory = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Firestorm in a Bottle");
      Tooltip.SetDefault("Enhances your jump, leaving behind fire");
    }


    public override void UpdateAccessory(Player player, bool hideVisual)
	{
        ((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).firestorm = true;
		player.jumpSpeedBoost = 1.75f;
	}
}}
