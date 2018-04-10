using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class BoilingBlood : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Boiling Blood");
			Description.SetDefault("Melting from within");
			Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
            canBeCleared = true;
		}
        
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<BTFANPC>(mod).boilingBlood = true;
        }

		public override bool ReApply (NPC npc, int time, int buffIndex)
		{
			if (npc.GetGlobalNPC<BTFANPC>(mod).boilingBloodCounter < 140)
				npc.GetGlobalNPC<BTFANPC>(mod).boilingBloodCounter += 7;

			return false;
		}
	}
}
