using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.NPCs.Night
{
    public class Some_Fucking_Owl : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nightly Owl");
			Main.npcFrameCount[npc.type] = 7;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = 0;  
			npc.lifeMax = 50;	 
            npc.defense = 5;  
			npc.value = 90f;
            npc.knockBackResist = 2f;
            npc.width = 40;
            npc.height = 42;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = false;
            npc.HitSound = 	new Terraria.Audio.LegacySoundStyle(29, 48);
            npc.DeathSound = SoundID.NPCDeath43;
			NPCID.Sets.TrailCacheLength[npc.type] = 10;
			NPCID.Sets.TrailingMode[npc.type] = 3;
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return spawnInfo.spawnTileY < Main.rockLayer && !Main.dayTime && !spawnInfo.invasion && !spawnInfo.sky && !Main.eclipse && !spawnInfo.player.ZoneDesert && !spawnInfo.player.ZoneJungle ? 0.05f : 0f;
		}
		public override void AI()
        {
			Player player = Main.player[npc.target];
			npc.spriteDirection = npc.direction;
			
            if (player == Main.player[npc.target])
            {
                if (npc.active && player.active && (double) Vector2.Distance(player.Center, npc.Center) >= (double) 200f && npc.life == npc.lifeMax)
                {
					Vector2 vector2 = new Vector2(npc.position.X + (float) npc.width * 0.5f, npc.position.Y + (float) npc.height * 0.5f);
					float num2 = Main.player[npc.target].position.X + (float) (Main.player[npc.target].width / 2) - vector2.X;
					float num3 = Main.player[npc.target].position.Y + (float) (Main.player[npc.target].height / 2) - vector2.Y;
					float num4 = 8f / (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
					npc.velocity.X = num2 * num4 * 0.3f;
					npc.velocity.Y = num3 * num4 * 0.3f;
					npc.damage = 0;
				}
				else if (Vector2.Distance(player.Center, npc.Center) < (double) 200f && npc.velocity.Y <= 0f && npc.velocity.X <= 0f)
				{
					npc.velocity.X -= 0.001f;
					npc.velocity.Y -= 0.001f;
				}
				if (npc.active && player.active && npc.life < npc.lifeMax)
                {
					Vector2 vector2 = new Vector2(npc.position.X + (float) npc.width * 0.5f, npc.position.Y + (float) npc.height * 0.5f);
					float num2 = Main.player[npc.target].position.X + (float) (Main.player[npc.target].width / 2) - vector2.X;
					float num3 = Main.player[npc.target].position.Y + (float) (Main.player[npc.target].height / 2) - vector2.Y;
					float num4 = 8f / (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
					npc.velocity.X = num2 * num4 * 0.46f;
					npc.velocity.Y = num3 * num4 * 0.46f;
					npc.damage = 20;
					if ((double) Math.Abs(npc.velocity.X) + (double) Math.Abs(npc.velocity.Y) > 1.0)
            		{
                		for (int index1 = 0; index1 < 1; ++index1)
                		{
                   			 int index2 = Dust.NewDust(new Vector2(npc.position.X - npc.velocity.X * 2f, (float) ((double) npc.position.Y - 2.0 - (double) npc.velocity.Y * 2.0)), npc.width, npc.height, 16, 0.0f, 0.0f, 100, new Color(), 2f);
                   			 Main.dust[index2].noGravity = true;
                    			 Main.dust[index2].noLight = true;
                   			 Main.dust[index2].velocity.X -= npc.velocity.X * 0.5f;
                   			 Main.dust[index2].velocity.Y = 0f;
                   			 Main.dust[index2].scale = 1f;
                		}
            		}
				}
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
			
			Player player = Main.player[npc.target];
			
			if (npc.active && player.active)
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
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WispDudes/Ow1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WispDudes/Owl_2"), 1f);
			}
		}
		public override void NPCLoot()
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkEnergy"), Main.rand.Next(2, 7));
			
			if(Main.rand.Next(10) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Valhalla"));
			}
		}
    }
}