using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Magnoliac
{
	[AutoloadBossHead]
    public class MagnoliacSwitchingPhase : ModNPC
    {	
	    public static int Switch = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magnoliac");
			Main.npcFrameCount[npc.type] = 6; // to be changed
		}
		
        public override void SetDefaults()
        {
			npc.aiStyle = 0;//custom ai
            npc.lifeMax = 55555; // change
            npc.damage = 40; // change
            npc.defense = 10; // change
            npc.knockBackResist = 0f;
            npc.width = 100; // change after testing
            npc.height = 150; // change after testing
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
			npc.dontTakeDamage = true;
			npc.friendly = true;
            npc.netAlways = true;
			npc.scale = 1f;
            music = MusicID.Boss3;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.3f);
		}
		public override void AI()
        {
			Player player = Main.player[npc.target];
			npc.spriteDirection = npc.direction;
			npc.velocity.X = 0f;
			npc.velocity.Y = 0f;
			if (npc.position.Y < player.position.Y - 2500 && npc.position.X < player.position.X - 2500 && npc.life < (npc.lifeMax - 1))
			{
				npc.active = false;		
			}
			if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
	  	    if (Main.player[npc.target].dead)
			{
				npc.active = false;
			}
        }
		const int Switching_Frame_1 = 0;
		const int Switching_Frame_2 = 1;
		const int Switching_Frame_3 = 2;
		const int Switching_Frame_4 = 3;
		const int Switching_Frame_5 = 4;
		const int Switching_Frame_6 = 5;


		public override void FindFrame(int frameHeight)
		{
			npc.spriteDirection = npc.direction;
			{
				npc.frameCounter++;
				if (npc.frameCounter < 10)
				{
					npc.frame.Y = Switching_Frame_1 * frameHeight;
				}
				else if (npc.frameCounter < 20)
				{
					npc.frame.Y = Switching_Frame_2 * frameHeight;
				}
				else if (npc.frameCounter < 30)
				{
					npc.frame.Y = Switching_Frame_3 * frameHeight;
				}
				else if (npc.frameCounter < 40)
				{
					npc.frame.Y = Switching_Frame_1 * frameHeight;
				}
				else if (npc.frameCounter < 50)
				{
					npc.frame.Y = Switching_Frame_2 * frameHeight;
				}
				else if (npc.frameCounter < 60)
				{
					npc.frame.Y = Switching_Frame_3 * frameHeight;
				}
				else if (npc.frameCounter < 70)
				{
					npc.frame.Y = Switching_Frame_4 * frameHeight;
				}
				else if (npc.frameCounter < 80)
				{
					npc.frame.Y = Switching_Frame_5 * frameHeight;
				}
				else if (npc.frameCounter < 90)
				{
					npc.frame.Y = Switching_Frame_6 * frameHeight;
				}
				else
				{
					npc.frameCounter = 0;
					npc.active = false;
					NPC.NewNPC((int)(npc.position.X), (int)(npc.position.Y + 160), (mod.NPCType("MagnoliacSecondStage")));
					Main.PlaySound(SoundID.NPCDeath31, npc.position);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Magnoliac/StageSwitch/MagnoliacLeavesGore1"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Magnoliac/StageSwitch/MagnoliacLeavesGore2"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Magnoliac/StageSwitch/MagnoliacLeavesGore3"), 1f);
					if ((double) npc.ai[1] == 30.0)
                        Main.PlaySound(29, (int) npc.Center.X, (int) npc.Center.Y, 92, 1f, 0.0f);
				}
			}
		}
	    public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			scale = 0f; // larger health bar
			return null;
        }
    }
}