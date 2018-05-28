using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Pet.Chicken
{
	public class TrashSeed : ModItem
	{
		public override void SetStaticDefaults()
		{
			 DisplayName.SetDefault("Recycled Seeds");
			 Tooltip.SetDefault("Summons a giant chicken to follow you around");
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = -1;
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = mod.ProjectileType("ChickenGiant");
			item.buffType = mod.BuffType("Chicken");
		}
		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}