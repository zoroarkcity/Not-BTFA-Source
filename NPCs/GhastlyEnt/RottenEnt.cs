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
		int spawnerTimer = 0;//////////// WE NEEED A TIMER /////////////////////////
		const int maxAmountofWorms = 3;
		int spawnedWorms = 0;
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
			bannerItem = mod.ItemType("RottenEntBannerItem");
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

			spawnerTimer++; //////////////REDUCED THE SPAWN TIMER BUT DECREASED THE RANGE OF SPAWNING ///////////////////////////
			float distanceBeetweenPlayerandNPC = 700f;
			if (spawnerTimer >= 120 && spawnedWorms != 3 &&  player.active && (double) Vector2.Distance(npc.Center, player.Center) <= (double) distanceBeetweenPlayerandNPC)
			{
				{
					spawnerTimer = 0;
					spawnedWorms += 1; 
				    NPC.NewNPC((int)(npc.position.X), (int)(npc.position.Y), (mod.NPCType("WormHead")));
				}
			}
			if (Vector2.Distance(npc.Center, player.Center) >= (double) distanceBeetweenPlayerandNPC)
			{
				spawnerTimer = 0;
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
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/RottenEnt/RottenEntGore1"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/RottenEnt/RottenEntGore2"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/RottenEnt/RottenEntGore3"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/RottenEnt/RottenEntGore4"), 1f);
			spawnerTimer = 0;///////////////////////RESETS THE TIMER INCASE IT BUGS OUT////////////////////
			spawnedWorms = 0;///////////////////////RESETS THE WORM AMOUNT ////////////////////////////////
			if(Main.rand.Next(10) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WoodlouseStaff"));
			}
		}
	}
}
