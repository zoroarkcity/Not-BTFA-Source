using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Desert
{
    public class Desert_Totem : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Totem");
			Main.npcFrameCount[npc.type] = 8;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = 3;  
			npc.lifeMax = 250;	 
            npc.defense = 12;  
			npc.value = 100f;
			aiType = 73;
            npc.knockBackResist = 1.5f;
            npc.width = 36;
            npc.height = 84;
			npc.damage = 25;
            npc.lavaImmune = true;
            npc.noTileCollide = false;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.HitSound = SoundID.NPCHit2;
			npc.dontTakeDamage = false;
        }
		public override void AI()
        {
			Player player = Main.player[npc.target];
			npc.spriteDirection = npc.direction;
			if ((npc.active && player.active && (double) Vector2.Distance(player.Center, npc.Center) >= (double) 200f))
            {
				npc.velocity.X = 0f;
				npc.dontTakeDamage = true;
				npc.aiStyle = 0;
			}
			else
			{
				Vector2 vector2 = new Vector2(npc.position.X + (float) npc.width * 0.5f, npc.position.Y + (float) npc.height * 0.5f);
				float num2 = Main.player[npc.target].position.X + (float) (Main.player[npc.target].width / 2) - vector2.X;
				float num3 = Main.player[npc.target].position.Y + (float) (Main.player[npc.target].height / 2) - vector2.Y;
				float num4 = 8f / (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
				npc.velocity.X = num2 * num4 * 0.4f;	
				npc.dontTakeDamage = false;
				npc.aiStyle = 3;
			}
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return spawnInfo.desertCave && NPC.downedBoss1 ? 0.08f : 0f;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WispDudes/Desert_Totem"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WispDudes/Desert_Totem_2"), 1f);
			}
		}
		public override void NPCLoot ()
		{
			{
			if (Main.rand.Next(5) == 0) Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, 658, (int)(npc.damage/6), 1f, npc.target, 0f, 0f);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BossEnergy"), Main.rand.Next(5, 9));
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
			Player player = Main.player[npc.target];
			
			if ((npc.active && player.active && (double) Vector2.Distance(player.Center, npc.Center) >= (double) 200f))
            {
				npc.frame.Y = Frame_8 * frameHeight;
			}
			else 
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
				else if (npc.frameCounter < 28)
				{
					npc.frame.Y = Frame_5 * frameHeight;
				}
				else if (npc.frameCounter < 32)
				{
					npc.frame.Y = Frame_6 * frameHeight;
				}
				else if (npc.frameCounter < 38)
				{
					npc.frame.Y = Frame_7 * frameHeight;
				}
				else
				{
					npc.frameCounter = 0;
				}
			}
		}
    }
}