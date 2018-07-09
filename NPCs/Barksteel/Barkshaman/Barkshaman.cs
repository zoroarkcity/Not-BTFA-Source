using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Barksteel.Barkshaman
{
    public class Barkshaman : ModNPC
    {
		protected int healTimer = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Barkshaman");
			Main.npcFrameCount[npc.type] = 9;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = 3;  
			npc.lifeMax = 500;	 
            npc.defense = 10;  
			npc.value = 500f;
			aiType = 73;
            npc.knockBackResist = 0f;
            npc.width = 40;
            npc.height = 80;
			npc.damage = 45;
            npc.lavaImmune = true;
            npc.noTileCollide = false;
            npc.HitSound = 	new Terraria.Audio.LegacySoundStyle(42, 71);
			npc.dontTakeDamage = false;
            npc.DeathSound = new Terraria.Audio.LegacySoundStyle(42, 67);
        }
		public override void AI()
        {
			Player player = Main.player[npc.target];
			npc.spriteDirection = npc.direction;

			
			healTimer++;
			
			if (healTimer >= 300)
			{
				healTimer = 0;
				for(int i = 0; i < Main.npc.Length; i++)
				{
					if (Main.npc[i].active && !Main.npc[i].friendly && Main.npc[i].life < Main.npc[i].lifeMax - 20 &&  Main.npc[i].damage >= 1 && Main.npc[i].type != mod.NPCType("Barkshaman") && (double) Vector2.Distance(Main.npc[i].Center, npc.Center) <= (double) 600f && (npc.velocity.Y == (double) 0.0))
					{
						Main.npc[i].life += 20; 
						Main.npc[i].HealEffect(20, true); 
						Main.PlaySound(new Terraria.Audio.LegacySoundStyle(42, 50));
					}
				}
			}
			for(int i = 0; i < Main.npc.Length; i++)
			{
				if (healTimer >= 240 && ((Main.npc[i].active && !Main.npc[i].friendly && Main.npc[i].life < Main.npc[i].lifeMax - 20 && Main.npc[i].damage >= 1 && (double) Vector2.Distance(Main.npc[i].Center, npc.Center) <= (double) 600f)  && (npc.velocity.Y == (double) 0.0) || (npc.active && npc.life < npc.lifeMax - 50)) && (npc.velocity.Y == (double) 0.0))
				{
					npc.aiStyle = 0;
					npc.velocity.X = 0f;
					npc.dontTakeDamage = true;
				}
				else if (healTimer < 240)
				{
					Vector2 vektor2 = new Vector2(npc.position.X + (float) npc.width * 0.5f, npc.position.Y + (float) npc.height * 0.5f);
					float number2 = Main.player[npc.target].position.X + (float) (Main.player[npc.target].width / 2) - vektor2.X;
					float number3 = Main.player[npc.target].position.Y + (float) (Main.player[npc.target].height / 2) - vektor2.Y;
					float number4 = 8f / (float) Math.Sqrt((double) number2 * (double) number2 + (double) number3 * (double) number3);
					npc.velocity.X = number2 * number4 * 0.15f;	
					npc.aiStyle = 3;
					npc.dontTakeDamage = false;
				}
			}
        }
		public override void NPCLoot ()
		{	
			if (Main.rand.Next(1) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Barksteel"), Main.rand.Next(3, 8));
			}
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				//Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Husk_Spearman_Gore"), 1f);
				//Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Husk_Spearman_Gore_2"), 1f);
			}
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
			const int Frame_9 = 8;
			
			npc.spriteDirection = npc.direction;
			Player player = Main.player[npc.target];
			npc.frameCounter++;
			Dust dust;
			Dust dust2;
			if (npc.velocity.Y != (double) 0.0)
			{
				npc.frame.Y = Frame_9 * frameHeight;
			}	
			for(int i = 0; i < Main.npc.Length; i++)
			{
				if ((npc.velocity.Y == (double) 0.0) && healTimer >= 300-60 && ((Main.npc[i].active && !Main.npc[i].friendly && Main.npc[i].life < Main.npc[i].lifeMax - 20 && Main.npc[i].damage >= 1 && (double) Vector2.Distance(Main.npc[i].Center, npc.Center) <= (double) 600f) || (npc.active && npc.life < npc.lifeMax - 50)))
				{
					if (npc.frameCounter < 12)
					{
						npc.frame.Y = Frame_4 * frameHeight;
					}
					else if (npc.frameCounter < 24)
					{
						npc.frame.Y = Frame_5 * frameHeight;
					}
					else if (npc.frameCounter < 36)
					{
						npc.frame.Y = Frame_6 * frameHeight;
					}
					else if (npc.frameCounter < 48)
					{
						npc.frame.Y = Frame_7 * frameHeight;
					}
					else if (npc.frameCounter < 60)
					{
						npc.frame.Y = Frame_8 * frameHeight;
					}
					else
					{
						npc.life += 50; 
						npc.HealEffect(50, true); 
						healTimer = 0;
						npc.frameCounter = 0;
						Main.PlaySound(new Terraria.Audio.LegacySoundStyle(42, 50));
					}
				}
				else if (healTimer < 300 && (npc.velocity.Y == (double) 0.0))
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
					else
					{
						npc.frameCounter = 0;
					}
				}
			}
		}
    }
}