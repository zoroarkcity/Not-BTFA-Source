using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using System;

namespace ForgottenMemories.NPCs.GhastlyEnt
{
	public class BambooTreeMan : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 16;
			npc.height = 40;
			npc.damage = 15;
			npc.defense = 8;
			npc.lifeMax = 350;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = 508;
			music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/Forests_Army");
		//	banner = npc.type;
		//	bannerItem = mod.ItemType("BorealTreemanBannerItem");
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bamboo Ent");
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
			int amountToDrop = Main.rand.Next(3,10);
		    Mod Wildlife = ModLoader.GetMod("Wildlife");
            if (Wildlife != null)
			{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (Wildlife.ItemType("Bamboo")), amountToDrop);
			}
			if(Main.rand.Next(30) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LivingTwig"));
			}
		}
	}
}