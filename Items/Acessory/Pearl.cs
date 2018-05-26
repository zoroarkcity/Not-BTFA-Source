using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory {
public class Pearl : ModItem
{
    public override void SetDefaults()
    {

        item.width = 24;
        item.height = 28;
        item.value = 100000;
        item.rare = 1;
		item.consumable = true;
		item.createTile = mod.TileType("GoldBottleTile");
        item.accessory = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Pearl");
      Tooltip.SetDefault("Taking over 10 damage has a 1/2 chance to restore 10 health \nTaking damage when under half of your max health will restore even more health \n'The ocean protects you'");
    }


    public override void UpdateAccessory(Player player, bool hideVisual)
	{
        ((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).pearl = true;
	}
	
	public override bool CanEquipAccessory(Player player, int slot)
		{
			if (((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).pearl2 == true)
			{
				return false;
			}
			
			else
			{
				return true;
			}
		}
}}
