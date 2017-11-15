using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.SoaringEssence
{
	[AutoloadEquip(EquipType.Head)]
	public class SoaringHelm : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 35000;
			item.rare = 2;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Soaring Cap");
		  Tooltip.SetDefault("5% increased magic damage and critical strike chance");
		}


		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("SoaringChest") && legs.type == mod.ItemType("SoaringGreaves");
		}

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.05f;
			player.magicCrit += 5;
        }

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "17% increased magic attack speed";
			((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).magicAttackSpeed += 0.17f;
		}

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"SoaringEnergy", 16);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
