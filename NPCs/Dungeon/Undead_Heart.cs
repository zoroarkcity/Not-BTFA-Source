using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Dungeon
{
    public class Undead_Heart : ModNPC // lol ballsack
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Undead Heart");
			Main.npcFrameCount[npc.type] = 8;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = 0;  
			npc.lifeMax = 350;	 
            npc.defense = 0;  
            npc.knockBackResist = 0.5f;
            npc.width = 34;
            npc.height = 48;
			npc.damage = 35;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.HitSound = SoundID.NPCHit2;
        }
		public override void AI()
        {
			Player player = Main.player[npc.target];
			Vector2 vector2 = new Vector2(npc.position.X + (float) npc.width * 0.5f, npc.position.Y + (float) npc.height * 0.5f);
                float num2 = Main.player[npc.target].position.X + (float) (Main.player[npc.target].width / 2) - vector2.X;
                float num3 = Main.player[npc.target].position.Y + (float) (Main.player[npc.target].height / 2) - vector2.Y;
                float num4 = 8f / (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
				npc.velocity.X = num2 * num4 * 0.4f;
                npc.velocity.Y = num3 * num4 * 0.4f;
        }
		public override void HitEffect(int hitDirection, double damage)
		{
			/*if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Stinging_Energy_Gore"), 1f);
			}*/
		}
		public override void OnHitPlayer (Player target, int damage, bool crit)
		{	
			for(int i = 0; i < Main.npc.Length; i++)
			{
				if (Main.npc[i].active && Main.npc[i].life < Main.npc[i].lifeMax && !Main.npc[i].friendly && Main.npc[i].damage >= 1 && Main.npc[i].type != mod.NPCType("Undead_Heart") && (double) Vector2.Distance(Main.npc[i].Center, npc.Center) <= (double) 300f)
				{
					Main.npc[i].life += damage; 
					Main.npc[i].HealEffect(damage, true); 
				}
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return spawnInfo.player.ZoneDungeon ? 0.075f : 0f;
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
			
			{
				npc.frameCounter++;
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
				else if (npc.frameCounter < 30)
				{
					npc.frame.Y = Frame_5 * frameHeight;
				}
				else if (npc.frameCounter < 36)
				{
					npc.frame.Y = Frame_6 * frameHeight;
				}
				else if (npc.frameCounter < 42)
				{
					npc.frame.Y = Frame_7 * frameHeight;
				}
				else if (npc.frameCounter < 48)
				{
					npc.frame.Y = Frame_8 * frameHeight;
				}
				else
				{
					npc.frameCounter = 0;
				}
			}
		}
		public override void NPCLoot()
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("UndeadEnergy"), Main.rand.Next(2, 7));
			if (Main.rand.Next(12) == 0) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("UndeadScythe")));
		}
    }
}