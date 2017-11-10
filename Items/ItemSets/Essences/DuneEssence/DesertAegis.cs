using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.DuneEssence
{
	[AutoloadEquip(EquipType.Shield)]
	public class DesertAegis : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Grants immunity to strong winds \n'Protects from mirages and the desert winds'");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 3500;
			item.rare = 1;
			item.accessory = true;
			item.defense = 4;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			{
			player.buffImmune[BuffID.WindPushed] = true;
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"BossEnergy", 4);
			recipe.AddIngredient(ItemID.Cactus, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}