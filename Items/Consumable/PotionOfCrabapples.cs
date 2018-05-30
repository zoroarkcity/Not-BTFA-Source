using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Consumable
{
	public class PotionOfCrabapples : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Energy Drink");
			Tooltip.SetDefault("Cheat Item- Grants a large amount of health, for a very long time \nUnobtainable without inventory editors \n9999999 Maximum Health \n9999999 Maximum mana \nInsane life regen \nNo mana cost \n999999 Minion slots");
		}

		public override void SetDefaults()
		{
			item.buffType = mod.BuffType("Crabapples");
			item.width = 20;
			item.height = 10;
			item.useStyle = 2;
			item.noUseGraphic = true;
			item.buffTime = 9999999;
			item.UseSound = SoundID.Item3;
			item.useTime = 10;
			item.useAnimation = 10;
			item.consumable = true;
			item.value = 1000;
			item.rare = -1;
			item.maxStack = 999;
		}
	}
}
