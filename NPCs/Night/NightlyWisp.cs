using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using System;

namespace ForgottenMemories.NPCs.Night
{
	public class NightlyWisp : ModNPC
	{
		public override void SetDefaults()
		{
			npc.width = 40;
			npc.height = 40;
			npc.damage = 18;
			npc.defense = 4;
			npc.lifeMax = 40;
			npc.HitSound = SoundID.NPCHit36;
			npc.DeathSound = SoundID.NPCDeath39;
			npc.value = 80f;
			npc.noTileCollide = false;
			npc.noGravity = true;
			npc.knockBackResist = 1f;
			//npc.aiStyle = 14;
			//aiType = NPCID.GiantBat;
		}
		
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nightly Wisp");
			Main.npcFrameCount[npc.type] = 4;
			//animationType = NPCID.GiantBat;
		}
		
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.2f;
			npc.frameCounter %= Main.npcFrameCount[npc.type]; 
			int frame = (int)npc.frameCounter; 
			npc.frame.Y = frame * frameHeight; 
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return spawnInfo.spawnTileY < Main.rockLayer && !Main.dayTime ? 0.05f : 0f;
		}
		
		public override void AI()
		{
			npc.ai[0]++;
			if (Main.rand.Next(700) == 0)
				Main.PlaySound(29, (int) npc.position.X, (int) npc.position.Y, Main.rand.Next(53, 55), 1f, 0.0f);
			if (npc.ai[0] < 180)
			{
				npc.TargetClosest(true);
				Vector2 vector2;
				vector2 = new Vector2(npc.Center.X, npc.Center.Y);
				float num1 = (float) (Main.player[npc.target].Center.X - vector2.X);
				float num2 = (float) (Main.player[npc.target].Center.Y - vector2.Y);
				float num3 = 12f / (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
				float num4 = num1 * num3;
				float num5 = num2 * num3;
				npc.velocity.X = ((npc.velocity.X * 100f + (float) num4) / 101f);
				npc.velocity.Y = ((npc.velocity.Y * 100f + (float) num5) / 101f);
				npc.spriteDirection = (npc.position.X < Main.player[npc.target].position.X) ? 1 : -1;
				int index = Dust.NewDust(npc.position, npc.width, npc.height, 173, 0.0f, 0.0f, 0, new Color(), 0.75f);
				Dust dust = Main.dust[index];
				dust.velocity = dust.velocity * 0.1f;
				//Main.dust[index].scale = 1.3f;
				Main.dust[index].noGravity = true;
			}
			
			else
			{
				
				Main.PlaySound(SoundID.NPCHit36, (int)npc.position.X, (int)npc.position.Y);
				float num4 = 7f;
				Vector2 vector2 = new Vector2(npc.position.X + (float) npc.width * 0.5f, npc.position.Y + (float) npc.height * 0.5f);
				float num5 = Main.player[npc.target].position.X + (float) (Main.player[npc.target].width / 2) - vector2.X;
				float num6 = Main.player[npc.target].position.Y + (float) (Main.player[npc.target].height / 2) - vector2.Y;
				float num7 = (float) Math.Sqrt((double) num5 * (double) num5 + (double) num6 * (double) num6);
				float num8 = num4 / num7;
				npc.velocity.X = num5 * num8;
				npc.velocity.Y = num6 * num8;
				npc.ai[0] -= 30;
				npc.ai[1]++;
			}
			
			if (npc.ai[1] > 1)
			{
				npc.ai[0] = 0;
				npc.ai[1] = 0;
			}
			
			
			
			if (Main.dayTime) //despawn
            {
                npc.TargetClosest(false);
                npc.velocity.Y = -20;
				npc.ai[0] = 0;
				npc.ai[1] = 0;
				if (npc.timeLeft > 10)
				{
					npc.timeLeft = 10;
				}
            }
		}
		
		public override void NPCLoot()
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkEnergy"), Main.rand.Next(2, 4));
		}
	}
}
