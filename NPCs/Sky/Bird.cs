using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;

namespace ForgottenMemories.NPCs.Sky
{
    public class Bird : ModNPC
    {
		protected int diveTimer = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soaring Pecker"); //Please adjust misc stats
			Main.npcFrameCount[npc.type] = 6;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = 14;
			npc.lifeMax = 225;	 
            npc.defense = 5;  
			npc.value = 500f;
            npc.knockBackResist = 0.1f;
            npc.width = 40;
            npc.height = 40;
			npc.damage = 30;
            npc.noGravity = true;
            npc.noTileCollide = false;
            npc.HitSound = SoundID.NPCHit28;
            npc.DeathSound = SoundID.NPCDeath31;
        }
		public override void AI()
        {
			Player player = Main.player[npc.target];
			npc.spriteDirection = npc.direction;
			
			attemptDive();
        }
		public void attemptDive()
		{
			diveTimer++;
			float num12 = 20f;
			float num13 = 0.0f;
			float num15 = num13 * num12;
			
			float num16 = 10f;
			Vector2 center = npc.Center;
			Vector2 v = Main.player[npc.target].Center - center;
			Vector2 vector2_1 = v - Vector2.UnitY * 20f;
			Vector2 vector2_2 = Vector2.Normalize(vector2_1);
			if (diveTimer >= 120)
			{
				npc.rotation = npc.velocity.ToRotation();
				if ((double) npc.rotation < -1.57079637050629)
					npc.rotation += 3.141593f;
				if ((double) npc.rotation > 1.57079637050629)
					npc.rotation -= 3.141593f;
				npc.velocity.X = (npc.velocity.X * (31.5f - 1f) + vector2_2.X) / 30f;
				npc.velocity.Y = (npc.velocity.Y * (31.5f - 1f) + vector2_2.Y) / 30f;
				{
				  int index = Dust.NewDust(npc.position, npc.width, npc.height, 16, 0.0f, 0.0f, 100, new Color(), 1.5f);
				  Main.dust[index].noGravity = true;
				  Main.dust[index].velocity = npc.velocity / 5f;
				  Vector2 spinningpoint = new Vector2(-10f, 10f);
				  if (npc.spriteDirection == 1)
					spinningpoint.X *= -1f;
				  spinningpoint = spinningpoint.RotatedBy((double) npc.rotation, new Vector2());
				  Main.dust[index].position = npc.Center + spinningpoint;
				}
				if (diveTimer >= 180)
				{
					diveTimer = 0;
				}
			}
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WispDudes/Bird"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WispDudes/Bird_2"), 1f);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return spawnInfo.player.ZoneSkyHeight && NPC.downedBoss2 && !spawnInfo.invasion ? 0.06f : 0f;
		}
		public override void NPCLoot()
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoaringEnergy"), Main.rand.Next(5, 9));
			if(Main.rand.Next(16) == 0 && !Main.hardMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Valhalla"));
			}
			if(Main.rand.Next(32) == 0 && Main.hardMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Valhalla"));
			}
		}
		public override void FindFrame(int frameHeight) //Do not touch npc
		{
			const int Frame_1 = 0;
			const int Frame_2 = 1;
			const int Frame_3 = 2;
			const int Frame_4 = 3;
			const int Frame_5 = 4;
			const int Frame_6 = 5;
			
				npc.frameCounter++;
			if (diveTimer < 180 && diveTimer >= 120)
			{
				npc.frame.Y = Frame_6 * frameHeight;
			}
			else
			{
				if (npc.frameCounter < 6)
				{
					npc.frame.Y = Frame_1 * frameHeight;
				}
				else if (npc.frameCounter < 12)
				{
					npc.frame.Y = Frame_2 * frameHeight;
				}
				else if (npc.frameCounter < 18)
				{
					npc.frame.Y = Frame_3 * frameHeight;
				}
				else if (npc.frameCounter < 24)
				{
					npc.frame.Y = Frame_4 * frameHeight;
				}
				else if (npc.frameCounter < 28)
				{
					npc.frame.Y = Frame_5 * frameHeight;
				}
				else
				{
					npc.frameCounter = 0;
				}
			}
		}
    }
}