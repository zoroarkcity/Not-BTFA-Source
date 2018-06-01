using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;

namespace ForgottenMemories.NPCs.Sky
{
	public class MysteriousAlienSpacecraft : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 48;
			npc.height = 36;
			npc.damage = 30;
			npc.defense = 16;
			npc.lifeMax = 130;
			npc.HitSound = SoundID.NPCHit53;
			npc.DeathSound = SoundID.NPCDeath56;
			npc.value = 70f;
			npc.knockBackResist = 1f;
			npc.aiStyle = 14;
			aiType = -1;
			bannerItem = mod.ItemType("MysteriousAlienSpacecraftBannerItem");
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mysterious Alien Spacecraft");
			Main.npcFrameCount[npc.type] = 3;
		}
		
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.25f; 
			npc.frameCounter %= Main.npcFrameCount[npc.type]; 
			int frame = (int)npc.frameCounter; 
			npc.frame.Y = frame * frameHeight; 
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return spawnInfo.player.ZoneSkyHeight ? 0.15f : 0f;
		}
		
		public override void NPCLoot()
		{
			if(Main.rand.Next(2) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DivineBolt"));
			}
			
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MysteriousAlienSpacecraft/MysteriousAlienSpacecraftGore1"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MysteriousAlienSpacecraft/MysteriousAlienSpacecraftGore2"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MysteriousAlienSpacecraft/MysteriousAlienSpacecraftGore3"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MysteriousAlienSpacecraft/MysteriousAlienSpacecraftGore4"), 1f);
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 1f);
			npc.damage = (int)(npc.damage * 1f);
		}
		
	}
}
