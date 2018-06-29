using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory 
{
	public class Blessed_Pearl : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 28;
			item.value = 101500;
			item.rare = 4;
			item.accessory = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Holy Pearl");
      Tooltip.SetDefault("Taking over 15 damage has a 1/2 chance to restore 15 health"
	  + "\nTaking damage when under half of your max health will restore even more health"
	  +	"\nIncreased length of invincibility"
	  + "\n'Protect it, and it will protect you'");
    }

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrossNecklace);
			recipe.AddIngredient(null, "Pearl");
			recipe.AddTile(114);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).pearl2 = true;
			player.longInvince = true;
		}
		
		public override bool CanEquipAccessory(Player player, int slot)
		{
			if (((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).pearl == true)
			{
				return false;
			}
			
			else
			{
				return true;
			}
		}
	}	
}
