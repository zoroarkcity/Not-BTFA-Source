using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class Frozen : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Frozen");
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
			if (npc.boss == false && npc.type != (247 | 248 | 264 | 265 | 13 | 14 | 15))
			{
				npc.velocity.X *= 0.75f;
				npc.velocity.Y *= 0.75f;
			}
			

			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 67);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;		
			}
		}
	}
}