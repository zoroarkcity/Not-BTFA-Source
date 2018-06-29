using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using System;

namespace ForgottenMemories.NPCs.GhastlyEnt
{
	public class SapEnt : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 70;
			npc.height = 90;
			npc.damage = 40;
			npc.defense = 20;
			npc.lifeMax = 750;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = 31;
			music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/Forests_Army");
			//banner = npc.type;
			//bannerItem = mod.ItemType("BorealTreemanBannerItem");
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sap Sprout");
			Main.npcFrameCount[npc.type] = 7;
			animationType = NPCID.Zombie;
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
		
		public override void HitEffect(int hitDirection, double damage)
		{
			if(Main.rand.Next(5) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SmolSap"));
		}
		
		public override void NPCLoot()
		{
			for(int i = 0; i < 3; i++)
			{
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SmolSap"));
			}
		}
	}
}
