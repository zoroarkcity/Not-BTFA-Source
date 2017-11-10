using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.UndeadEssence
{
	[AutoloadEquip(EquipType.Head)]
	public class UndeadHelmet : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 35000;
			item.rare = 3;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Skeletal Mask");
		  Tooltip.SetDefault("15% increased throwing damage");
		}


		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("UndeadBreastplate") && legs.type == mod.ItemType("UndeadGreaves");
		}

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.15f;
        }

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Throwing damage done creates life regen-increasing bone hearts";
			((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).boneHearts = true;
		}

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"UndeadEnergy", 12);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
