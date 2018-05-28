using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory 
{
	public class Rock : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 28;
			item.value = 50000;
			item.rare = 5;
			item.accessory = true;
		}
		
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Eldritch Geode");
      Tooltip.SetDefault("Increases your magic damage and mana cost \nIncreases life regen");
    }
    public override void Update(Player player, ref int buffIndex)
    {
        player.magicDamage *= 1.05f;
        player.manaCost += 0.30f;
	    player.lifeRegen += 2;
	}
    }
}
