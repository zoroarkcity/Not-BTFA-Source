using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;

namespace ForgottenMemories.NPCs.Sky
{
	public class CosmowyvernHead : Worm
	{
		public override void SetDefaults()
		{
			npc.width = (int)(50 * 0.7f);
			npc.height = (int)(48 * 0.7f);
			npc.noTileCollide = true;
			npc.damage = 50;
			npc.defense = 18;
			npc.lifeMax = 1000;
			npc.HitSound = SoundID.NPCHit41;
			npc.DeathSound = SoundID.NPCDeath44;
			npc.noGravity = true;
			npc.value = 100;
			npc.knockBackResist = 0f;
			bannerItem = mod.ItemType("CosmoRockWyvernBannerItem");
			
			head = true;
			flies = true;
			directional = true;
			minLength = 10;
			maxLength = 20;
			speed = 10f;
			turnSpeed = 10f;
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

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return spawnInfo.player.ZoneSkyHeight && TGEMWorld.downedTitanRock ? 0.05f : 0f;
		}
		
		public override void NPCLoot()
		{
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Cosmowyvern/CosmowyvernHeadGore"), 1f);
			for (int m = 0; m <= 10; m++)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 15);
			}
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpaceRockFragment"), Main.rand.Next(1, 4));	
		}
		
		public override void CustomBehavior()
		{
			npc.spriteDirection *= -1;
			
			if (!Main.player[npc.target].active || Main.player[npc.target].dead)
			{
				npc.TargetClosest(false);
                npc.velocity.Y = -20;
				if (npc.timeLeft > 10)
				{
					npc.timeLeft = 10;
				}
			}		
		}
	}
}
