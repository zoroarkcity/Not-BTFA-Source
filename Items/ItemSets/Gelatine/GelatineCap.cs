using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Gelatine
{
	[AutoloadEquip(EquipType.Head)]
	public class GelatineCap : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;

			item.value = 35000;
			item.rare = 1;
			item.defense = 3;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Gelatine Cap");
      Tooltip.SetDefault("10% increased movement speed");
    }


		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("GelatineBreastplate") && legs.type == mod.ItemType("GelatineGreaves");
		}

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.10f;
        }

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Summons a Slime Guard to fight for you";
			((TgemPlayer)player.GetModPlayer(mod, "TgemPlayer")).slimeGuard = true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GelatineBar", 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
