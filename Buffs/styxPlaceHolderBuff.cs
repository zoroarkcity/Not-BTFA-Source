using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class styxPlaceHolderBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Styx");
			Description.SetDefault("Consider this a magical trick");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			canBeCleared = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
		}
	}
}
