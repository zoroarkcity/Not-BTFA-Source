using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class BoilingBlood2 : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Boiling Blood II");
			Description.SetDefault("Increased damage taken");
			Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
            canBeCleared = true;
		}
        
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<BTFANPC>(mod).boilingBlood2 = true;
        }
	}
}
