using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class CosmicCurse : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Cosmos Curse");
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.defense -= 7;

			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 15);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;		
			}
		}
	}
}