using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Pet.Fatfrog
{
	public class Tadpole_Egg : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Obese Frogspawn");
			Tooltip.SetDefault("Summons a Fatfrog to amuse you");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = mod.ProjectileType("Fatfrog");
			item.buffType = mod.BuffType("Fatfrog_Buff");
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