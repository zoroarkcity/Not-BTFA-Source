using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;

namespace ForgottenMemories.NPCs.Sky
{
	public class CosmowyvernBody : Worm
	{
		int type;
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
			
			Main.npcFrameCount[npc.type] = 2;
			
			type = 0;
			
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
			for (int m = 0; m <= 10; m++)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 15);
			}
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpaceRockFragment"), Main.rand.Next(1, 4));	
		}
		
		public override void CustomBehavior()
		{
			if (type == 0)
			{	
				type = Main.rand.Next(2) + 1;
			}
			npc.spriteDirection *= -1;
		}
		
		public override void FindFrame(int frameHeight)
		{
			npc.frame.Y = (type - 1) * frameHeight;
		}
	}
}
