using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class TitanCrush : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Titanic Crush");
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.defense = (int)(npc.defense / 2);
			npc.GetGlobalNPC<BTFANPC>(mod).titanCrush = true;

			if (Main.rand.Next(3) == 0)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 1);
				Main.dust[dust].scale = 2.5f;
				Main.dust[dust].noGravity = true;		
			}
		}
	}
}