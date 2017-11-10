using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class DevilsCurse : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Devil Curse");
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.defense -= (int)(npc.defense * 0.15);
		}
	}
}