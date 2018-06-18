using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using System;

namespace ForgottenMemories.NPCs.GhastlyEnt
{
	public class RedwoodRam : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 122;
			npc.height = 56;
			npc.damage = 40;
			npc.defense = 10;
			npc.lifeMax = 430;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 26;
			aiType = 508;
			music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/Forests_Army");
			banner = npc.type;
			bannerItem = mod.ItemType("RedwoodRammerBannerItem");
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Redwood Ram");
			Main.npcFrameCount[npc.type] = 4;
		}
		
		public override void AI()
		{
			Player player = Main.player[npc.target];
			
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
		}
		
		public override void FindFrame(int frameHeight)
		{
			if (npc.velocity.Y == 0.0)
			{
				if (npc.direction == 1)
					npc.spriteDirection = 1;
				if (npc.direction == -1)
					npc.spriteDirection = -1;
				
				npc.frameCounter += 0.25f; 
				npc.frameCounter %= 4; 
				int frame = (int)npc.frameCounter; 
				npc.frame.Y = frame * frameHeight;
			}
		}
		
		public override void NPCLoot()
		{
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/RedwoodRammer/RedwoodRammerGore1"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/RedwoodRammer/RedwoodRammerGore2"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/RedwoodRammer/RedwoodRammerGore3"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/RedwoodRammer/RedwoodRammerGore4"), 1f);
			if(Main.rand.Next(30) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RedwoodPike"));
			}
		}
	}
}
