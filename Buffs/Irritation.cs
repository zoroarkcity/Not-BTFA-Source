using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class Irritation : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Irritation");
			//colin
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.lifeRegen -= 5;
		}
	}
}