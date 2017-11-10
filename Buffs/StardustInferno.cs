using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class StardustInferno : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Stardust Inferno");
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.lifeRegen -= 20;
			npc.defense /= 2;
			npc.damage /= 2;

			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 269);
				int dust2 = Dust.NewDust(npc.position, npc.width, npc.height, 211);
				Main.dust[dust].scale = 3.5f;
				Main.dust[dust].noGravity = true;
				Main.dust[dust2].scale = 3.5f;
				Main.dust[dust2].noGravity = true;					
			}
		}
	}
}