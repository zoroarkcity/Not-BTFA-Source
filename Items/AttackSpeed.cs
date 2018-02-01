using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items
{
	public class AttackSpeed : GlobalItem
	{
		public override float UseTimeMultiplier(Item item, Player player)
		{
			if (item.magic)
			{
				return ((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).magicAttackSpeed;
			}
			
			return 1f;
		}
		
		public override float MeleeSpeedMultiplier(Item item, Player player)
		{
			if (item.magic)
			{
				return ((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).magicAttackSpeed;
			}
			
			return 1f;
		}
	}
}