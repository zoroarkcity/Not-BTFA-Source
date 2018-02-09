using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory 
{
	public class MysticalCode : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 100000;
			item.expert = true;
			item.rare = 10;
			item.lifeRegen = 2;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Mystical Code");
		  Tooltip.SetDefault("Greatly increases life regen \nReduces the cooldown time of health potions \nCreates emerald energy around you over time \nEmerald energy homes, explodes on hit, and increases the amount of money enemies drop \n10% Increased Damage");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).EmeraldSpawn();
			((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).EmeraldHeal();
			player.meleeDamage += 0.1f;
			player.minionDamage += 0.1f;
			player.magicDamage += 0.1f;
			player.rangedDamage += 0.1f;
			player.thrownDamage += 0.1f;
			player.pStone = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CharmofMyths, 1);
			recipe.AddIngredient(ItemID.GoldDust, 15);
			recipe.AddIngredient(ItemID.Emerald, 12);
			recipe.AddIngredient(null, "ShinyOrb", 1);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddTile(114);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
