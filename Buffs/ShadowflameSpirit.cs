using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class ShadowflameSpirit : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Shadowflame Spirit");
			Description.SetDefault("A malevolent spirit fights for you");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			BTFAPlayer modPlayer = player.GetModPlayer<BTFAPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("ShadowflameSpirit")] > 0)
			{
				modPlayer.ShadowflameSpirit = true;
			}
			if (!modPlayer.ShadowflameSpirit)
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