using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class Disarmed : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Disarmed");
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
			if (npc.boss == false)
			{
				npc.defense /= 4;
			}
			
			npc.defense /= 2;
		}
	}
}