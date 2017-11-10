using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Cryotine
{
	[AutoloadEquip(EquipType.Head)]
	public class CryotineHelmet : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;

			item.value = 15000;
			item.rare = 2;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Cryotine Helmet");
		  Tooltip.SetDefault("Increases minion damage by 10%");
		}
		
		public override bool DrawHead()	
		{
			return false;
		}


		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("CryotineChestplate") && legs.type == mod.ItemType("CryotineLeggings");
		}

        public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.1f;
        }

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Ice Crystals do 20% more damage and fire faster, homing projectiles \nIncreased max turrets";
			((TgemPlayer)player.GetModPlayer(mod, "TgemPlayer")).cryotine1 = true;
			player.maxTurrets += 1;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CryotineBar", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
