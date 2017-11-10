using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class Bleeding : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Bleeding");
		}
		
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.lifeRegen -= 8;

			if (Main.rand.Next(2) == 0)
			{
				int dust2 = Dust.NewDust(npc.position, npc.width, npc.height, 5);
				Main.dust[dust2].scale = 1.5f;
				Main.dust[dust2].noGravity = true;		
			}
		}
	}
}