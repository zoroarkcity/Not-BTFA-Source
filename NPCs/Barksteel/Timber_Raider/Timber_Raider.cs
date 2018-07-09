using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Barksteel.Timber_Raider
{
    public class Timber_Raider : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Timber Raider");
			Main.npcFrameCount[npc.type] = 8;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = 3;  
			npc.lifeMax = 110;	 
            npc.defense = 5;  
			npc.value = 500f;
			aiType = 73;
            npc.knockBackResist = 0.5f;
            npc.width = 28;
            npc.height = 36;
			npc.damage = 40;
            npc.lavaImmune = true;
            npc.noTileCollide = false;
            npc.HitSound = 	new Terraria.Audio.LegacySoundStyle(42, 93);
			npc.dontTakeDamage = false;
            npc.DeathSound = new Terraria.Audio.LegacySoundStyle(42, 107);
			banner = npc.type;
			bannerItem = mod.ItemType("Timber_Raider_Banner");
        }
		public override void AI()
        {
			Player player = Main.player[npc.target];
			npc.spriteDirection = npc.direction;

			Vector2 vector2 = new Vector2(npc.position.X + (float) npc.width * 0.5f, npc.position.Y + (float) npc.height * 0.5f);
			float num2 = Main.player[npc.target].position.X + (float) (Main.player[npc.target].width / 2) - vector2.X;
			float num3 = Main.player[npc.target].position.Y + (float) (Main.player[npc.target].height / 2) - vector2.Y;
			float num4 = 8f / (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
			npc.velocity.X = num2 * num4 * 0.35f;
			float distance = 1500f;		
        }
		public override void NPCLoot ()
		{	
			if (Main.rand.Next(2) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Barksteel"), Main.rand.Next(1, 5));
			}
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			//if (npc.life <= 0)
			//{
			//	Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Timber_Raider_Gore"), 1f);
			//	Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Timber_Raider_Gore_2"), 1f);
			//}
		}
		public override void FindFrame(int frameHeight)
		{
			const int Frame_1 = 0;
			const int Frame_2 = 1;
			const int Frame_3 = 2;
			const int Frame_4 = 3;
			const int Frame_5 = 4;
			const int Frame_6 = 5;
			const int Frame_7 = 6;
			const int Frame_8 = 7;
			
			Player player = Main.player[npc.target];
			npc.frameCounter++;
			if ((double) Vector2.Distance(player.Center, npc.Center) <= (double) 20f)
			{
				if (npc.frameCounter < 6)
				{
					npc.frame.Y = Frame_5 * frameHeight;
				}
				else if (npc.frameCounter < 12)
				{
					npc.frame.Y = Frame_6 * frameHeight;
				}
				else if (npc.frameCounter < 18)
				{
					npc.frame.Y = Frame_7 * frameHeight;
				}
				else if (npc.frameCounter < 24)
				{
					npc.frame.Y = Frame_8 * frameHeight;
					player.AddBuff(30, 8*60);
				}
				else
				{
					npc.frameCounter = 0;
				}
				npc.spriteDirection = npc.direction;
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
				else
				{
					npc.frameCounter = 0;
				}
				npc.spriteDirection = npc.direction;
			}
		}
    }
}