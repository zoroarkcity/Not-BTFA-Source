using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class FernlingMinion : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Fernling");
			Description.SetDefault("Its a wood-pecker HAHAHA GET IT?");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			BTFAPlayer modPlayer = player.GetModPlayer<BTFAPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("FernlingMinion")] > 0)
			{
				modPlayer.Fernling = true;
			}
			if (!modPlayer.Fernling)
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
