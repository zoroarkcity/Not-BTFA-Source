using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.NightlyEssence
{
	[AutoloadEquip(EquipType.Head)]
	public class AssassinsHood : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 35000;
			item.rare = 1;
			item.defense = 2;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Assassin's Cowl");
      Tooltip.SetDefault("5% increased ranged critical strike chance");
    }


		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("AssassinsRobes") && legs.type == mod.ItemType("AssassinsTrousers");
		}

        public override void UpdateEquip(Player player)
        {
            player.rangedCrit += 5;
        }

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Ranged projectiles move 25% more swiftly";
			((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).rangedVelocity += 0.25f;
		}
        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
        }
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"DarkEnergy", 8);
			recipe.AddIngredient(ItemID.Silk, 15);
			recipe.AddRecipeGroup("AnyIron", 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
