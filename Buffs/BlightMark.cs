using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories;

namespace ForgottenMemories.Buffs
{
	public class BlightMark : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Blight Mark");
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
			//npc.GetGlobalNPC<BTFANPC>(mod).blightMark = true;
			npc.GetGlobalNPC<BTFANPC>(mod).blightFlame = true;

			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 173);
				Main.dust[dust].scale = 1.8f;
				Main.dust[dust].noGravity = true;		
			}
		}
	}
}