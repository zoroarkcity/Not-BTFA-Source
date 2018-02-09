using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class ServantOfCthulhu : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Servant Of Cthulhu");
			Description.SetDefault("You have eyes at the back of your head!");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			BTFAPlayer modPlayer = player.GetModPlayer<BTFAPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("Servant")] > 0)
			{
				modPlayer.Servant = true;
			}
			if (!modPlayer.Servant)
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
