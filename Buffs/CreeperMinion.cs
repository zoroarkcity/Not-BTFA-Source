using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class CreeperMinion : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Creeper minion");
			Description.SetDefault("A creeper fights for you");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			BTFAPlayer modPlayer = player.GetModPlayer<BTFAPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("CreeperMinion")] > 0)
			{
				modPlayer.CreeperMinion = true;
			}
			if (!modPlayer.CreeperMinion)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}