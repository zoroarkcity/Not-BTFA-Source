using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items
{
	public class ThrownConsume : GlobalItem
	{
		public override bool ConsumeItem(Item item, Player player)
		{
			if (((BTFAPlayer)player.GetModPlayer(mod, "BTFAPlayer")).BlightConserve == true && Main.rand.Next(4) == 0 && item.thrown == true)
			{
				return false;
			}
			
			return true;
		}
	}
}