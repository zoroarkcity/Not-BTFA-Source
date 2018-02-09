using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class BloodSlime : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Living Blood");
			Description.SetDefault("Living Blood fights for you");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			BTFAPlayer modPlayer = player.GetModPlayer<BTFAPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("BloodSlime")] > 0)
			{
				modPlayer.BloodSlime = true;
			}
			if (!modPlayer.BloodSlime)
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