using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;

namespace ForgottenMemories.NPCs.Sky
{
	public class CosmowyvernTail : Worm
	{
		public override void SetDefaults()
		{
			npc.width = (int)(50 * 0.7f);
			npc.height = (int)(36 * 0.7f);
			npc.damage = 50;
			npc.defense = 18;
			npc.lifeMax = 1000;
			npc.HitSound = SoundID.NPCHit41;
			npc.DeathSound = SoundID.NPCDeath44;
			npc.noGravity = true;
			npc.value = 100;
			npc.knockBackResist = 0f;
			npc.dontTakeDamage = true;
			
			tail = true;
			
			flies = true;
			directional = true;
			headType = mod.NPCType("CosmowyvernHead");
			bodyType = mod.NPCType("CosmowyvernBody");
			tailType = mod.NPCType("CosmowyvernTail");
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmowyvern");
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = 1200;
		}
		
		public override void NPCLoot()
		{
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Cosmowyvern/CosmowyvernTailGore"), 1f);
			for (int m = 0; m <= 10; m++)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 15);
			}
		}
		
		public override void CustomBehavior()
		{
			npc.spriteDirection *= -1;
		}
	}
}
