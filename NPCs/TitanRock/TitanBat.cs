using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.TitanRock
{
	public class TitanBat : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 20;
			npc.height = 14;
			npc.damage = 35;
			npc.defense = 15;
			npc.lifeMax = 100;
			npc.HitSound = SoundID.NPCHit41;
			npc.DeathSound = SoundID.NPCDeath44;
			npc.value = 0f;
			npc.knockBackResist = 1f;
			npc.aiStyle = 14;
			aiType = NPCID.GiantBat;
			animationType = NPCID.GiantBat;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titan Bat");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.GiantBat];
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = 200;
			npc.damage = 70;
		}
		
		public override bool PreNPCLoot()
		{
			for (int i = 0; i < 10; ++i)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60);
			}
			
			return false;
		}
	}
}
