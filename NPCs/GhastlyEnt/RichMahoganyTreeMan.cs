using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using System;

namespace ForgottenMemories.NPCs.GhastlyEnt
{
	public class RichMahoganyTreeMan : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 16;
			npc.height = 40;
			npc.damage = 33;
			npc.defense = 10;
			npc.lifeMax = 70;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = 508;
            music = MusicID.Boss3;
			banner = npc.type;
			bannerItem = mod.ItemType("MahoganyTreemanBannerItem");
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mahogany Ent");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
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
		
		public override void NPCLoot()
		{
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/RichMahoganyTreeMan/RichMahoganyTreeManGore1"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/RichMahoganyTreeMan/RichMahoganyTreeManGore2"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/RichMahoganyTreeMan/RichMahoganyTreeManGore3"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/RichMahoganyTreeMan/RichMahoganyTreeManGore4"), 1f);
			int amountToDrop = Main.rand.Next(3,10);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RichMahogany, amountToDrop);
			if(Main.rand.Next(30) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LivingTwig"));
			}
		}
	}
}
