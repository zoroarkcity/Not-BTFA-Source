using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory
 {
	public class RoyalGelNecklace : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 28;
			item.value = 140000;
			item.rare = 2;
			item.expert = true;
			item.accessory = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Royal Gel Necklace");
      Tooltip.SetDefault("Getting hit releases slime guards to protect you \nMinions have a chance to slow down enemies \nSlimes are passive");
    }


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).jungard = true;
			((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).frostguard = true;
			((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).SlimyNeck = true;
			player.npcTypeNoAggro[1] = true;
			player.npcTypeNoAggro[16] = true;
			player.npcTypeNoAggro[59] = true;
			player.npcTypeNoAggro[71] = true;
			player.npcTypeNoAggro[81] = true;
			player.npcTypeNoAggro[138] = true;
			player.npcTypeNoAggro[121] = true;
			player.npcTypeNoAggro[122] = true;
			player.npcTypeNoAggro[141] = true;
			player.npcTypeNoAggro[147] = true;
			player.npcTypeNoAggro[183] = true;
			player.npcTypeNoAggro[184] = true;
			player.npcTypeNoAggro[204] = true;
			player.npcTypeNoAggro[225] = true;
			player.npcTypeNoAggro[244] = true;
			player.npcTypeNoAggro[302] = true;
			player.npcTypeNoAggro[333] = true;
			player.npcTypeNoAggro[335] = true;
			player.npcTypeNoAggro[334] = true;
			player.npcTypeNoAggro[336] = true;
			player.npcTypeNoAggro[537] = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SlimyNecklace", 1);
			recipe.AddIngredient(null, "JungleSlimePendant", 1);
			recipe.AddIngredient(null, "IceSlimeNecklace", 1);
			recipe.AddIngredient(ItemID.RoyalGel, 1);
			recipe.AddTile(114);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
