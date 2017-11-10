using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class Electrified : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("ZAP");
		}
		
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.lifeRegen -= 18;
			if (npc.boss == false)
			{
				npc.velocity.X *= 0f;
				npc.velocity.Y *= 0f;
			}
			if (npc.boss == true)
			{
				npc.lifeRegen -= 9;
			}
			if (Main.rand.Next(2) == 0)
			{
				int dust2 = Dust.NewDust(npc.position, npc.width, npc.height, 226);
				Main.dust[dust2].scale = 1.5f;
				Main.dust[dust2].noGravity = true;		
			}
		}
	}
}