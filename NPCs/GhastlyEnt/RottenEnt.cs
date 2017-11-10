using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Events;
using Terraria.ModLoader;
using System;

namespace ForgottenMemories.NPCs.GhastlyEnt
{
	public class RottenEnt : ModNPC
	{
		int ai;
		public override void SetDefaults()
		{
			npc.width = 92;
			npc.height = 126;
			npc.damage = 60;
			npc.defense = 18;
			npc.lifeMax = 1000;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = 31;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rottenwood Goliath");
			Main.npcFrameCount[npc.type] = 4;
		}
		
		public override void AI()
        {
			Player player = Main.player[npc.target];
			ai++;
			if (ai >= 300)
			{
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Woodlouse"));
				ai = 0;
			}
			
			Vector2 newMove = npc.Center - player.Center;
			float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
			
			if (!player.active || player.dead || distanceTo >= 1000)
            {
                npc.TargetClosest(false);
				
				if (npc.timeLeft > 60)
				{
					npc.timeLeft = 60;
				}
            }
			
			if (npc.position.X > player.position.X)
			{
				npc.spriteDirection = -1;
			}
			if (npc.position.X < player.position.X)
			{
				npc.spriteDirection = 1;
			}
		}
		
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.12f;
			npc.frameCounter %= Main.npcFrameCount[npc.type]; 
			int frame = (int)npc.frameCounter; 
			npc.frame.Y = frame * frameHeight; 
		}
		
		public override void NPCLoot()
		{
			if(Main.rand.Next(10) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WoodlouseStaff"));
			}
		}
	}
}
